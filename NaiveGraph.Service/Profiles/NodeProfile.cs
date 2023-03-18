using AutoMapper;
using NaiveGraph.Commands.Nodes;
using NaiveGraph.Service.Entities;

namespace NaiveGraph.Service.Profiles
{
    public class NodeProfile : Profile
    {
        public NodeProfile()
        {
            CreateMap<CreateNode, NodeEntity>();
        }
    }
}
