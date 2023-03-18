using MediatR;

namespace NaiveGraph.Commands.Users
{
    public class UpdateUser : User, IRequest<Unit>
    {
        public string Password { get; set; }
    }
}
