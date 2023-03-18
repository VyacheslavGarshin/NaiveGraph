using MediatR;
using NaiveGraph.Commands.Users;
using NaiveGraph.Service.Cogs;
using System.Threading;
using System.Threading.Tasks;

namespace NaiveGraph.Service.Handlers.Users
{
    public class DeleteUserHandler : IRequestHandler<DeleteUser, Unit>
    {
        private readonly NaiveGraphService _service;

        private readonly Context _context;

        public DeleteUserHandler(NaiveGraphService service, Context context)
        {
            _service = service;
            _context = context;
        }

        public Task<Unit> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
