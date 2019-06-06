using System.Linq;
using static ProjectEuler.Problems.Helpers.Funcs;

namespace ProjectEuler.Problems.Solutions
{
    /// <summary>
    /// Summation of primes
    /// <see cref="https://projecteuler.net/problem=10"/>
    /// </summary>
    public class Problem010 : IProblem
    {
        public int Id => 10;
        public string Title => "Summation of primes";

        public string Description =>
            "The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17. \r\n" +
            "Find the sum of all the primes below two million.";

        public string GetSolution() =>
            Sieve(2000000 - 1)
                .Sum()
                .ToString();
    }
}
