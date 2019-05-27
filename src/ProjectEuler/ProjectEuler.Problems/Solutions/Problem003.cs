using System;
using ProjectEuler.Problems.Helpers;

namespace ProjectEuler.Problems.Solutions
{
    /// <summary>
    /// Largest prime factor
    /// <see cref="https://projecteuler.net/problem=3"/>
    /// </summary>
    public class Problem003 : IProblem
    {
        public const long Number = 600_851_475_143;

        public int Id => 3;
        public string Title => "Largest prime factor";

        public string Description =>
            "The prime factors of 13195 are 5, 7, 13 and 29. \r\n" +
            $"What is the largest prime factor of the number {Number} ?";

        public string GetSolution()
        {
            for (var i = (long)Math.Sqrt(Number); i > 1; i--)
            {
                if (Number % i == 0 && i.IsPrime())
                    return i.ToString();
            }
            throw new Exception("Solution not found");
        }
    }
}
