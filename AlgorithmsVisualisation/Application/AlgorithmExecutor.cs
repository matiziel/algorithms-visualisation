using Contracts.Services;
using Common;
using Contracts.DataTransferObjects;
using Application.Extensions;
using System;
using GraphsAlgorithms.Result;
using GraphsAlgorithms.Algorithms;

namespace Application {
    public class AlgorithmExecutor : IAlgorithmExecutor {
        private readonly IAlgorithmFactory _factory;
        private readonly IGraphBuilder _builder;

        public AlgorithmExecutor(IAlgorithmFactory factory, IGraphBuilder builder) {
            _factory = factory;
            _builder = builder;
        }

        public Animation Execute(Grid grid) {
            var graph = _builder.BuildGraphFromGrid(grid.GridArray, grid.MetricType);
            var algorithm = _factory.Create(graph, grid.Start, grid.End, grid.AlgorithmType);

            return GetAlgorithmTimeCounter(algorithm)
                .Execute()
                .CreateAnimationOptimized(grid.Speed);
        }

        private static AlgorithmTimeCounter GetAlgorithmTimeCounter(IPathFindingAlgorithm algorithm) =>
            new(algorithm);
    }
}