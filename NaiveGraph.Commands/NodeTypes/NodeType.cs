using System.Collections.Generic;

namespace NaiveGraph.Commands.NodeTypes
{
    public class NodeType
    {
        public string Name { get; set; }

        public string Graph { get; set; }

        public List<Field> Fields { get; set; }
    }
}
