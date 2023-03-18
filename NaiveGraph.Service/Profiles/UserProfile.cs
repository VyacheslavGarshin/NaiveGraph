using AutoMapper;
using NaiveGraph.Commands.Users;
using NaiveGraph.Service.Entities;
using NaiveGraph.Service.Extensions;

namespace NaiveGraph.Service.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUser, UserEntity>()
                .ForMember(x => x.IsAdmin, x => x.MapFrom(y => y.IsAdmin))
                .ForMember(x => x.Login, x => x.MapFrom(y => y.Login))
                .ForMember(x => x.PasswordHash, x => x.MapFrom(y => y.Password.ComputeHash()));
        }
    }
}
