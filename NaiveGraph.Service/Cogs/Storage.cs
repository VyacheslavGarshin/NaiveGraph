using NaiveGraph.Service.Exceptions;
using System.Collections.Concurrent;

namespace NaiveGraph.Service.Cogs
{
    public class Storage
    {
        public ConcurrentDictionary<string, UserCog> Users { get; set; } = new();

        public ConcurrentDictionary<string, GraphCog> Graphs { get; set; } = new();

        public GraphCog GetGraph(string name, string login = null)
        {
            if (!Graphs.TryGetValue(name, out var result))
            {
                throw new LogicException($"Graph \"{name}\" not found.");
            }

            if (login != null)
            {
                result.CheckUser(login);
            }

            return result;
        }
    }
}
