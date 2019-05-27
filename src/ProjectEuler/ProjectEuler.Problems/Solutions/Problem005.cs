using static ProjectEuler.Problems.Helpers.Funcs;

namespace ProjectEuler.Problems.Solutions
{
    /// <summary>
    /// Smallest multiple
    /// <see cref="https://projecteuler.net/problem=5"/>
    /// </summary>
    public class Problem005 : IProblem
    {
        public int Id => 5;
        public string Title => "Smallest multiple";

        public string Description =>
            "2520 is the smallest number that can be divided by each of the numbers " +
            "from 1 to 10 without any remainder. \r\n" +
            "What is the smallest positive number that is evenly divisible by all of the numbers " +
            "from 1 to 20?";

        public string GetSolution()
        {
            long result = 1;
            for (int i = 1; i <= 20; i++)
                result = Lcd(i, result);
            return result.ToString();
        }
    }
}
