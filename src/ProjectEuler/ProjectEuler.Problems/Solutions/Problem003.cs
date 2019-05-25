namespace ProjectEuler.Problems.Solutions
{
    public class Problem003 : IProblem
    {
        public const long Number = 600851475143;

        public int Id => 3;
        public string Title => "Largest prime factor";

        public string Description =>
            "The prime factors of 13195 are 5, 7, 13 and 29. \r\n" +
            $"What is the largest prime factor of the number {Number} ?";

        public string GetSolution()
        {
            var num = Number;
            long factor = 2;
            while (true)
            {
                if (num % factor == 0)
                {
                    num /= factor;
                }
                else if (!NextPrime(num, ref factor))
                {
                    if (num > factor && IsPrime(num))
                        factor = num;
                    break;
                }
            }
            return factor.ToString();
        }

        private bool NextPrime(long num, ref long prime)
        {
            for (var i = prime; ++i < num;)
            {
                if (IsPrime(i))
                {
                    prime = i;
                    return true;
                }
            }
            return false;
        }

        private bool IsPrime(long n)
        {
            for (int i = 2; i < n - 1; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
    }
}
