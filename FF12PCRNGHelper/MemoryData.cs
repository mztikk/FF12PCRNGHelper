using System;

namespace FF12PCRNGHelper
{
    internal static class MemoryData
    {
        // Is this actually static? Would be way faster since we don't have to rebase every rpm.
        // If its not, maybe look into rebasing in AttachProc()
        internal static IntPtr BaseAddress = new IntPtr(0x120000);

        internal static IntPtr MtiAddress = BaseAddress + 0x2D721F0;

        internal static int MtSize = 624;

        internal static IntPtr MtAddress = MtiAddress - 4 * MtSize;
    }
}
