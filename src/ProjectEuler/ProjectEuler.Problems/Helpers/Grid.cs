using System;

namespace ProjectEuler.Problems.Helpers
{
    public class Grid<T>
    {
        public T[,] Values { get; }

        public T this[int col, int row]
        {
            get => Values[col, row];
            set => Values[col, row] = value;
        }

        public int ColCount { get; }
        public int RowCount { get; }

        public Grid(int colCount, int rowCount)
        {
            if (colCount < 1 || rowCount < 1)
                throw new ArgumentOutOfRangeException();

            ColCount = colCount;
            RowCount = rowCount;
            Values   = new T[ColCount, RowCount];
        }
    }
}
