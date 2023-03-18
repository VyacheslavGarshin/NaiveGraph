using MediatR;
using NaiveGraph.Commands.Users;
using NaiveGraph.Service.Cogs;
using System.Threading;
using System.Threading.Tasks;
using NaiveGraph.Service.Exceptions;
using AutoMapper;
using NaiveGraph.Service.Entities;
using FluentValidation;

namespace NaiveGraph.Service.Handlers.Users
{
    public class CreateUserHandler : IRequestHandler<CreateUser, Unit>
    {
        private readonly NaiveGraphService _service;
        
        private readonly Context _context;
        
        private readonly IMapper _mapper;

        public CreateUserHandler(NaiveGraphService service, Context context, IMapper mapper)
        {
            _service = service;
            _context = context;
            _mapper = mapper;
        }

        public Task<Unit> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            CreateUserValidator.Default.ValidateAndThrow(request);

            _context.CheckAdmin();

            var cog = new UserCog { Entity = _mapper.Map<UserEntity>(request) };

            if (!_service.Storage.Users.TryAdd(cog.Entity.Login, cog))
            {
                throw new LogicException($"User \"{cog.Entity.Login}\" already exists.");
            };

            return Task.FromResult(Unit.Value);
        }

        public class CreateUserValidator : AbstractValidator<CreateUser>
        {
            public static CreateUserValidator Default { get; } = new();

            public CreateUserValidator()
            {
                RuleFor(x => x.Login).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }
    }
}
