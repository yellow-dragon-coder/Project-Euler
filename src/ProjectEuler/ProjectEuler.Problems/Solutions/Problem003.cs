using System;

namespace ProjectEuler.Problems.Solutions
{
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
            var max = (long)Math.Sqrt(Number);
            for (var i = max; i > 1; i--)
            {
                if (Number % i == 0 && IsPrime(i))
                    return i.ToString();
            }
            throw new Exception("Solution not found");
        }

        private bool IsPrime(long n)
        {
            if (n < 2) return false;
            var i = 2;
            while (i * i <= n)
            {
                if (n % i == 0) return false;
                i++;
            }
            return true;
        }
    }
}
