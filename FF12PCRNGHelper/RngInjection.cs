namespace FF12PCRNGHelper
{
    internal static class RngInjection
    {
        internal static void WriteValue(int mti, uint value, int count)
        {
            WriteMt(mti, RngData.GetMtForValue(value), count);
        }

        internal static void WritePercentage(int mti, uint percentage, int count = 1)
        {
            WriteMt(mti, RngData.GetMtForPercentage(percentage), count);
        }

        internal static void WriteMti(int mti)
        {
            if (mti > 624 || mti < 0 || Form1.RemoteMem == null)
            {
                return;
            }

            try
            {
                Form1.RemoteMem.Write(MemoryData.MtiAddress, mti);
            }
            catch
            {
            }
        }

        internal static void WriteMt(int mti, uint mt, int count = 1)
        {
            if (Form1.RemoteMem == null)
            {
                return;
            }

            try
            {
                if (count > 1)
                {
                    var array = new uint[count];
                    for (var i = 0; i < count; i++)
                    {
                        array[i] = mt;
                    }

                    Form1.RemoteMem.Write(MemoryData.MtAddress + 4 * mti, array);
                }
                else
                {
                    Form1.RemoteMem.Write(MemoryData.MtAddress + 4 * mti, mt);
                }
            }
            catch
            {
            }
        }
    }
}