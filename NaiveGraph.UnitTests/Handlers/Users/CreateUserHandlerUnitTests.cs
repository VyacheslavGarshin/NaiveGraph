using FluentAssertions;
using NaiveGraph.Commands.Users;
using NaiveGraph.Service.Exceptions;
using NaiveGraph.Service.Handlers.Users;

namespace NaiveGraph.UnitTests.Handlers.Users
{
    public class CreateUserHandlerUnitTests
    {
        [Test]
        public async Task AddNewUser()
        {
            var handler = new CreateUserHandler(Static.CreateService(), Static.CreateContext(Static.CreateAdmin()), Static.CreateMapper());

            await handler.Handle(new CreateUser { Login = "user", Password = "user" }, CancellationToken.None);
        }

        [Test]
        public async Task AddExistingUser()
        {
            var handler = new CreateUserHandler(Static.CreateService(), Static.CreateContext(Static.CreateAdmin()), Static.CreateMapper());

            var result = await handler.Handle(new CreateUser { Login = "user", Password = "user" }, CancellationToken.None);
            var act = async () => { await handler.Handle(new CreateUser { Login = "user", Password = "user" }, CancellationToken.None); };

            await act.Should().ThrowAsync<LogicException>().WithMessage("*already*");
        }

        [Test]
        public async Task AddNewUserByNotAdmin()
        {
            var handler = new CreateUserHandler(Static.CreateService(), Static.CreateContext(Static.CreateUser()), Static.CreateMapper());

            var act = async () => { await handler.Handle(new CreateUser { Login = "user", Password = "user" }, CancellationToken.None); };

            await act.Should().ThrowAsync<LogicException>().WithMessage("*must be an admin*");
        }
    }
}