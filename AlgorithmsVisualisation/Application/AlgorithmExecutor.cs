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

        public AlgorithmExecutor(IAlgorithmFactory factory) =>
            _factory = factory;


        public Animation Execute(Grid grid) {
            var algorithm = _factory.Create(grid);

            return GetAlgorithmTimeCounterDecorator(algorithm)
                .Execute()
                .CreateAnimationOptimized(grid.Speed);
        }

        public TestResult TestExecute(Grid grid, int testCount) {
            double averageTime = 0.0;

            for (int i = 0; i < testCount; ++i) {
                var algorithm = _factory.Create(grid);
                var algorithmResult = GetAlgorithmTimeCounterDecorator(algorithm).Execute();
                averageTime += algorithmResult.TimeSpan.TotalMilliseconds;
            }

            return new TestResult() {
                AverageTime = averageTime / testCount
            };
        }

        private static AlgorithmTimeCounter GetAlgorithmTimeCounterDecorator(IPathFindingAlgorithm algorithm) =>
            new(algorithm);
    }
}