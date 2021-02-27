using System;

namespace FF12PCRNGHelper.Patching
{
    public abstract class BytePatch
    {
        // ReSharper disable once InconsistentNaming
        public const byte NOP = 0x90;

        protected abstract byte[] OriginalBytes { get; set; }

        protected abstract byte[] BytesToPatch { get; set; }

        protected abstract IntPtr Address { get; set; }

        public virtual bool Apply()
        {
            if (Form1.ZodiacMemory != null)
            {
                try
                {
                    Form1.ZodiacMemory.Write(this.Address, this.BytesToPatch);
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
            if (Form1.ZodiacMemory != null)
            {
                try
                {
                    Form1.ZodiacMemory.Write(this.Address, this.OriginalBytes);
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