using FluentAssertions;
using NaiveGraph.Commands.Graphs;
using NaiveGraph.Service.Exceptions;
using NaiveGraph.Service.Handlers.Graphs;

namespace NaiveGraph.UnitTests.Handlers.Graphs
{
    public class CreateGraphHandlerUnitTests
    {
        [Test]
        public async Task AddNewGraph()
        {
            var handler = new CreateGraphHandler(Static.CreateService(), Static.CreateContext(Static.CreateAdmin()), Static.CreateMapper());

            await handler.Handle(new CreateGraph { Name = "graph" }, CancellationToken.None);
        }

        [Test]
        public async Task AddExistingGraph()
        {
            var handler = new CreateGraphHandler(Static.CreateService(), Static.CreateContext(Static.CreateAdmin()), Static.CreateMapper());

            var result = await handler.Handle(new CreateGraph { Name = "graph" }, CancellationToken.None);
            var act = async () => { await handler.Handle(new CreateGraph { Name = "graph" }, CancellationToken.None); };

            await act.Should().ThrowAsync<LogicException>().WithMessage("*already*");
        }
    }
}