using MediatR;

namespace NaiveGraph.Commands.Users
{
    public class DeleteUser : IRequest<Unit>
    {
        public string Login { get; set; }
    }
}
