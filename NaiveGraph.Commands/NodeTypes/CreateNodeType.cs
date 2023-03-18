using MediatR;

namespace NaiveGraph.Commands.NodeTypes
{
    public class CreateNodeType : NodeType, IRequest<Unit>
    {

    }
}
