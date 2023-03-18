using NaiveGraph.Service.Entities;
using NaiveGraph.Service.Exceptions;

namespace NaiveGraph.Service.Cogs
{
    public class Context
    {
        public UserEntity User { get; set; }

        public void CheckUser()
        {
            if (User == null)
            {
                throw new LogicException($"User is not authenticated.");
            }
        }
        
        public void CheckAdmin()
        {
            CheckUser();

            if (User == null || !User.IsAdmin)
            {
                throw new LogicException($"User \"{User.Login}\" must be an admin.");
            }
        }
    }
}
