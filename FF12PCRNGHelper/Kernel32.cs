using System;
using System.Runtime.InteropServices;

namespace FF12PCRNGHelper
{
    /// <summary>
    ///     Native Methods from the Kernel32 dll.
    /// </summary>
    public static class Kernel32
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Closes an open object handle.
        /// </summary>
        /// <param name="hObject">
        ///     A valid handle to an open object.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get
        ///     extended error information, call GetLastError. If the application is running under a debugger, the function will
        ///     throw an exception if it receives either a handle value that is not valid or a pseudo-handle value. This can happen
        ///     if you close a handle twice, or if you call CloseHandle on a handle returned by the FindFirstFile function instead
        ///     of calling the FindClose function.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle([In] IntPtr hObject);

        /// <summary>
        ///     Determines whether the specified process is running under WOW64.
        /// </summary>
        /// <param name="hProcess">
        ///     A handle to the process. The handle must have the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION
        ///     access right. For more information, see Process Security and Access Rights. Windows Server 2003 and Windows XP:
        ///     The handle must have the PROCESS_QUERY_INFORMATION access right.
        /// </param>
        /// <param name="wow64Process">
        ///     A pointer to a value that is set to TRUE if the process is running under WOW64. If the process is running under
        ///     32-bit Windows, the value is set to FALSE. If the process is a 64-bit application running under 64-bit Windows, the
        ///     value is also set to FALSE.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is a nonzero value. If the function fails, the return value is zero.To
        ///     get extended error information, call GetLastError.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWow64Process([In] IntPtr hProcess, [Out] out bool wow64Process);

        /// <summary>
        ///     Opens an existing local process object.
        /// </summary>
        /// <param name="dwDesiredAccess">
        ///     The access to the process object. This access right is checked against the security descriptor for the process.
        ///     This parameter can be one or more of the process access rights. If the caller has enabled the SeDebugPrivilege
        ///     privilege, the requested access is granted regardless of the contents of the security descriptor.
        /// </param>
        /// <param name="bInheritHandle">
        ///     If this value is TRUE, processes created by this process will inherit the handle. Otherwise, the processes do not
        ///     inherit this handle.
        /// </param>
        /// <param name="dwProcessId">
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
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Handle OpenProcess([In] ProcessAccessFlags dwDesiredAccess,
            [MarshalAs(UnmanagedType.Bool)] [In] bool bInheritHandle, [In] int dwProcessId);

        /// <summary>
        ///     Reads data from an area of memory in a specified process. The entire area to be read must be accessible or the
        ///     operation fails.
        /// </summary>
        /// <param name="hProcess">
        ///     A handle to the process with memory that is being read. The handle must have PROCESS_VM_READ access to the process.
        /// </param>
        /// <param name="lpBaseAddress">
        ///     A pointer to the base address in the specified process from which to read. Before any data transfer occurs, the
        ///     system verifies that all data in the base address and memory of the specified size is accessible for read access,
        ///     and if it is not accessible the function fails.
        /// </param>
        /// <param name="lpBuffer">
        ///     A pointer to a buffer that receives the contents from the address space of the specified process.
        /// </param>
        /// <param name="nSize">
        ///     The number of bytes to be read from the specified process.
        /// </param>
        /// <param name="lpNumberOfBytesRead">
        ///     A pointer to a variable that receives the number of bytes transferred into the specified buffer. If
        ///     lpNumberOfBytesRead is NULL, the parameter is ignored.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero. If the function fails, the return value is 0 (zero). To
        ///     get extended error information, call GetLastError. The function fails if the requested read operation crosses into
        ///     an area of the process that is inaccessible.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadProcessMemory([In] Handle hProcess, [In] IntPtr lpBaseAddress,
            [Out] byte[] lpBuffer, [In] int nSize, [Out] out int lpNumberOfBytesRead);

        /// <summary>
        ///     Changes the protection on a region of committed pages in the virtual address space of a specified process.
        /// </summary>
        /// <param name="hProcess">
        ///     A handle to the process whose memory protection is to be changed. The handle must have the PROCESS_VM_OPERATION
        ///     access right.
        /// </param>
        /// <param name="lpAddress">
        ///     A pointer to the base address of the region of pages whose access protection attributes are to be changed. All
        ///     pages in the specified region must be within the same reserved region allocated when calling the VirtualAlloc or
        ///     VirtualAllocEx function using MEM_RESERVE. The pages cannot span adjacent reserved regions that were allocated by
        ///     separate calls to VirtualAlloc or VirtualAllocEx using MEM_RESERVE.
        /// </param>
        /// <param name="dwSize">
        ///     The size of the region whose access protection attributes are changed, in bytes. The region of affected pages
        ///     includes all pages containing one or more bytes in the range from the lpAddress parameter to (lpAddress+dwSize).
        ///     This means that a 2-byte range straddling a page boundary causes the protection attributes of both pages to be
        ///     changed.
        /// </param>
        /// <param name="flNewProtect">
        ///     The memory protection option. This parameter can be one of the memory protection constants. For mapped views, this
        ///     value must be compatible with the access protection specified when the view was mapped(see MapViewOfFile,
        ///     MapViewOfFileEx, and MapViewOfFileExNuma).
        /// </param>
        /// <param name="lpflOldProtect">
        ///     A pointer to a variable that receives the previous access protection of the first page in the specified region of
        ///     pages. If this parameter is NULL or does not point to a valid variable, the function fails.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get
        ///     extended error information, call GetLastError.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool VirtualProtectEx([In] Handle hProcess, [In] IntPtr lpAddress, [In] int dwSize,
            [In] MemoryProtection flNewProtect, [Out] out MemoryProtection lpflOldProtect);

        /// <summary>
        ///     Writes data to an area of memory in a specified process. The entire area to be written to must be accessible or the
        ///     operation fails.
        /// </summary>
        /// <param name="hProcess">
        ///     A handle to the process memory to be modified. The handle must have PROCESS_VM_WRITE and PROCESS_VM_OPERATION
        ///     access to the process.
        /// </param>
        /// <param name="lpBaseAddress">
        ///     A pointer to the base address in the specified process to which data is written. Before data transfer occurs, the
        ///     system verifies that all data in the base address and memory of the specified size is accessible for write access,
        ///     and if it is not accessible, the function fails.
        /// </param>
        /// <param name="lpBuffer">
        ///     A pointer to the buffer that contains data to be written in the address space of the specified process.
        /// </param>
        /// <param name="nSize">
        ///     The number of bytes to be written to the specified process.
        /// </param>
        /// <param name="lpNumberOfBytesWritten">
        ///     A pointer to a variable that receives the number of bytes transferred into the specified process. This parameter is
        ///     optional. If lpNumberOfBytesWritten is NULL, the parameter is ignored.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero. If the function fails, the return value is 0 (zero). To get
        ///     extended error information, call GetLastError.The function fails if the requested write operation crosses into an
        ///     area of the process that is inaccessible.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WriteProcessMemory([In] Handle hProcess, [In] IntPtr lpBaseAddress,
            [In] byte[] lpBuffer, [In] int nSize, [Out] out int lpNumberOfBytesWritten);

        #endregion
    }
}