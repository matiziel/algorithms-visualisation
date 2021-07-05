using Contracts.Services;
using Common;
using Contracts.DataTransferObjects;
using Application.Extensions;


namespace Application {
    public class AlgorithmExecutor : IAlgorithmExecutor {
        private readonly IAlgorithmFactory _factory;
        private readonly IGraphBuilder _builder;

        public AlgorithmExecutor(IAlgorithmFactory factory, IGraphBuilder builder) {
            _factory = factory;
            _builder = builder;
        }

        public Animation Execute(Grid grid, AlgorithmType type) {
            var graph = _builder.BuildGraphFromGrid(grid.GridArray);
            var algorithm = _factory.Create(graph, type);
            return algorithm.Execute().MapToAnimation();
        }
    }
}