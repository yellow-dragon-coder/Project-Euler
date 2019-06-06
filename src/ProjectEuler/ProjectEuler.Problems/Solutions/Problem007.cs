using ProjectEuler.Problems.Helpers;
using static ProjectEuler.Problems.Helpers.Funcs;

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

        public const int UpperBound = 10001;

        public string Description =>
            "By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, " +
            "we can see that the 6th prime is 13. \r\n" +
            "What is the 10 001st prime number?";

        public string GetSolution() => Sieve(UpperBound).ToText();
    }
}
