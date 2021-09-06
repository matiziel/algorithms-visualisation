using Contracts.Services;
using Common;
using Contracts.DataTransferObjects;
using Application.Extensions;
using System;
using GraphsAlgorithms.Result;
using GraphsAlgorithms.Algorithms;
using System.Collections.Generic;

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

        public IEnumerable<TestResult> TestExecute(Grid grid, int testCount) {
            var result = new List<TestResult>();

            foreach (AlgorithmType type in
                new List<AlgorithmType> { AlgorithmType.BreadthFirstSearch, AlgorithmType.Dijkstra }) {
                double averageTime = 0.0;
                int visitedVertices = 0;

                grid.AlgorithmType = type;
                for (int i = 0; i < testCount; ++i) {
                    var algorithmResult = GetTimeFromAlgorithm(grid);
                    averageTime += algorithmResult.Item1;
                    visitedVertices = algorithmResult.Item2;
                }
                result.Add(
                    new TestResult() {
                        AlgorithmType = type,
                        AverageTime = averageTime / testCount,
                        MetricType = grid.MetricType,
                        VisitedVertices = visitedVertices
                    }
                );
            }
            foreach (MetricType type in Enum.GetValues(typeof(MetricType))) {
                double averageTime = 0.0;
                int visitedVertices = 0;
                grid.MetricType = type;

                foreach (AlgorithmType algorithmType in
                    new List<AlgorithmType> { AlgorithmType.AStar, AlgorithmType.BestFirstSearch }) {
                    grid.AlgorithmType = algorithmType;
                    for (int i = 0; i < testCount; ++i) {
                        var algorithmResult = GetTimeFromAlgorithm(grid);
                        averageTime += algorithmResult.Item1;
                        visitedVertices = algorithmResult.Item2;
                    }
                    result.Add(
                        new TestResult() {
                            AlgorithmType = algorithmType,
                            AverageTime = averageTime / testCount,
                            MetricType = type,
                            VisitedVertices = visitedVertices
                        }
                    );
                }
            }
            return result;
        }

        private (double, int) GetTimeFromAlgorithm(Grid grid) {
            var algorithm = _factory.Create(grid);
            var algorithmResult = GetAlgorithmTimeCounterDecorator(algorithm).Execute();
            return (algorithmResult.TimeSpan.TotalMilliseconds, algorithmResult.VisitedVertices);
        }

        private static AlgorithmTimeCounter GetAlgorithmTimeCounterDecorator(IPathFindingAlgorithm algorithm) =>
            new(algorithm);
    }
}