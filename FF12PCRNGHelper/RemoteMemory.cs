using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace FF12PCRNGHelper
{
    /// <inheritdoc />
    /// <summary>
    ///     Class for reading from and writing to memory of a remote process.
    /// </summary>
    public class RemoteMemory : IDisposable
    {
        #region Static Fields

        /// <summary>
        ///     If our process is 64Bit or not.
        /// </summary>
        public static readonly bool Self64 = IntPtr.Size == 8;

        #endregion

        #region Fields

        /// <summary>
        ///     If our and the process we attached to is 64Bit.
        /// </summary>
        public readonly bool Both64;

        /// <summary>
        ///     If the process we attached to is 64Bit or not.
        /// </summary>
        public readonly bool Is64;

        /// <summary>
        ///     Determines whether or not the process is still valid and running.
        /// </summary>
        public bool IsValid
        {
            get
            {
                return !this.ProcessHandle.IsInvalid && !this.ProcessHandle.IsClosed && !this.NativeProcess.HasExited;
            }
        }

        /// <summary>
        ///     Native process
        /// </summary>
        public readonly Process NativeProcess;

        /// <summary>
        ///     Handle to the process
        /// </summary>
        public readonly Handle ProcessHandle;

        private byte[] _dumpedRegion;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="RemoteMemory" /> class.
        /// </summary>
        /// <param name="proc">
        ///     The process to open.
        /// </param>
        public RemoteMemory(Process proc)
        {
            if (!ProcessExists(proc))
            {
                throw new ArgumentException("Process not valid");
            }

            this.NativeProcess = proc;
            this.ProcessHandle = OpenProcess(ProcessAccessFlags.AllAccess, this.NativeProcess.Id);
            this.Is64 = Is64Bit(this.NativeProcess);
            this.Both64 = this.Is64 && Self64;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="RemoteMemory" /> class.
        /// </summary>
        /// <param name="procName">
        ///     Name of the process to open.
        /// </param>
        public RemoteMemory(string procName) : this(Process.GetProcessesByName(procName)[0])
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="RemoteMemory" /> class.
        /// </summary>
        /// <param name="procId">
        ///     Id of the process to open.
        /// </param>
        public RemoteMemory(int procId) : this(Process.GetProcessById(procId))
        {
        }

        /// <inheritdoc />
        ~RemoteMemory()
        {
            this.Dispose(true);
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     The MainModule of the attached process.
        /// </summary>
        public ProcessModule MainModule
        {
            get
            {
                return this.NativeProcess.MainModule;
            }
        }

        /// <summary>
        ///     All modules of the attached process.
        /// </summary>
        public ProcessModuleCollection Modules
        {
            get
            {
                return this.NativeProcess.Modules;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Gets a byte array and mask from a string aob pattern/signature.
        /// </summary>
        /// <param name="pattern">
        ///     The aob pattern.
        /// </param>
        /// <returns>
        ///     Tuple with byte array and mask.
        /// </returns>
        public static (byte[], string) GetBytesAndMaskFromPattern(string pattern)
        {
            var split = pattern.Split(' ');
            var bytes = new byte[split.Length];
            var mask = new char[split.Length];
            for (var i = 0; i < split.Length; i++)
            {
                if (split[i][0] == '?' || split[i][1] == '?')
                {
                    bytes[i] = 0;
                    mask[i] = '?';
                }
                else
                {
                    bytes[i] = Convert.ToByte(new string(new[] {split[i][0], split[i][1]}), 16);
                    mask[i] = 'x';
                }
            }

            return (bytes, new string(mask));
        }

        /// <summary>
        ///     Gets the byte array from a string aob pattern/signature.
        /// </summary>
        /// <param name="pattern">
        ///     Pattern to get bytes from.
        /// </param>
        /// <returns>
        ///     Bytes of the pattern.
        /// </returns>
        public static byte[] GetBytesFromPattern(string pattern)
        {
            var split = pattern.Split(' ');
            var rtn = new byte[split.Length];
            for (var i = 0; i < split.Length; i++)
            {
                if (split[i][0] == '?' || split[i][1] == '?')
                {
                    rtn[i] = 0;
                }
                else
                {
                    rtn[i] = Convert.ToByte(new string(new[] {split[i][0], split[i][1]}), 16);
                }
            }

            return rtn;
        }

        /// <summary>
        ///     Gets a mask from a string aob pattern/signature.
        /// </summary>
        /// <param name="pattern">
        ///     Pattern to get mask from.
        /// </param>
        /// <returns>
        ///     Mask of the pattern.
        /// </returns>
        public static string GetMaskFromPattern(string pattern)
        {
            var split = pattern.Split(' ');
            var rtn = new char[split.Length];
            for (var i = 0; i < split.Length; i++)
            {
                if (split[i][0] == '?' || split[i][1] == '?')
                {
                    rtn[i] = '?';
                }
                else
                {
                    rtn[i] = 'x';
                }
            }

            return new string(rtn);
        }

        /// <summary>
        ///     Determines whether the specified process is 64bit or not.
        /// </summary>
        /// <param name="proc">
        ///     The process to check.
        /// </param>
        /// <returns>
        ///     TRUE if 64bit, otherwise FALSE.
        /// </returns>
        public static bool Is64Bit(Process proc)
        {
            Kernel32.IsWow64Process(proc.Handle, out var iswow64);
            return !iswow64 && Environment.Is64BitOperatingSystem;
        }

        /// <summary>
        ///     Determines whether the specified process exists.
        /// </summary>
        /// <param name="process">
        ///     The process to check.
        /// </param>
        /// <returns>
        ///     TRUE if process exists, otherwise FALSE.
        /// </returns>
        public static bool ProcessExists(Process process)
        {
            if (process == null)
            {
                throw new ArgumentNullException(nameof(process));
            }

            try
            {
                Process.GetProcessById(process.Id);
            }
            catch (ArgumentException)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Opens an existing local process object.
        /// </summary>
        /// <param name="accessFlags">
        ///     The access to the process object. This access right is checked against the security descriptor for the process.
        ///     This parameter can be one or more of the process access rights. If the caller has enabled the SeDebugPrivilege
        ///     privilege, the requested access is granted regardless of the contents of the security descriptor.
        /// </param>
        /// <param name="procId">
        ///     The identifier of the local process to be opened. If the specified process is the System Process(0x00000000), the
        ///     function fails and the last error code is ERROR_INVALID_PARAMETER.If the specified process is the Idle process or
        ///     one of the CSRSS processes, this function fails and the last error code is ERROR_ACCESS_DENIED because their access
        ///     restrictions prevent user-level code from opening them. If you are using GetCurrentProcessId as an argument to this
        ///     function, consider using GetCurrentProcess instead of OpenProcess, for improved performance.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is an open handle to the specified process. If the function fails, the
        ///     return value is NULL.To get extended error information, call GetLastError.
        /// </returns>
        public static Handle OpenProcess(ProcessAccessFlags accessFlags, int procId)
        {
            var handle = Kernel32.OpenProcess(accessFlags, false, procId);

            if (!handle.IsInvalid && !handle.IsClosed)
            {
                return handle;
            }

            throw new Win32Exception($"Couldn't open process: {procId}");
        }

        /// <inheritdoc />
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Finds the address of the specified pattern + mask in the main module.
        /// </summary>
        /// <param name="btPattern">
        ///     Byte pattern to search for.
        /// </param>
        /// <param name="strMask">
        ///     Mask to check.
        /// </param>
        /// <param name="nOffset">
        ///     Offset to add to the address.
        /// </param>
        /// <returns>
        ///     Address where the pattern was found if successful, otherwise IntPtr.Zero
        /// </returns>
        public IntPtr FindPattern(byte[] btPattern, string strMask, int nOffset)
        {
            return this.FindPatternInModule(btPattern, strMask, nOffset, this.MainModule);
        }

        /// <summary>
        ///     Finds the address of the specified pattern in the main module.
        /// </summary>
        /// <param name="strPattern">
        ///     Pattern to search for.
        /// </param>
        /// <param name="nOffset">
        ///     Offset to add to the address.
        /// </param>
        /// <returns>
        ///     Address where the pattern was found if successful, otherwise IntPtr.Zero
        /// </returns>
        public IntPtr FindPattern(string strPattern, int nOffset)
        {
            return this.FindPatternInModule(strPattern, nOffset, this.MainModule);
        }

        /// <summary>
        ///     Finds the address of the specified pattern in the main module.
        /// </summary>
        /// <param name="dwPattern">
        ///     Pattern to search for.
        /// </param>
        /// <returns>
        ///     Address where the pattern was found if successful, otherwise IntPtr.Zero
        /// </returns>
        public IntPtr FindPattern(StringPattern dwPattern)
        {
            return this.FindPatternInModule(dwPattern, this.MainModule);
        }

        /// <summary>
        ///     Finds the address of the specified pattern + mask in the module.
        /// </summary>
        /// <param name="btPattern">
        ///     Byte pattern to search for.
        /// </param>
        /// <param name="strMask">
        ///     Mask to check.
        /// </param>
        /// <param name="nOffset">
        ///     Offset to add to the address.
        /// </param>
        /// <param name="procModule">
        ///     ProcessModule to search through.
        /// </param>
        /// <returns>
        ///     Address where the pattern was found if successful, otherwise IntPtr.Zero
        /// </returns>
        public IntPtr FindPatternInModule(byte[] btPattern, string strMask, int nOffset, ProcessModule procModule)
        {
            if (strMask.Length != btPattern.Length || btPattern.Length < 1)
            {
                throw new ArgumentException("length does not match");
            }

            try
            {
                var firstIndex = strMask.IndexOf('x');
                var first = btPattern[firstIndex];
                if (!this.DumpMemory(procModule.BaseAddress, procModule.ModuleMemorySize))
                {
                    return IntPtr.Zero;
                }

                for (var i = 0; i < this._dumpedRegion.Length - btPattern.Length; i++)
                {
                    if (this._dumpedRegion[i + firstIndex] != first)
                    {
                        continue;
                    }

                    if (this.CheckMask(i, btPattern, strMask))
                    {
                        return new IntPtr(procModule.BaseAddress.ToInt64()) + i + nOffset;
                    }
                }

                return IntPtr.Zero;
            }
            catch (Exception)
            {
                return IntPtr.Zero;
            }
            finally
            {
                this._dumpedRegion = null;
            }
        }

        /// <summary>
        ///     Finds the address of the specified pattern in the module.
        /// </summary>
        /// <param name="strPattern">
        ///     Pattern to search for.
        /// </param>
        /// <param name="nOffset">
        ///     Offset to add to the address.
        /// </param>
        /// <param name="procModule">
        ///     ProcessModule to search through.
        /// </param>
        /// <returns>
        ///     Address where the pattern was found if successful, otherwise IntPtr.Zero
        /// </returns>
        public IntPtr FindPatternInModule(string strPattern, int nOffset, ProcessModule procModule)
        {
            var (bytes, mask) = GetBytesAndMaskFromPattern(strPattern);
            return this.FindPatternInModule(bytes, mask, nOffset, procModule);
        }

        /// <summary>
        ///     Finds the address of the specified pattern in the module.
        /// </summary>
        /// <param name="dwPattern">
        ///     Pattern to search for.
        /// </param>
        /// <param name="procModule">
        ///     ProcessModule to search through.
        /// </param>
        /// <returns>
        ///     Address where the pattern was found if successful, otherwise IntPtr.Zero
        /// </returns>
        public IntPtr FindPatternInModule(StringPattern dwPattern, ProcessModule procModule)
        {
            var (bytes, mask) = GetBytesAndMaskFromPattern(dwPattern.Pattern);
            return this.FindPatternInModule(bytes, mask, dwPattern.Offset, procModule);
        }

        /// <summary>
        ///     Reads the value of a type in the remote process memory.
        /// </summary>
        /// <typeparam name="T">
        ///     Type of the value.
        /// </typeparam>
        /// <param name="address">
        ///     Address of the value.
        /// </param>
        /// <param name="relative">
        ///     Address is relative to the main module.
        /// </param>
        /// <returns>
        ///     The value.
        /// </returns>
        public T Read<T>(IntPtr address, bool relative = false)
        {
            int size;
            if (typeof(T) == typeof(IntPtr))
            {
                size = this.Both64 ? 8 : 4;
            }
            else
            {
                size = MarshalType<T>.Size;
            }

            return MarshalType<T>.ByteArrayToObject(this.ReadBytes(address, size, relative));
        }

        /// <summary>
        ///     Reads an array of a type in the remote process memory.
        /// </summary>
        /// <typeparam name="T">
        ///     Type of the values.
        /// </typeparam>
        /// <param name="address">
        ///     Address of the values.
        /// </param>
        /// <param name="count">
        ///     Array size.
        /// </param>
        /// <param name="relative">
        ///     Address is relative to the main module.
        /// </param>
        /// <returns>
        ///     Array filled with values.
        /// </returns>
        public T[] Read<T>(IntPtr address, int count, bool relative = false)
        {
            var type = typeof(T);
            var array = new T[count];

            int size;
            if (type == typeof(IntPtr))
            {
                size = this.Both64 ? 8 : 4;
            }
            else
            {
                size = MarshalType<T>.Size;
            }

            var bytes = this.ReadBytes(address, size * count, relative);

            if (type == typeof(byte))
            {
                Buffer.BlockCopy(bytes, 0, array, 0, count);
            }
            else
            {
                for (var i = 0; i < count; i++)
                {
                    array[i] = MarshalType<T>.ByteArrayToObject(bytes, size * i);
                }
            }

            return array;
        }

        /// <summary>
        ///     Reads a string with the specified encoding in the remote process memory.
        /// </summary>
        /// <param name="address">
        ///     Address of the values.
        /// </param>
        /// <param name="encoding">
        ///     Encoding to use.
        /// </param>
        /// <param name="maxLength">
        ///     Maximum length of the string(bytes to be read)
        /// </param>
        /// <param name="relative">
        ///     Address is relative to the main module.
        /// </param>
        /// <returns>
        ///     String at the address
        /// </returns>
        public string ReadString(IntPtr address, Encoding encoding, int maxLength = 512, bool relative = false)
        {
            var data = encoding.GetString(this.ReadBytes(address, maxLength, relative));
            var eosPos = data.IndexOf('\0');

            return eosPos == -1 ? data : data.Substring(0, eosPos);
        }

        /// <summary>
        ///     Reads a string with Encoding.UTF8 in the remote process memory.
        /// </summary>
        /// <param name="address">
        ///     Address of the values.
        /// </param>
        /// <param name="maxLength">
        ///     Maximum length of the string(bytes to be read)
        /// </param>
        /// <param name="relative">
        ///     Address is relative to the main module.
        /// </param>
        /// <returns>
        ///     String at the address
        /// </returns>
        public string ReadString(IntPtr address, int maxLength = 512, bool relative = false)
        {
            return this.ReadString(address, Encoding.UTF8, maxLength, relative);
        }

        /// <summary>
        ///     Converts the relative address to an absolute one.
        /// </summary>
        /// <param name="address">
        ///     Relative address to convert.
        /// </param>
        /// <returns>
        ///     An address absolute to the main module.
        /// </returns>
        public IntPtr ToAbsolute(IntPtr address)
        {
            if (address.ToInt64() > this.MainModule.ModuleMemorySize)
            {
                throw new ArgumentOutOfRangeException(nameof(address),
                    "Relative address greater than main module size.");
            }

            return new IntPtr(this.MainModule.BaseAddress.ToInt64() + address.ToInt64());
        }

        /// <summary>
        ///     Writes the value of a type in the remote process memory.
        /// </summary>
        /// <param name="address">
        ///     Address to write at.
        /// </param>
        /// <param name="value">
        ///     Value to write.
        /// </param>
        /// <param name="relative">
        ///     Address is relative to the main module.
        /// </param>
        /// <typeparam name="T">
        ///     Type of the value.
        /// </typeparam>
        public void Write<T>(IntPtr address, T value, bool relative = false)
        {
            this.WriteBytes(address, MarshalType<T>.ObjectToByteArray(value, this.Is64), relative);
        }

        public void Write<T>(IntPtr address, T[] values, bool relative = false)
        {
            var type = typeof(T);
            int size;
            if (type == typeof(IntPtr))
            {
                size = this.Is64 ? 8 : 4;
            }
            else
            {
                size = MarshalType<T>.Size;
            }

            var bytes = new byte[size * values.Length];

            for (var i = 0; i < values.Length; i++)
            {
                var offset = size * i;
                Buffer.BlockCopy(MarshalType<T>.ObjectToByteArray(values[i], this.Is64), 0, bytes, offset, size);
            }

            this.WriteBytes(address, bytes, relative);
        }

        /// <summary>
        ///     Writes a string with the specified encoding in the remote process memory.
        /// </summary>
        /// <param name="address">
        ///     Address to write at.
        /// </param>
        /// <param name="text">
        ///     String value to be written.
        /// </param>
        /// <param name="encoding">
        ///     Encoding to use.
        /// </param>
        /// <param name="relative">
        ///     Address is relative to the main module.
        /// </param>
        public void WriteString(IntPtr address, string text, Encoding encoding, bool relative = false)
        {
            this.WriteBytes(address, encoding.GetBytes(text + '\0'), relative);
        }

        /// <summary>
        ///     Writes a string with Encoding.UTF8 in the remote process memory.
        /// </summary>
        /// <param name="address">
        ///     Address to write at.
        /// </param>
        /// <param name="text">
        ///     String value to be written.
        /// </param>
        /// <param name="relative">
        ///     Address is relative to the main module.
        /// </param>
        public void WriteString(IntPtr address, string text, bool relative = false)
        {
            this.WriteString(address, text, Encoding.UTF8, relative);
        }

        #endregion

        #region Methods

        private static byte[] ReadBytes(Handle procHandle, IntPtr address, int size)
        {
            if (!procHandle.IsInvalid && !procHandle.IsClosed && address != IntPtr.Zero)
            {
                var buffer = new byte[size];
                if (Kernel32.ReadProcessMemory(procHandle, address, buffer, size, out var numBytesRead) &&
                    size == numBytesRead)
                {
                    return buffer;
                }
            }

            throw new Win32Exception($"Couldn't read {size} bytes from 0x{address.ToString("X")}.");
        }

        private static void WriteBytes(Handle procHandle, IntPtr address, byte[] bytes)
        {
            if (procHandle.IsInvalid || procHandle.IsClosed || address == IntPtr.Zero)
            {
                throw new ArgumentException("Handle invalid/closed or address is zero");
            }

            Kernel32.VirtualProtectEx(procHandle, address, bytes.Length, MemoryProtection.EXECUTE_READWRITE,
                out var oldProtect);

            var result = Kernel32.WriteProcessMemory(procHandle, address, bytes, bytes.Length, out var numBytesWritten);

            Kernel32.VirtualProtectEx(procHandle, address, bytes.Length, oldProtect, out oldProtect);

            if (!result || numBytesWritten != bytes.Length)
            {
                throw new Win32Exception($"Couldn't write {bytes.Length} bytes to 0x{address.ToString("X")}");
            }
        }

        private bool CheckMask(int index, byte[] btPattern, string strMask)
        {
            for (var i = 0; i < btPattern.Length; i++)
            {
                if (strMask[i] == '?')
                {
                    continue;
                }

                if (strMask[i] == 'x' && btPattern[i] != this._dumpedRegion[index + i])
                {
                    return false;
                }
            }

            return true;
        }

        private void Dispose(bool disposing)
        {
            this.ReleaseUnmanagedResources();
            if (disposing)
            {
                this.NativeProcess?.Dispose();
                this.ProcessHandle?.Dispose();
            }
        }

        private bool DumpMemory(IntPtr startAddress, int size)
        {
            try
            {
                if (this.NativeProcess == null || this.NativeProcess.HasExited || size == 0)
                {
                    return false;
                }

                this._dumpedRegion = new byte[size];

                this._dumpedRegion = this.ReadBytes(startAddress, size);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private byte[] ReadBytes(IntPtr address, int count, bool relative = false)
        {
            return ReadBytes(this.ProcessHandle, relative ? this.ToAbsolute(address) : address, count);
        }

        private void ReleaseUnmanagedResources()
        {
            this.ProcessHandle?.Close();
        }

        private void WriteBytes(IntPtr address, byte[] bytes, bool relative = false)
        {
            WriteBytes(this.ProcessHandle, relative ? this.ToAbsolute(address) : address, bytes);
        }

        #endregion
    }
}