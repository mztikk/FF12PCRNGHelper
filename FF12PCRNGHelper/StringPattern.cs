namespace FF12PCRNGHelper
{
    public class StringPattern
    {
        public readonly int Offset;

        public readonly string Pattern;

        public StringPattern(string pattern, int offset)
        {
            this.Pattern = pattern;
            this.Offset = offset;
        }

        public StringPattern(string pattern) : this(pattern, 0)
        {
        }
    }
}