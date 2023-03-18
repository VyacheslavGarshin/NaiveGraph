using MediatR;
using NaiveGraph.Commands.Users;
using NaiveGraph.Service.Cogs;
using System.Threading;
using System.Threading.Tasks;

namespace NaiveGraph.Service.Handlers.Users
{
    public class GetUserHandler : IRequestHandler<GetUser, User>
    {
        private readonly NaiveGraphService _service;

        private readonly Context _context;
        
        public GetUserHandler(NaiveGraphService service, Context context)
        {
            _service = service;
            _context = context;
        }

        public Task<User> Handle(GetUser request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
