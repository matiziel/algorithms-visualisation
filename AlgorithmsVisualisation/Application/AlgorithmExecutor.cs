using System;
using Contracts.Services;
using GraphsAlgorithms.Result;
using Common;
using Contracts.DataTransferObjects;

namespace Application {
    public class AlgorithmExecutor : IAlgorithmExecutor {
        private readonly IAlgorithmFactory _factory;
        private readonly IGraphBuilder _builder;

        public AlgorithmExecutor(IAlgorithmFactory factory, IGraphBuilder builder) {
            _factory = factory;
            _builder = builder;
        }

        public AlgorithmResult Execute(Grid grid, AlgorithmType type) {
            var graph = _builder.BuildGraphFromGrid(grid);
            var algorithm = _factory.Create(graph, type);
            return algorithm.Execute();
        }
    }
}