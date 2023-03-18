using MediatR;
using NaiveGraph.Service.Cogs;
using System.Threading;
using System.Threading.Tasks;
using NaiveGraph.Service.Exceptions;
using AutoMapper;
using NaiveGraph.Service.Entities;
using FluentValidation;
using NaiveGraph.Commands.NodeTypes;
using NaiveGraph.Commands.Nodes;

namespace NaiveGraph.Service.Handlers.Nodes
{
    public class CreateNodeHandler : IRequestHandler<CreateNode, Unit>
    {
        private readonly NaiveGraphService _service;

        private readonly Context _context;

        private readonly IMapper _mapper;

        public CreateNodeHandler(NaiveGraphService service, Context context, IMapper mapper)
        {
            _service = service;
            _context = context;
            _mapper = mapper;
        }

        public Task<Unit> Handle(CreateNode request, CancellationToken cancellationToken)
        {
            CreateNodeValidator.Default.ValidateAndThrow(request);

            _context.CheckUser();

            var entity = _mapper.Map<NodeEntity>(request);

            var graph = _service.Storage.GetGraph(entity.Graph, _context.User.Login);

            if (!graph.NodeTypes.TryGetValue(entity.Type, out var nodeType))
            {
                throw new LogicException($"Node type \"{entity.Type}\" on graph \"{entity.Graph}\" not found.");
            };

            var cog = new NodeCog { Entity = entity };

            if (!nodeType.Nodes.TryAdd(cog.Entity.Id, cog))
            {
                throw new LogicException($"Node of type \"{entity.Type}\" with id \"{entity.Id}\" on graph \"{entity.Graph}\" already exists.");
            }

            return Task.FromResult(Unit.Value);
        }

        public class CreateNodeValidator : AbstractValidator<CreateNode>
        {
            public static CreateNodeValidator Default { get; } = new();

            public CreateNodeValidator()
            {
                RuleFor(x => x.Type).NotEmpty();
                RuleFor(x => x.Graph).NotEmpty();
            }
        }
    }
}
