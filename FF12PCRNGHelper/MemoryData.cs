using System;

namespace FF12PCRNGHelper
{
    internal static class MemoryData
    {
        internal static IntPtr MtiAddress = new IntPtr(0x2D8D030);

        internal static int MtSize = 624;

        internal static IntPtr MtAddress = MtiAddress - 4 * MtSize;
    }
}