using System;

namespace FF12PCRNGHelper.Patching
{
    public class AutoPause : BytePatch
    {
        // old way
        //protected override byte[] OriginalBytes { get; set; } = {0xE8, 0xD5, 0xA6, 0x00, 0x00};

        //protected override byte[] BytesToPatch { get; set; } = {NOP, NOP, NOP, NOP, NOP};

        //// This is only the address of the function call to the pause window, i'm noping this instead of the lost focus handler to still get the clip/show cursor calls.
        //// If there are problems i should probably patch the whole lost/got focus, but then i have to inject assembly instructions to call user32.showcursor/clipcursor
        //protected override IntPtr Address { get; set; } = MemoryData.BaseAddress + 0x677C66;

        protected override byte[] OriginalBytes { get; set; } = { 0x00 };
        protected override byte[] BytesToPatch { get; set; } = { 0x01 };

        protected override IntPtr Address { get; set; } = MemoryData.BaseAddress + 0xB290126;
    }
}
