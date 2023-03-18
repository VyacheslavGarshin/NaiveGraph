using NaiveGraph.Service.Entities;
using NaiveGraph.Service.Exceptions;
using System.Collections.Concurrent;

namespace NaiveGraph.Service.Cogs
{
    public class GraphCog
    {
        public GraphEntity Entity { get; set; }

        public ConcurrentDictionary<string, UserCog> Users { get; set; } = new();

        public ConcurrentDictionary<string, NodeTypeCog> NodeTypes { get; set; } = new();

        public void CheckUser(string login)
        {
            if (!Users.ContainsKey(login))
            {
                throw new LogicException($"User \"{login}\" on graph \"{Entity.Name}\" not found.");
            }
        }
    }
}
