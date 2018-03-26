using System;
using System.Runtime.InteropServices;

namespace FF12PCRNGHelper
{
    public static unsafe class Compare
    {
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int memcmp(void* b1, void* b2, long count);

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int memcmp(IntPtr b1, IntPtr b2, long count);

        public static bool Equal(uint[] a, uint[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            fixed (void* pa = a)
            {
                fixed (void* pb = b)
                {
                    return memcmp(pa, pb, a.Length * 4) == 0;
                }
            }
        }

        public static bool PinnedEqual(uint[] a, uint[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            var pa = Marshal.UnsafeAddrOfPinnedArrayElement(a, 0);
            var pb = Marshal.UnsafeAddrOfPinnedArrayElement(b, 0);
            return memcmp(pa, pb, a.Length * 4) == 0;
        }
    }
}