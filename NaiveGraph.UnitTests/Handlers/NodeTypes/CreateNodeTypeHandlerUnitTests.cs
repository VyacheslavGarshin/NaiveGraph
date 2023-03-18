using NaiveGraph.Commands;
using NaiveGraph.Commands.Graphs;
using NaiveGraph.Commands.NodeTypes;
using NaiveGraph.Commands.Users;
using NaiveGraph.Service.Handlers.Graphs;
using NaiveGraph.Service.Handlers.NodeTypes;
using NaiveGraph.Service.Handlers.Users;

namespace NaiveGraph.UnitTests.Handlers.NodeTypes
{
    public class CreateNodeTypeHandlerUnitTests
    {
        [Test]
        public async Task AddNewNodeType()
        {
            var service = Static.CreateService();
            var context = Static.CreateContext(Static.CreateAdmin());
            var mapper = Static.CreateMapper();

            await new CreateUserHandler(service, context, mapper)
                .Handle(new CreateUser { Login = "user", Password = "user" }, CancellationToken.None);

            await new CreateGraphHandler(service, context, mapper)
                .Handle(new CreateGraph { Name = "graph", Users = new List<string> { "user" } }, CancellationToken.None);

            context = Static.CreateContext(Static.CreateUser());

            var request = new CreateNodeType
            {
                Name = "person",
                Graph = "graph",
                Fields = new List<Field>
                {
                    new Field { Name = "name", Type = FieldType.String }
                }
            };

            await new CreateNodeTypeHandler(service, context, mapper)
                .Handle(request, CancellationToken.None);
        }

        [Test]
        public async Task AddExistingNodeType()
        {         
        }
    }
}