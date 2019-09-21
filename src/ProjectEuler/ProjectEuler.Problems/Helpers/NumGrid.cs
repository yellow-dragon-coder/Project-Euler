using System;

namespace ProjectEuler.Problems.Helpers
{
    public class Grid
    {
        public enum Direction
        {
            Horz,
            Vert,
            Diag,
            Diag2
        }

        private readonly int[][] values;

        public int this[int row, int col]
        {
            get => values[row][col];
            set => values[row][col] = value;
        }

        public int RowCount { get; }
        public int ColCount { get; }

        public Grid(int rowCount, int colCount)
        {
            if (colCount < 1 || rowCount < 1)
                throw new ArgumentOutOfRangeException();

            RowCount = rowCount;
            ColCount = colCount;
            values   = default;
        }

        public Grid(int[][] values) : this(values.Length, values[0].Length)
        {
            this.values = values;
        }

        public int CurrentRow { get; private set; }
        public int CurrentCol { get; private set; }

        public int CurrentValue => values[CurrentRow][CurrentCol];

        public bool MoveNext()
        {
            CurrentCol++;
            if (CurrentCol > ColCount - 1)
            {
                CurrentRow++;
                CurrentCol = 0;
            }
            if (CurrentRow > RowCount - 1)
            {
                CurrentRow = RowCount - 1;
                CurrentCol = ColCount - 1;
                return false;
            }

            return true;
        }

        public bool GetNext(
            (int row, int col) current,
            Direction dir,
            out (int row, int col, int value) next)
        {
            next = (current.row, current.col, default);
            switch (dir)
            {
                case Direction.Horz
                when current.col < ColCount - 1:
                    next.col++;
                    break;
                case Direction.Vert
                when current.row < RowCount - 1:
                    next.row++;
                    break;
                case Direction.Diag
                when current.col < ColCount - 1 && current.row < RowCount - 1:
                    next.row++;
                    next.col++;
                    break;
                case Direction.Diag2
                when current.col > 0 && current.row < RowCount - 1:
                    next.row++;
                    next.col--;
                    break;
                default:
                    return false;
            }
            next.value = values[next.row][next.col];
            return true;
        }

        public (int row, int col, int value)[] GetBlock(
            (int row, int col) start,
            Direction dir,
            int size)
        {
            var block = new (int row, int col, int value)[size];
            for (int i = 0; i < size; i++)
            {
                if (!GetNext(start, dir, out var next))
                    return null;
                block[i] = (next.row, next.col, next.value);
                start.row = next.row;
                start.col = next.col;
            }
            return block;
        }

        public (int row, int col, int value)[] GetBlock(
            Direction dir,
            int size)
        {
            return GetBlock((CurrentRow, CurrentCol), dir, size);
        }
    }
}
