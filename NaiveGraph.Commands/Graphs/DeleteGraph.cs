using MediatR;

namespace NaiveGraph.Commands.Graphs
{
    public class DeleteGraph : IRequest<Unit>
    {
        public string Name { get; set; }
    }
}
