using System.Linq;
using ProjectEuler.Problems.Helpers;
using static System.Math;

namespace ProjectEuler.Problems.Solutions
{
    /// <summary>
    /// 10001st prime
    /// <see cref="https://projecteuler.net/problem=7"/>
    /// </summary>
    public class Problem007 : IProblem
    {
        public int Id => 7;
        public string Title => "10001st prime";

        private const int UpperBound = 10001;

        public string Description =>
            "By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, " +
            "we can see that the 6th prime is 13. \r\n" +
            "What is the 10 001st prime number?";

        public string GetSolution() => Sieve(UpperBound).ToText();

        /// <summary>
        /// Sieve of Eratosthenes
        /// <see cref="http://www.wikizero.biz/index.php?q=aHR0cHM6Ly9lbi53aWtpcGVkaWEub3JnL3dpa2kvU2lldmVfb2ZfRXJhdG9zdGhlbmVz"/>
        /// </summary>
        private static int[] Sieve(int upperBound)
        {
            if (upperBound < 2) return new int[0];

            var isComposite = new bool[upperBound + 1];
            var primes = new int[upperBound / (int)Log10(upperBound)];

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

            return primes.Where(i => i > 0).ToArray();
        }
    }
}
