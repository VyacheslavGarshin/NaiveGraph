using AutoMapper;
using NaiveGraph.Commands.NodeTypes;
using NaiveGraph.Service.Entities;

namespace NaiveGraph.Service.Profiles
{
    public class NodeTypeProfile : Profile
    {
        public NodeTypeProfile()
        {
            CreateMap<CreateNodeType, NodeTypeEntity>();
        }
    }
}
