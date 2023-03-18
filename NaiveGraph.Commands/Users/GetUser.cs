using MediatR;

namespace NaiveGraph.Commands.Users
{
    public class GetUser : IRequest<User>
    {
        public string Login { get; set; }
    }
}
