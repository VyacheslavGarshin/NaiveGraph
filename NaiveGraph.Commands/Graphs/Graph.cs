using NaiveGraph.Commands.Nodes;
using NaiveGraph.Commands.NodeTypes;
using System.Collections.Generic;

namespace NaiveGraph.Commands.Graphs
{
    public class Graph
    {
        public string Name { get; set; }

        public List<string> Users { get; set; }

        public List<NodeType> NodeTypes { get; set; }

        public List<Node> Nodes { get; set; }
    }
}
