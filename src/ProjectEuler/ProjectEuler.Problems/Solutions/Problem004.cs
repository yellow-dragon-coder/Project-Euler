using ProjectEuler.Problems.Helpers;

namespace ProjectEuler.Problems.Solutions
{
    /// <summary>
    /// Largest palindrome product
    /// <see cref="https://projecteuler.net/problem=4"/>
    /// </summary>
    public class Problem004 : IProblem
    {
        public int Id => 4;
        public string Title => "Largest palindrome product";

        public string Description =>
            "A palindromic number reads the same both ways. \r\n" +
            "The largest palindrome made from the product of two 2-digit numbers is \r\n" +
            "9009 = 91 × 99. \r\n" +
            "Find the largest palindrome made from the product of two 3-digit numbers.";

        public string GetSolution()
        {
            var maxP = 0;
            var result = "";
            for (var i = 1000; i > 100; i--)
            {
                for (var j = 1000; j > 100; j--)
                {
                    var p = i * j;
                    if (p.IsPalindrome())
                    {
                        if (p > maxP)
                        {
                            maxP = p;
                            result = $"{i} × {j} = {maxP}";
                        }
                        break; // this is the largest palindrome with this i value.
                    }
                }
            }
            return result;
        }
    }
}
