using MediatR;
using NaiveGraph.Service.Cogs;
using System.Threading;
using System.Threading.Tasks;
using NaiveGraph.Service.Exceptions;
using AutoMapper;
using NaiveGraph.Service.Entities;
using FluentValidation;
using NaiveGraph.Commands.Graphs;

namespace NaiveGraph.Service.Handlers.Graphs
{
    public class CreateGraphHandler : IRequestHandler<CreateGraph, Unit>
    {
        private readonly NaiveGraphService _service;

        private readonly Context _context;

        private readonly IMapper _mapper;

        public CreateGraphHandler(NaiveGraphService service, Context context, IMapper mapper)
        {
            _service = service;
            _context = context;
            _mapper = mapper;
        }

        public Task<Unit> Handle(CreateGraph request, CancellationToken cancellationToken)
        {
            CreateGraphValidator.Default.ValidateAndThrow(request);

            _context.CheckAdmin();

            var cog = new GraphCog { Entity = _mapper.Map<GraphEntity>(request) };

            AddUsers(request, cog);

            if (!_service.Storage.Graphs.TryAdd(cog.Entity.Name, cog))
            {
                throw new LogicException($"Graph \"{cog.Entity.Name}\" already exists.");
            };

            return Task.FromResult(Unit.Value);
        }

        private void AddUsers(CreateGraph request, GraphCog cog)
        {
            if (request.Users == null)
            {
                return;
            }

            foreach (var login in request.Users)
            {
                if (!_service.Storage.Users.TryGetValue(login, out var user))
                {
                    throw new LogicException($"User \"{login}\" not found.");
                }

                cog.Users.TryAdd(login, user);
            }
        }

        public class CreateGraphValidator : AbstractValidator<CreateGraph>
        {
            public static CreateGraphValidator Default { get; } = new();

            public CreateGraphValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
            }
        }
    }
}
