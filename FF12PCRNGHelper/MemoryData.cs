using System;
using RFReborn.AoB;

namespace FF12PCRNGHelper
{
    internal static class MemoryData
    {
        internal static readonly Signature MtiSig = new Signature("8B 15 ?? ?? ?? ?? 48 63 ?? 48 8D ?? ?? ?? ?? ?? FF C2 89 15 ?? ?? ?? ?? 8B 0C 81 8B C1 C1 E8 0B 33 C8 8B C1 25 ?? ?? ?? ?? C1 E0 07 33 C8 8B C1 25 ?? ?? ?? ?? C1 E0 0F 33 C8 8B C1 C1 E8 12 33 C1 48 83 C4 28", 2);

        internal const int MtSize = 624;

        internal static IntPtr BaseAddress;

        internal static IntPtr MtiAddress;
        internal static IntPtr MtAddress;

        internal static void LoadMtiAndMt(IntPtr mtiAddress)
        {
            MtiAddress = mtiAddress;
            MtAddress = MtiAddress - (4 * MtSize);
        }
    }
}
