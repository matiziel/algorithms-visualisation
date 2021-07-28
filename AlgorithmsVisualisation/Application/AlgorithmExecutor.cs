using Contracts.Services;
using Common;
using Contracts.DataTransferObjects;
using Application.Extensions;
using System;
using GraphsAlgorithms.Result;

namespace Application {
    public class AlgorithmExecutor : IAlgorithmExecutor {
        private readonly IAlgorithmFactory _factory;
        private readonly IGraphBuilder _builder;
        private readonly ITimeCounter _timeCounter;

        public AlgorithmExecutor(IAlgorithmFactory factory, IGraphBuilder builder, ITimeCounter timeCounter) {
            _factory = factory;
            _builder = builder;
            _timeCounter = timeCounter;
        }

        public Animation Execute(Grid grid, AlgorithmType type) {
            var graph = _builder.BuildGraphFromGrid(grid.GridArray, grid.MetricType);
            var algorithm = _factory.Create(graph, grid.Start, grid.End, type);
            (TimeSpan timeSpan, AlgorithmResult algorithmResult) = _timeCounter.Time(
                () => algorithm.Execute()
            );
            return algorithmResult.CreateAnimation(timeSpan);
        }
    }
}