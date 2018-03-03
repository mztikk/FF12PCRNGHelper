using System.Collections.Generic;

namespace FF12PCRNGHelper
{
    public static class Strings
    {
        private static readonly HashSet<char> WhitespaceChars = new HashSet<char>
        {
            '\u0020',
            '\u00A0',
            '\u1680',
            '\u2000',
            '\u2001',
            '\u2002',
            '\u2003',
            '\u2004',
            '\u2005',
            '\u2006',
            '\u2007',
            '\u2008',
            '\u2009',
            '\u200A',
            '\u202F',
            '\u205F',
            '\u3000',
            '\u2028',
            '\u2029',
            '\u0009',
            '\u000A',
            '\u000B',
            '\u000C',
            '\u000D',
            '\u0085'
        };

        public static string RemoveWhitespace(string input)
        {
            var len = input.Length;
            var src = input.ToCharArray();
            var dstIdx = 0;
            for (var i = 0; i < len; i++)
            {
                var ch = src[i];
                if (WhitespaceChars.Contains(ch))
                {
                    continue;
                }

                src[dstIdx++] = ch;
            }

            return new string(src, 0, dstIdx);
        }
    }
}