using System;
using ProjectEuler.Problems.Helpers;

namespace ProjectEuler.Problems.Solutions
{
    /// <summary>
    /// Lattice paths
    /// <see cref="https://projecteuler.net/problem=15"/>
    /// </summary>
    public class Problem015 : IProblem
    {
        public int Id => 15;
        public string Title => "Lattice paths";

        public string Description =>
            "Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, " +
            "there are exactly 6 routes to the bottom right corner. \r\n" +
            "  (see https://projecteuler.net/problem=15 for visual representation) \r\n" +
            "How many such routes are there through a 20×20 grid?";

        // TODO!
        public string GetSolution()
        {
            var grid = new PathGrid();
            //grid.Setup(2, 2);
            //grid.Setup(3, 3);
            //grid.Setup(4, 4);
            //grid.Setup(5, 5);
            grid.Setup(10, 10);
            //grid.Setup(20, 20);
            var result = grid.FindPathCount();
            return result.ToString();
        }
    }
}
