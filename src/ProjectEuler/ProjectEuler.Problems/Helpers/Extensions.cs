using System;

namespace ProjectEuler.Problems.Helpers
{
    public static class Extensions
    {
        public static bool IsPrime(this long num)
        {
            if (num < 0)
                throw new ArgumentOutOfRangeException(nameof(num));
            if (num < 2) return false;
            if (num == 2 || num == 3) return true;
            if (num % 2 == 0 || num % 3 == 0) return false;
            var max = (long)Math.Sqrt(num);
            for (long i = 5; i <= max; i += 2)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }

        public static bool IsPrime(this int num) => IsPrime((long)num);
    }
}
