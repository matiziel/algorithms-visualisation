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

                grid.AlgorithmType = type;
                result.Add(GetTestResult(grid, testCount));
            }
            foreach (AlgorithmType algorithmType in
                    new List<AlgorithmType> { AlgorithmType.AStar, AlgorithmType.BestFirstSearch }) {

                grid.AlgorithmType = algorithmType;
                foreach (MetricType type in Enum.GetValues(typeof(MetricType))) {
                    grid.MetricType = type;
                    result.Add(GetTestResult(grid, testCount));
                }
            }

            return result;
        }

        private TestResult GetTestResult(Grid grid, int testCount) {
            double averageTime = 0.0;
            int visitedVertices = 0;
            int pathLength = 0;
            for (int i = 0; i < testCount; ++i) {
                var algorithm = _factory.Create(grid);
                var algorithmResult = GetAlgorithmTimeCounterDecorator(algorithm).Execute();
                averageTime += algorithmResult.TimeSpan.TotalMilliseconds;
                visitedVertices = algorithmResult.VisitedVertices;
                pathLength = algorithmResult.PathLength;
            }
            return new TestResult() {
                AlgorithmType = grid.AlgorithmType,
                AverageTime = averageTime / testCount,
                MetricType = grid.MetricType,
                VisitedVertices = visitedVertices,
                PathLength = pathLength
            };

        }

        private static AlgorithmTimeCounter GetAlgorithmTimeCounterDecorator(IPathFindingAlgorithm algorithm) =>
            new(algorithm);
    }
}