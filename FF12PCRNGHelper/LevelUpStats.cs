namespace FF12PCRNGHelper
{
    public static class LevelUpStats
    {
        public static bool IsPerfectHpMp(uint level, uint value1, uint value2)
        {
            if (HpRand(level, value1) >= (HpMinBonus(level) - 1) / 5 && MpRand(level, value2) >= MpMinBonus(level) - 1)
            {
                return true;
            }

            return false;
        }

        public static int PerfectHpMpCount(uint level, ref uint[] values, int index = 0)
        {
            var amount = 0;
            uint j = 0;
            for (var i = index; i < values.Length - 1; i += 2)
            {
                if (level + j >= 100)
                {
                    return amount;
                }

                if (IsPerfectHpMp(level + j, values[i], values[i + 1]))
                {
                    amount++;
                }
                else
                {
                    break;
                }

                j++;
            }

            return amount;
        }

        public static int PerfectHpMpCount(uint level, ref uint[][] values, int index = 0)
        {
            var amount = 0;

            uint j = 0;
            for (var i = index; i < values.Length - 1; i += 2)
            {
                if (level + j >= 100)
                {
                    return amount;
                }

                if (IsPerfectHpMp(level + j, values[i][0], values[i + 1][0]))
                {
                    amount++;
                }
                else
                {
                    break;
                }

                j++;
            }

            return amount;
        }

        public static uint MpRand(uint level, uint value)
        {
            return value % MpMod(level) / 100;
        }

        public static uint MpMod(uint level)
        {
            return MpMinBonus(level) * 100;
        }

        public static uint MpMinBonus(uint level)
        {
            if (level < 11)
            {
                return 3;
            }

            if (level < 30)
            {
                return 4;
            }

            if (level < 44)
            {
                return 5;
            }

            if (level < 61)
            {
                return 4;
            }

            if (level < 81)
            {
                return 3;
            }

            if (level < 91)
            {
                return 2;
            }

            if (level < 100)
            {
                return 1;
            }

            return 0;
        }

        public static uint HpRand(uint level, uint value)
        {
            return value % HpMod(level) / 100;
        }

        public static uint HpMod(uint level)
        {
            if (level == 12 || level == 90 || level == 95)
            {
                return 20 * HpMinBonus(level) - 1;
            }

            return 20 * HpMinBonus(level);
        }

        public static uint HpMinBonus(uint level)
        {
            if (level < 26)
            {
                return level + 9;
            }

            if (level < 35)
            {
                return 59 - level;
            }

            if (level < 50)
            {
                return 2 * level - 43;
            }

            if (level < 68)
            {
                return 153 - 2 * level;
            }

            if (level < 100)
            {
                return level - 48;
            }

            return 0;
        }
    }
}