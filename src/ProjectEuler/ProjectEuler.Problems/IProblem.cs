namespace ProjectEuler.Problems
{
    public interface IProblem
    {
        int Id { get; }
        string Title { get; }
        string Description { get; }
        string GetSolution();
    }
}
