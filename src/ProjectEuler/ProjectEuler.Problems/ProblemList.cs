using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ProjectEuler.Problems
{
    public static class ProblemList
    {
        static ProblemList() =>
            registeredProblems.AddRange(Assembly.GetExecutingAssembly().ExportedTypes
                .Where(t => typeof(IProblem).IsAssignableFrom(t)
                    && !t.IsInterface
                    && !t.IsAbstract).Select(t => Activator.CreateInstance(t) as IProblem));

        private static readonly List<IProblem> registeredProblems = new List<IProblem>();

        public static IProblem FindById(int id) => registeredProblems.Find(p => p.Id == id);
    }
}
