using System;

namespace ProjectEuler.Problems.Solutions
{
    /// <summary>
    /// Special Pythagorean triplet
    /// <see cref="https://projecteuler.net/problem=9"/>
    /// <seealso cref="http://www.wikizero.biz/index.php?q=aHR0cHM6Ly9lbi53aWtpcGVkaWEub3JnL3dpa2kvRm9ybXVsYXNfZm9yX2dlbmVyYXRpbmdfUHl0aGFnb3JlYW5fdHJpcGxlcw"/>
    /// </summary>
    public class Problem009 : IProblem
    {
        public int Id => 9;
        public string Title => "Special Pythagorean triplet";

        public string Description =>
            "A Pythagorean triplet is a set of three natural numbers, a < b < c, for which, \r\n" +
            "a² + b² = c² \r\n" +
            "For example, 32 + 42 = 9 + 16 = 25 = 5². \r\n" +
            "There exists exactly one Pythagorean triplet for which a + b + c = 1000. \r\n" +
            "Find the product abc.";

        public string GetSolution()
        {
            for (int k = 1; k <= 10; k++)
            {
                for (int m = 20; m > 2; m--)
                {
                    for (int n = 2; n < m - 1; n++)
                    {
                        var a = k * (2 * m * n);
                        var b = k * ((m * m) - (n * n));
                        var c = k * ((m * m) + (n * n));
                        if (a + b + c == 1000)
                            return $"{a} * {b} * {c} = {a * b * c}";
                    }
                }
            }
            throw new Exception("NOT FOUND!");
        }
    }
}
