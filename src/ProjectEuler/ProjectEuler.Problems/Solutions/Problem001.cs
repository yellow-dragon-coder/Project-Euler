using System.Linq;
using ProjectEuler.Problems.Helpers;

namespace ProjectEuler.Problems.Solutions
{
    /// <summary>
    /// Multiples of 3 and 5
    /// <see cref="https://projecteuler.net/problem=1"/>
    /// </summary>
    public class Problem001 : IProblem
    {
        public int Id => 1;
        public string Title => "Multiples of 3 and 5";

        public string Description =>
            "If we list all the natural numbers below 10 that are multiples of 3 or 5, \r\n" +
            "we get 3, 5, 6 and 9. The sum of these multiples is 23. \r\n" +
            "Find the sum of all the multiples of 3 or 5 below 1000.";

        public string GetSolution()
            => (1..999)
                .ToArray()
                .Where(i => i % 3 == 0 || i % 5 == 0)
                .Sum()
                .ToString();
    }
}
