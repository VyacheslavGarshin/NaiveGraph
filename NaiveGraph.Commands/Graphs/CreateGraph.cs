using MediatR;

namespace NaiveGraph.Commands.Graphs
{
    public class CreateGraph : Graph, IRequest<Unit>
    {
    }
}
