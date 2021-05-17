using System.Collections.Generic;
using System.Linq;

namespace Task_2
{
    public class Node
    {
        public  HashSet<Node> AdjacentNodes { get; }
        public Color Color { get; set; }
        
        public int Id { get; }

        public Node(int id, Color color = Color.None, params Node[] nodes)
        {
            Color = color;
            AdjacentNodes = nodes.ToHashSet();
            Id = id;
        }
    }
}