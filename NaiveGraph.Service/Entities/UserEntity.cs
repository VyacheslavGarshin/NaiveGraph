using NaiveGraph.Commands.Users;

namespace NaiveGraph.Service.Entities
{
    public class UserEntity : User
    {
        public string PasswordHash { get; set; }
    }
}
