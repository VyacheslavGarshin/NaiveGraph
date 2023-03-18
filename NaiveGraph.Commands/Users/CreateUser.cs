using MediatR;

namespace NaiveGraph.Commands.Users
{
    public class CreateUser : User, IRequest<Unit>
    {
        public string Password { get; set; }
    }
}
