using AutoMapper;
using NaiveGraph.Commands.Graphs;
using NaiveGraph.Service.Entities;

namespace NaiveGraph.Service.Profiles
{
    public class GraphProfile : Profile
    {
        public GraphProfile()
        {
            CreateMap<CreateGraph, GraphEntity>();
        }
    }
}
