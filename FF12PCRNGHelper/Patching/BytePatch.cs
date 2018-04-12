using System;

namespace FF12PCRNGHelper.Patching
{
    public abstract class BytePatch
    {
        protected abstract byte[] OriginalBytes { get; set; }

        protected abstract byte[] BytesToPatch { get; set; }

        protected abstract IntPtr Address { get; set; }

        public virtual bool Apply()
        {
            if (Form1.RemoteMem != null)
            {
                try
                {
                    Form1.RemoteMem.Write(this.Address, this.BytesToPatch);
                    return true;
                }
                catch
                {
                }
            }

            return false;
        }

        public virtual bool Remove()
        {
            if (Form1.RemoteMem != null)
            {
                try
                {
                    Form1.RemoteMem.Write(this.Address, this.OriginalBytes);
                    return true;
                }
                catch
                {
                }
            }

            return false;
        }
    }
}