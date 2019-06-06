using System;
using System.Linq;
using static System.String;
using static System.Environment;
using static System.Math;

namespace ProjectEuler.Problems.Helpers
{
    public static class Funcs
    {
        /// <summary>
        /// Sieve of Eratosthenes
        /// <see cref="http://www.wikizero.biz/index.php?q=aHR0cHM6Ly9lbi53aWtpcGVkaWEub3JnL3dpa2kvU2lldmVfb2ZfRXJhdG9zdGhlbmVz"/>
        /// </summary>
        public static long[] Sieve(long upperBound)
        {
            if (upperBound < 2) return new long[0];

            var isComposite = new bool[upperBound + 1];
            var primes = new long[upperBound / (long)Log10(upperBound)];

            isComposite[0] = isComposite[1] = true;

            for (var i = 2; i * i <= upperBound; i++)
            {
                if (isComposite[i]) continue;
                for (var j = i * i; j <= upperBound; j += i)
                    isComposite[j] = true;
            }

            var p = 0;
            for (var k = 0; k <= upperBound; k++)
            {
                if (isComposite[k]) continue;
                primes[p] = k;
                p++;
            }

            return primes.TakeWhile(i => i > 0).ToArray();
        }

        public static string ToText(this long[] values)
        {
            const int colSize  = 7;
            const int colCount = 16;

            var len = values?.Length ?? 0;
            if (len == 0) return "[]";
            var result = NewLine;
            var c = 0;
            for (int i = 0; i < len; i++)
            {
                if (c >= colCount)
                {
                    c = 0;
                    result += NewLine;
                }
                c++;
                result += Format($"{{0,{colSize}}}", values[i]);
            }
            return result;
        }

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
        public static int Gcd(int x, int y) => (int)Gcd(x, (long)y);

        /// <summary>
        /// Lowest common denominator
        /// </summary>
        public static long Lcd(long x, long y) => x / Gcd(x, y) * y;

        /// <summary>
        /// Lowest common denominator
        /// </summary>
        public static int Lcd(int x, int y) => x / Gcd(x, y) * y;

        public static bool IsPalindrome(this string s)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));

            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                    return false;
            }
            return true;
        }

        public static bool IsPalindrome(this int i) => i.ToString().IsPalindrome();
    }
}
