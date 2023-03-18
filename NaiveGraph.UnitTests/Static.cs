using AutoMapper;
using NaiveGraph.Service;
using NaiveGraph.Service.Cogs;
using NaiveGraph.Service.Entities;
using NaiveGraph.Service.Extensions;

namespace NaiveGraph.UnitTests
{
    public static class Static
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(NaiveGraphService).Assembly));
            return config.CreateMapper();
        }

        public static NaiveGraphService CreateService()
        {
            return new NaiveGraphService(CreateMapper());
        }

        public static Context CreateContext(UserEntity userEntity = null)
        {
            return new Context { User = userEntity ?? new UserEntity() };
        }

        public static UserEntity CreateUser()
        {
            return new UserEntity { Login = "user", PasswordHash = "user".ComputeHash() };
        }
        
        public static UserEntity CreateAdmin()
        {
            return new UserEntity { Login = "admin", PasswordHash = "admin".ComputeHash(), IsAdmin = true };
        }
    }
}