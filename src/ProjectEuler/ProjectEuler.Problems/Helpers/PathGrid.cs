using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems.Helpers
{
    public class PathGrid
    {
        private PathGridNode[] nodes;
        private readonly Stack<PathGridNode> path = new Stack<PathGridNode>();

        public PathGrid()
        {
        }

        public void Setup(int cols, int rows)
        {
            path.Clear();
            if (cols <= 0 || rows <= 0) throw new ArgumentOutOfRangeException();
            nodes = new PathGridNode[++cols * ++rows];
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new PathGridNode();
            }
            var p = 0;
            for (var r = 0; r < rows; r++)
                for (var c = 0; c < cols; c++)
                {
                    nodes[p].RightNode = c < cols - 1 ? nodes[p + 1] : null;
                    nodes[p].DownNode  = r < rows - 1 ? nodes[p + cols] : null;
                    p++;
                }
        }

        public int FindPathCount()
        {
            if (nodes is null || nodes.Length < 9)
                throw new InvalidOperationException(nameof(nodes));
            var count = 0;
            var node = nodes[0];
            while (node != null)
            {
                path.Push(node);
                GoToFinish(node);
                count++;
                node = BackToDetour()?.DownNode;
            }
            return count;
        }

        private PathGridNode BackToDetour()
        {
            var node = path.Pop();
            while (node.VisitedDown || node.DownNode is null)
            {
                if (path.Count == 0) return null;
                node = path.Pop();
            }
            return node;
        }

        private void GoToFinish(PathGridNode node)
        {
            while (node != null)
            {
                if (node.RightNode != null)
                {
                    node.VisitedRight = true;
                    node = node.RightNode;
                }
                else if (node.DownNode != null)
                {
                    node.VisitedDown = true;
                    node = node.DownNode;
                }
                else
                {
                    path.Push(node);
                    return;
                }
                path.Push(node);
            }
        }
    }
}
