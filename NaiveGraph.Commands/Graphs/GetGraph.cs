using MediatR;

namespace NaiveGraph.Commands.Graphs
{
    public class GetGraph : IRequest<Graph>
    {
        public string Name { get; set; }

        public bool GetUsers { get; set; }

        public bool GetNodeTypes { get; set; }

        public bool GetEdgeTypes { get; set; }

        public bool GetNodes { get; set; }

        public bool GetEdges { get; set; }
    }
}
