using System;

namespace ProjectEuler.Problems.Helpers
{
    public abstract class Grid<T>
    {
        protected readonly T[][] values;

        public T this[int row, int col]
        {
            get => values[row][col];
            set => values[row][col] = value;
        }

        public int RowCount { get; }
        public int ColCount { get; }

        protected Grid(int rowCount, int colCount)
        {
            if (colCount < 1 || rowCount < 1)
                throw new ArgumentOutOfRangeException();

            RowCount = rowCount;
            ColCount = colCount;
            values   = default;
        }

        protected Grid(T[][] values) : this(values.Length, values[0].Length)
        {
            this.values = values;
        }
    }
}
