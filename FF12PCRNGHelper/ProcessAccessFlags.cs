using System;

namespace FF12PCRNGHelper
{
    /// <summary>
    ///     The Microsoft Windows security model enables you to control access to process objects. For more information about
    ///     security, see Access-Control Model.
    ///     When a user logs in, the system collects a set of data that uniquely identifies the user during the authentication
    ///     process, and stores it in an access token. This access token describes the security context of all processes
    ///     associated with the user. The security context of a process is the set of credentials given to the process or the
    ///     user account that created the process.
    ///     You can use a token to specify the current security context for a process using the CreateProcessWithTokenW
    ///     function. You can specify a security descriptor for a process when you call the CreateProcess, CreateProcessAsUser,
    ///     or CreateProcessWithLogonW function. If you specify NULL, the process gets a default security descriptor. The ACLs
    ///     in the default security descriptor for a process come from the primary or impersonation token of the creator.
    ///     To retrieve a process's security descriptor, call the GetSecurityInfo function. To change a process's security
    ///     descriptor, call the SetSecurityInfo function.
    ///     The valid access rights for process objects include the standard access rights and some process-specific access
    ///     rights. The following table lists the standard access rights used by all objects.
    /// </summary>
    [Flags]
    public enum ProcessAccessFlags
    {
        /// <summary>
        ///     All possible access rights for a process object. Windows Server 2003 and Windows XP:  The size of the
        ///     PROCESS_ALL_ACCESS flag increased on Windows Server 2008 and Windows Vista. If an application compiled for Windows
        ///     Server 2008 and Windows Vista is run on Windows Server 2003 or Windows XP, the PROCESS_ALL_ACCESS flag is too large
        ///     and the function specifying this flag fails with ERROR_ACCESS_DENIED. To avoid this problem, specify the minimum
        ///     set of access rights required for the operation. If PROCESS_ALL_ACCESS must be used, set _WIN32_WINNT to the
        ///     minimum operating system targeted by your application (for example, #define _WIN32_WINNT _WIN32_WINNT_WINXP). For
        ///     more information, see Using the Windows Headers.
        /// </summary>
        AllAccess = 0x1F0FFF,

        /// <summary>
        ///     Required to create a process.
        /// </summary>
        CreateProcess = 0x80,

        /// <summary>
        ///     Required to create a thread.
        /// </summary>
        CreateThread = 0x2,

        /// <summary>
        ///     Required to duplicate a handle using DuplicateHandle.
        /// </summary>
        DupHandle = 0x40,

        /// <summary>
        ///     Required to retrieve certain information about a process, such as its token, exit code, and priority class (see
        ///     OpenProcessToken).
        /// </summary>
        QueryInformation = 0x400,

        /// <summary>
        ///     Required to retrieve certain information about a process (see GetExitCodeProcess, GetPriorityClass, IsProcessInJob,
        ///     QueryFullProcessImageName). A handle that has the PROCESS_QUERY_INFORMATION access right is automatically granted
        ///     PROCESS_QUERY_LIMITED_INFORMATION.
        ///     Windows Server 2003 and Windows XP:  This access right is not supported.
        /// </summary>
        QueryLimitedInformation = 0x1000,

        /// <summary>
        ///     Required to set certain information about a process, such as its priority class (see SetPriorityClass).
        /// </summary>
        SetInformation = 0x200,

        /// <summary>
        ///     Required to set memory limits using SetProcessWorkingSetSize.
        /// </summary>
        SetQuota = 0x100,

        /// <summary>
        ///     Required to suspend or resume a process.
        /// </summary>
        SuspendResume = 0x800,

        /// <summary>
        ///     Required to terminate a process using TerminateProcess.
        /// </summary>
        Terminate = 0x1,

        /// <summary>
        ///     Required to perform an operation on the address space of a process (see VirtualProtectEx and WriteProcessMemory).
        /// </summary>
        VmOperation = 0x8,

        /// <summary>
        ///     Required to read memory in a process using ReadProcessMemory.
        /// </summary>
        VmRead = 0x10,

        /// <summary>
        ///     Required to write to memory in a process using WriteProcessMemory.
        /// </summary>
        VmWrite = 0x20,

        /// <summary>
        ///     Required to wait for the process to terminate using the wait functions.
        /// </summary>
        Synchronize = 0x100000
    }
}