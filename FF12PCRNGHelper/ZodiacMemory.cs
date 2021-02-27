using System;
using RFDown.Windows.Memory;
using RFDown.Windows.Memory.Exceptions;
using RFDown.Windows.Native;

namespace FF12PCRNGHelper
{
    public class ZodiacMemory : RemoteMemory
    {
        // Since we're only reading 625 * 4 bytes for mt and mti and nothing else, but that a lot, might aswell optimize for it instead of using a generic version
        private const int NumBytesToRead = 625 * 4;

        // Caching arrays to avoid reconstruction
        private readonly uint[] _mt = new uint[624];

        private readonly byte[] _rngBuffer = new byte[NumBytesToRead];

        public ZodiacMemory(System.Diagnostics.Process proc) : base(proc)
        {
        }

        public ZodiacMemory(int processID) : base(processID)
        {
        }

        public ZodiacMemory(string processName, int index = 0) : base(processName, index)
        {
        }

        public ZodiacMemory(string processName, Func<System.Diagnostics.Process, bool> processSelector) : base(processName, processSelector)
        {
        }

        public (uint[], int) GetMtAndMti(IntPtr address)
        {
            if (!ProcessHandle.IsInvalid && !ProcessHandle.IsClosed && address != IntPtr.Zero)
            {
                if (Kernel32.ReadProcessMemory(ProcessHandle, address, _rngBuffer, NumBytesToRead, out int numBytesRead)
                    && NumBytesToRead == numBytesRead)
                {
                    Buffer.BlockCopy(_rngBuffer, 0, _mt, 0, NumBytesToRead - 4);

                    return (_mt, BitConverter.ToInt32(_rngBuffer, NumBytesToRead - 4));
                }
            }

            throw new ReadMemoryException($"Couldn't read mt and mti at 0x{address.ToString("X")}");
        }
    }
}
