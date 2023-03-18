using AutoMapper;
using NaiveGraph.Commands;
using NaiveGraph.Service.Entities;

namespace NaiveGraph.Service.Profiles
{
    public class FieldProfile : Profile
    {
        public FieldProfile()
        {
            CreateMap<Field, FieldEntity>();
        }
    }
}
