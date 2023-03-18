using System.Collections.Concurrent;

namespace NaiveGraph.Commands.Nodes
{
    public class Node
    {
        public string Id { get; set; }

        public string Graph { get; set; }
        
        public string Type { get; set; }

        public ConcurrentDictionary<string, object> Values { get; set; } = new();
    }
}
