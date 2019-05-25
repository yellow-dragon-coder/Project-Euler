using System;
using ProjectEuler.Problems;
using static System.Console;

#pragma warning disable RCS1018 // Add default access modifier.

namespace ProjectEuler.CLI
{
    static class Program
    {
        static void Main()
        {
            WriteLine("WELCOME TO PROJECT EULER!");
            WriteLine("Enter Problem ID (0: EXIT) \r\n");
            while (true)
            {
                Write("Problem ID> #");
                if (!int.TryParse(ReadLine(), out var id)) continue;
                if (id > 0)
                    Solve(id);
                else
                    break;
            }
        }

        private static void Solve(int id)
        {
            try
            {
                var problem = ProblemList.FindById(id);
                if (problem == null) throw new Exception($"Problem #{id} not fount!");
                var title = $"{problem.Title.ToUpperInvariant()}:";
                WriteLine(title);
                WriteLine(new string('-', title.Length));
                WriteLine($"{problem.Description} \r\n");
                WriteLine($"= {problem.GetSolution()} \r\n");
            }
            catch (Exception e)
            {
                WriteLine($"ERROR: {e.Message} \r\n");
            }
        }
    }
}

#pragma warning restore RCS1018 // Add default access modifier.
