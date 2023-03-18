using AutoMapper;
using NaiveGraph.Commands.Users;
using NaiveGraph.Service.Cogs;
using NaiveGraph.Service.Entities;
using NaiveGraph.Service.Handlers.Users;
using System.Threading;

namespace NaiveGraph.Service
{
    public class NaiveGraphService
    {
        public Storage Storage { get; } = new();

        private readonly IMapper _mapper;

        public NaiveGraphService(IMapper mapper)
        {
            _mapper = mapper;

            AddAdminUser();
        }

        private void AddAdminUser()
        {
            var admin = new CreateUser { Login = "admin", Password = "admin", IsAdmin = true };
            var adminEntity = _mapper.Map<UserEntity>(admin);
            var context = new Context { User = adminEntity };
            new CreateUserHandler(this, context, _mapper).Handle(admin, CancellationToken.None).GetAwaiter().GetResult();
        }
    }
}
