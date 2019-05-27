namespace ProjectEuler.Problems.Solutions
{
    /// <summary>
    /// Sum square difference
    /// <see cref="https://projecteuler.net/problem=6"/>
    /// </summary>
    public class Problem006 : IProblem
    {
        public int Id => 6;
        public string Title => "Sum square difference";

        public string Description =>
            "The sum of the squares of the first ten natural numbers is, \r\n" +
            "12 + 22 + ... + 102 = 385 \r\n" +
            "The square of the sum of the first ten natural numbers is, \r\n" +
            "(1 + 2 + ... + 10)2 = 552 = 3025 \r\n" +
            "Hence the difference between the sum of the squares of the first ten natural numbers \r\n" +
            "and the square of the sum is 3025 − 385 = 2640. \r\n" +
            "Find the difference between the sum of the squares of the first \r\n" +
            "one hundred natural numbers and the square of the sum.";

        public string GetSolution()
        {
            var sum = 0;
            var sumOfSqueres = 0;
            for (int i = 1; i <= 100; i++)
            {
                sum += i;
                sumOfSqueres += i * i;
            }
            return ((sum * sum) - sumOfSqueres).ToString();
        }
    }
}
