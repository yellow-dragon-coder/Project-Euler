using System;

#pragma warning disable RCS1018 // Add default access modifier.

namespace ProjectEuler.Problems.Helpers
{
    public static class Funcs
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

        /// <summary>
        /// Greatest common divisor
        /// </summary>
        public static long Gcd(long x, long y)
        {
            if (x < 0 || y < 0)
                throw new ArgumentOutOfRangeException();
            while (y != 0)
                (x, y) = (y, x % y);
            return x;
        }

        /// <summary>
        /// Greatest common divisor
        /// </summary>
        public static int Gcd(int x, int y) =>
            (int)Gcd((long)x, (long)y);

        /// <summary>
        /// Lowest common denominator
        /// </summary>
        public static long Lcd(long x, long y) => x / Gcd(x, y) * y;

        /// <summary>
        /// Lowest common denominator
        /// </summary>
        public static int Lcd(int x, int y) => x / Gcd(x, y) * y;
    }
}

#pragma warning restore RCS1018 // Add default access modifier.
