using ProjectEuler.Problems.Helpers;

namespace ProjectEuler.Problems.Solutions
{
    /// <summary>
    /// Largest product in a grid
    /// <see cref="https://projecteuler.net/problem=11"/>
    /// </summary>
    public class Problem011 : IProblem
    {
        public int Id => 11;
        public string Title => "Largest product in a grid";

        private readonly int[][] Values =
        {
            new int[] { 08, 02, 22, 97, 38, 15, 00, 40, 00, 75, 04, 05, 07, 78, 52, 12, 50, 77, 91, 08 },
            new int[] { 49, 49, 99, 40, 17, 81, 18, 57, 60, 87, 17, 40, 98, 43, 69, 48, 04, 56, 62, 00 },
            new int[] { 81, 49, 31, 73, 55, 79, 14, 29, 93, 71, 40, 67, 53, 88, 30, 03, 49, 13, 36, 65 },
            new int[] { 52, 70, 95, 23, 04, 60, 11, 42, 69, 24, 68, 56, 01, 32, 56, 71, 37, 02, 36, 91 },
            new int[] { 22, 31, 16, 71, 51, 67, 63, 89, 41, 92, 36, 54, 22, 40, 40, 28, 66, 33, 13, 80 },
            new int[] { 24, 47, 32, 60, 99, 03, 45, 02, 44, 75, 33, 53, 78, 36, 84, 20, 35, 17, 12, 50 },
            new int[] { 32, 98, 81, 28, 64, 23, 67, 10, 26, 38, 40, 67, 59, 54, 70, 66, 18, 38, 64, 70 },
            new int[] { 67, 26, 20, 68, 02, 62, 12, 20, 95, 63, 94, 39, 63, 08, 40, 91, 66, 49, 94, 21 },
            new int[] { 24, 55, 58, 05, 66, 73, 99, 26, 97, 17, 78, 78, 96, 83, 14, 88, 34, 89, 63, 72 },
            new int[] { 21, 36, 23, 09, 75, 00, 76, 44, 20, 45, 35, 14, 00, 61, 33, 97, 34, 31, 33, 95 },
            new int[] { 78, 17, 53, 28, 22, 75, 31, 67, 15, 94, 03, 80, 04, 62, 16, 14, 09, 53, 56, 92 },
            new int[] { 16, 39, 05, 42, 96, 35, 31, 47, 55, 58, 88, 24, 00, 17, 54, 24, 36, 29, 85, 57 },
            new int[] { 86, 56, 00, 48, 35, 71, 89, 07, 05, 44, 44, 37, 44, 60, 21, 58, 51, 54, 17, 58 },
            new int[] { 19, 80, 81, 68, 05, 94, 47, 69, 28, 73, 92, 13, 86, 52, 17, 77, 04, 89, 55, 40 },
            new int[] { 04, 52, 08, 83, 97, 35, 99, 16, 07, 97, 57, 32, 16, 26, 26, 79, 33, 27, 98, 66 },
            new int[] { 88, 36, 68, 87, 57, 62, 20, 72, 03, 46, 33, 67, 46, 55, 12, 32, 63, 93, 53, 69 },
            new int[] { 04, 42, 16, 73, 38, 25, 39, 11, 24, 94, 72, 18, 08, 46, 29, 32, 40, 62, 76, 36 },
            new int[] { 20, 69, 36, 41, 72, 30, 23, 88, 34, 62, 99, 69, 82, 67, 59, 85, 74, 04, 36, 16 },
            new int[] { 20, 73, 35, 29, 78, 31, 90, 01, 74, 31, 49, 71, 48, 86, 81, 16, 23, 57, 05, 54 },
            new int[] { 01, 70, 54, 71, 83, 51, 54, 69, 16, 92, 33, 48, 61, 43, 52, 01, 89, 19, 67, 48 }
        };

        public string Description =>
            "In the 20×20 grid below, four numbers along a diagonal line have been marked\r\n\r\n" +
            "  08  02  22  97  38  15  00  40  00  75  04  05  07  78  52  12  50  77  91  08\r\n" +
            "  49  49  99  40  17  81  18  57  60  87  17  40  98  43  69  48  04  56  62  00\r\n" +
            "  81  49  31  73  55  79  14  29  93  71  40  67  53  88  30  03  49  13  36  65\r\n" +
            "  52  70  95  23  04  60  11  42  69  24  68  56  01  32  56  71  37  02  36  91\r\n" +
            "  22  31  16  71  51  67  63  89  41  92  36  54  22  40  40  28  66  33  13  80\r\n" +
            "  24  47  32  60  99  03  45  02  44  75  33  53  78  36  84  20  35  17  12  50\r\n" +
            "  32  98  81  28  64  23  67  10 [26] 38  40  67  59  54  70  66  18  38  64  70\r\n" +
            "  67  26  20  68  02  62  12  20  95 [63] 94  39  63  08  40  91  66  49  94  21\r\n" +
            "  24  55  58  05  66  73  99  26  97  17 [78] 78  96  83  14  88  34  89  63  72\r\n" +
            "  21  36  23  09  75  00  76  44  20  45  35 [14] 00  61  33  97  34  31  33  95\r\n" +
            "  78  17  53  28  22  75  31  67  15  94  03  80  04  62  16  14  09  53  56  92\r\n" +
            "  16  39  05  42  96  35  31  47  55  58  88  24  00  17  54  24  36  29  85  57\r\n" +
            "  86  56  00  48  35  71  89  07  05  44  44  37  44  60  21  58  51  54  17  58\r\n" +
            "  19  80  81  68  05  94  47  69  28  73  92  13  86  52  17  77  04  89  55  40\r\n" +
            "  04  52  08  83  97  35  99  16  07  97  57  32  16  26  26  79  33  27  98  66\r\n" +
            "  88  36  68  87  57  62  20  72  03  46  33  67  46  55  12  32  63  93  53  69\r\n" +
            "  04  42  16  73  38  25  39  11  24  94  72  18  08  46  29  32  40  62  76  36\r\n" +
            "  20  69  36  41  72  30  23  88  34  62  99  69  82  67  59  85  74  04  36  16\r\n" +
            "  20  73  35  29  78  31  90  01  74  31  49  71  48  86  81  16  23  57  05  54\r\n" +
            "  01  70  54  71  83  51  54  69  16  92  33  48  61  43  52  01  89  19  67  48\r\n\r\n" +
            "The product of these numbers is 26 × 63 × 78 × 14 = 1788696. \r\n" +
            "What is the greatest product of four adjacent numbers in the \r\n" +
            "same direction (up, down, left, right, or diagonally) in the 20×20 grid?";

        public string GetSolution()
        {
            var grid = new Grid(Values);

            (int row, int col, int value)[] max = null;

            do
            {
                CheckBlock(grid.GetBlock(Grid.Direction.Diag,  4), ref max);
                CheckBlock(grid.GetBlock(Grid.Direction.Diag2, 4), ref max);
                CheckBlock(grid.GetBlock(Grid.Direction.Horz,  4), ref max);
                CheckBlock(grid.GetBlock(Grid.Direction.Vert,  4), ref max);
            } while (grid.MoveNext());

            // TODO: Better visualization
            return
                $"{max[0].value} × {max[1].value} × {max[2].value} × {max[3].value} = " +
                $"{max[0].value  *  max[1].value  *  max[2].value  *  max[3].value} \r\n" +
                $"  from: (row:{max[0].row + 1},col:{max[0].col + 1})\r\n" +
                $"  to  : (row:{max[3].row + 1},col:{max[3].col + 1})";
        }

        private void CheckBlock(
            (int row, int col, int value)[] block,
            ref (int row, int col, int value)[] max)
        {
            if (block == null) return;
            max = max ?? block;
            if (block.Multiply(i => i.value) > max.Multiply(i => i.value))
                max = block;
        }
    }
}
