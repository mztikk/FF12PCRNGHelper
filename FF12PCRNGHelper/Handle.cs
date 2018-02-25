using System;
using Microsoft.Win32.SafeHandles;

namespace FF12PCRNGHelper
{
    public class Handle : SafeHandleZeroOrMinusOneIsInvalid
    {
        #region Methods

        protected override bool ReleaseHandle()
        {
            return this.handle != IntPtr.Zero && Kernel32.CloseHandle(this.handle);
        }

        #endregion

        #region Constructors and Destructors

        public Handle() : base(true)
        {
        }

        public Handle(IntPtr handle) : base(true)
        {
            this.SetHandle(handle);
        }

        #endregion
    }
}