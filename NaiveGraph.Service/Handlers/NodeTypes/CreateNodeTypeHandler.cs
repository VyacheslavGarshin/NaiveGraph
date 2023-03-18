using MediatR;
using NaiveGraph.Service.Cogs;
using System.Threading;
using System.Threading.Tasks;
using NaiveGraph.Service.Exceptions;
using AutoMapper;
using NaiveGraph.Service.Entities;
using FluentValidation;
using NaiveGraph.Commands.NodeTypes;

namespace NaiveGraph.Service.Handlers.NodeTypes
{
    public class CreateNodeTypeHandler : IRequestHandler<CreateNodeType, Unit>
    {
        private readonly NaiveGraphService _service;

        private readonly Context _context;

        private readonly IMapper _mapper;

        public CreateNodeTypeHandler(NaiveGraphService service, Context context, IMapper mapper)
        {
            _service = service;
            _context = context;
            _mapper = mapper;
        }

        public Task<Unit> Handle(CreateNodeType request, CancellationToken cancellationToken)
        {
            CreateNodeTypeValidator.Default.ValidateAndThrow(request);

            _context.CheckUser();

            var entity = _mapper.Map<NodeTypeEntity>(request);

            var graph = _service.Storage.GetGraph(entity.Graph, _context.User.Login);

            var cog = new NodeTypeCog { Entity = entity };

            if (!graph.NodeTypes.TryAdd(cog.Entity.Name, cog))
            {
                throw new LogicException($"Node type \"{cog.Entity.Name}\" on graph \"{cog.Entity.Graph}\" already exists.");
            };

            return Task.FromResult(Unit.Value);
        }

        public class CreateNodeTypeValidator : AbstractValidator<CreateNodeType>
        {
            public static CreateNodeTypeValidator Default { get; } = new();

            public CreateNodeTypeValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Graph).NotEmpty();
            }
        }
    }
}
