using NaiveGraph.Service.Entities;
using System.Collections.Concurrent;

namespace NaiveGraph.Service.Cogs
{
    public class NodeTypeCog
    {
        public NodeTypeEntity Entity { get; set; }

        public ConcurrentDictionary<string, NodeCog> Nodes { get; set; } = new();
    }
}
