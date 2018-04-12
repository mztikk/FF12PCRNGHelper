using System;
using System.ComponentModel;
using System.Diagnostics;

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

        #region FF12TZA RNG

        // Since we're only reading 625 * 4 bytes for mt and mti and nothing else, but that a lot, might aswell optimize for it instead of using a generic version
        private const int NumBytesToRead = 625 * 4;

        // Caching arrays to avoid reconstruction
        private readonly uint[] _mt = new uint[624];

        private readonly byte[] _rngBuffer = new byte[NumBytesToRead];

        public (uint[], int) GetMtAndMti(IntPtr address)
        {
            if (!this.ProcessHandle.IsInvalid && !this.ProcessHandle.IsClosed && address != IntPtr.Zero)
            {
                if (Kernel32.ReadProcessMemory(this.ProcessHandle, address, this._rngBuffer, NumBytesToRead,
                        out var numBytesRead) && NumBytesToRead == numBytesRead)
                {
                    Buffer.BlockCopy(this._rngBuffer, 0, this._mt, 0, NumBytesToRead - 4);

                    return (this._mt, BitConverter.ToInt32(this._rngBuffer, NumBytesToRead - 4));
                }
            }

            throw new Win32Exception($"Couldn't read mt and mti at 0x{address.ToString("X")}");
        }

        #endregion

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

        private void Dispose(bool disposing)
        {
            this.ReleaseUnmanagedResources();
            if (disposing)
            {
                this.NativeProcess?.Dispose();
                this.ProcessHandle?.Dispose();
            }
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