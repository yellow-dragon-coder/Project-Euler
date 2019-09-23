namespace ProjectEuler.Problems.Helpers
{
    public class PathGridNode
    {
        public bool VisitedRight { get; set; }
        public bool VisitedDown { get; set; }

        public PathGridNode RightNode { get; set; }
        public PathGridNode DownNode { get; set; }
    }
}
