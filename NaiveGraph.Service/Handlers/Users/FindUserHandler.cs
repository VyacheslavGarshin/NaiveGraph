using MediatR;
using NaiveGraph.Commands.Users;
using NaiveGraph.Service.Cogs;
using System.Threading;
using System.Threading.Tasks;

namespace NaiveGraph.Service.Handlers.Users
{
    public class FindUserHandler : IRequestHandler<FindUsers, Unit>
    {
        private readonly NaiveGraphService _service;

        private readonly Context _context;

        public FindUserHandler(NaiveGraphService service)
        {
            _service = service;
        }

        public Task<Unit> Handle(FindUsers request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
