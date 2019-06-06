using System.Linq;

namespace ProjectEuler.Problems.Solutions
{
    /// <summary>
    /// Largest product in a series
    /// <see cref="https://projecteuler.net/problem=8"/>
    /// </summary>
    public class Problem008 : IProblem
    {
        private const string digit =
            "    73167176531330624919225119674426574742355349194934 \r\n" +
            "    96983520312774506326239578318016984801869478851843 \r\n" +
            "    85861560789112949495459501737958331952853208805511 \r\n" +
            "    12540698747158523863050715693290963295227443043557 \r\n" +
            "    66896648950445244523161731856403098711121722383113 \r\n" +
            "    62229893423380308135336276614282806444486645238749 \r\n" +
            "    30358907296290491560440772390713810515859307960866 \r\n" +
            "    70172427121883998797908792274921901699720888093776 \r\n" +
            "    65727333001053367881220235421809751254540594752243 \r\n" +
            "    52584907711670556013604839586446706324415722155397 \r\n" +
            "    53697817977846174064955149290862569321978468622482 \r\n" +
            "    83972241375657056057490261407972968652414535100474 \r\n" +
            "    82166370484403199890008895243450658541227588666881 \r\n" +
            "    16427171479924442928230863465674813919123162824586 \r\n" +
            "    17866458359124566529476545682848912883142607690042 \r\n" +
            "    24219022671055626321111109370544217506941658960408 \r\n" +
            "    07198403850962455444362981230987879927244284909188 \r\n" +
            "    84580156166097919133875499200524063689912560717606 \r\n" +
            "    05886116467109405077541002256983155200055935729725 \r\n" +
            "    71636269561882670428252483600823257530420752963450 \r\n";

        public int Id => 8;
        public string Title => "Largest product in a series";

        public string Description =>
            "The four adjacent digits in the 1000-digit number that have the greatest product " +
            "are 9 × 9 × 8 × 9 = 5832. \r\n\r\n" +
            digit +
            "\r\nFind the thirteen adjacent digits in the 1000-digit number that have " +
            "the greatest product. What is the value of this product?";

        public string GetSolution()
        {
            var d = string.Concat(digit
                .Split('\r', '\n')
                .Select(c => c.Trim())
                .Where(c => !string.IsNullOrEmpty(c)));

            const int digits = 13;

            var result     = new int[digits];
            var maxProduct = int.MinValue;

            var p = 0;

            while (p + digits <= d.Length)
            {
                var values  = new int[digits];
                var product = 1;

                for (int i = 0; i < digits; i++)
                {
                    values[i] = int.Parse(d[i + p].ToString());
                    product *= values[i];
                }
                p++;
                if (product <= maxProduct) continue;

                result     = values;
                maxProduct = product;
            }
            return $"{string.Join(" × ", result)} = {maxProduct}";
        }
    }
}
