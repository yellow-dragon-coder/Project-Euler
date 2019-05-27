using System;

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
            for (var i = 999; i > 100; i--)
            {
                for (var j = 999; j > 100; j--)
                {
                    var p = i * j;
                    if (IsPalindrome(p.ToString()))
                        return $"{i} * {j} = {p}";
                }
            }
            throw new Exception("Solution not found");
        }

        private bool IsPalindrome(string s)
        {
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                    return false;
            }
            return true;
        }
    }
}
