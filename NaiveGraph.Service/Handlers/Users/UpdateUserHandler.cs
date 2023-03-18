using MediatR;
using NaiveGraph.Commands.Users;
using NaiveGraph.Service.Cogs;
using System.Threading;
using System.Threading.Tasks;

namespace NaiveGraph.Service.Handlers.Users
{
    public class UpdateUserHandler : IRequestHandler<UpdateUser, Unit>
    {
        private readonly NaiveGraphService _service;

        private readonly Context _context;
        
        public UpdateUserHandler(NaiveGraphService service, Context context)
        {
            _service = service;
            _context = context;
        }

        public Task<Unit> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
