using System;
using Common;
using Application;
using Xunit;


namespace UnitTests {
    public class AlgorithmExecutionTest {

        [Theory]
        [InlineData(AlgorithmType.AStar, MetricType.Euclidean, 6)]
        [InlineData(AlgorithmType.AStar, MetricType.Manhattan, 6)]
        [InlineData(AlgorithmType.AStar, MetricType.Maximum, 6)]
        [InlineData(AlgorithmType.BreadthFirstSearch, MetricType.Euclidean, 6)]
        [InlineData(AlgorithmType.BestFirstSearch, MetricType.Euclidean, 6)]
        [InlineData(AlgorithmType.BestFirstSearch, MetricType.Manhattan, 6)]
        [InlineData(AlgorithmType.BestFirstSearch, MetricType.Maximum, 6)]
        [InlineData(AlgorithmType.Dijkstra, MetricType.Euclidean, 6)]
        public void Case0(AlgorithmType algorithm, MetricType metric, int length) {
            var grid = TestGridBuilder.GraphType_0(algorithm, metric);
            var executor = new AlgorithmExecutor(new AlgorithmFactory(new GraphBuilder()));
            var result = executor.Execute(grid);
            Assert.Equal(length, result.PathLength);
        }

        [Theory]
        [InlineData(AlgorithmType.AStar, MetricType.Euclidean, 10)]
        [InlineData(AlgorithmType.AStar, MetricType.Manhattan, 10)]
        [InlineData(AlgorithmType.AStar, MetricType.Maximum, 10)]
        [InlineData(AlgorithmType.BreadthFirstSearch, MetricType.Euclidean, 10)]
        [InlineData(AlgorithmType.BestFirstSearch, MetricType.Euclidean, 10)]
        [InlineData(AlgorithmType.BestFirstSearch, MetricType.Manhattan, 10)]
        [InlineData(AlgorithmType.BestFirstSearch, MetricType.Maximum, 10)]
        [InlineData(AlgorithmType.Dijkstra, MetricType.Euclidean, 10)]
        public void Case1(AlgorithmType algorithm, MetricType metric, int length) {
            var grid = TestGridBuilder.GraphType_1(algorithm, metric);
            var executor = new AlgorithmExecutor(new AlgorithmFactory(new GraphBuilder()));
            var result = executor.Execute(grid);
            Assert.Equal(length, result.PathLength);
        }

        [Theory]
        [InlineData(AlgorithmType.AStar, MetricType.Euclidean, 14)]
        [InlineData(AlgorithmType.AStar, MetricType.Manhattan, 14)]
        [InlineData(AlgorithmType.AStar, MetricType.Maximum, 14)]
        [InlineData(AlgorithmType.BreadthFirstSearch, MetricType.Euclidean, 14)]
        [InlineData(AlgorithmType.BestFirstSearch, MetricType.Euclidean, 14)]
        [InlineData(AlgorithmType.BestFirstSearch, MetricType.Manhattan, 14)]
        [InlineData(AlgorithmType.BestFirstSearch, MetricType.Maximum, 14)]
        [InlineData(AlgorithmType.Dijkstra, MetricType.Euclidean, 14)]
        public void Case2(AlgorithmType algorithm, MetricType metric, int length) {
            var grid = TestGridBuilder.GraphType_2(algorithm, metric);
            var executor = new AlgorithmExecutor(new AlgorithmFactory(new GraphBuilder()));
            var result = executor.Execute(grid);
            Assert.Equal(length, result.PathLength);
        }

        [Theory]
        [InlineData(AlgorithmType.AStar, MetricType.Euclidean, 19)]
        [InlineData(AlgorithmType.AStar, MetricType.Manhattan, 19)]
        [InlineData(AlgorithmType.AStar, MetricType.Maximum, 19)]
        [InlineData(AlgorithmType.BreadthFirstSearch, MetricType.Euclidean, 19)]
        [InlineData(AlgorithmType.BestFirstSearch, MetricType.Euclidean, 19)]
        [InlineData(AlgorithmType.BestFirstSearch, MetricType.Manhattan, 19)]
        [InlineData(AlgorithmType.BestFirstSearch, MetricType.Maximum, 19)]
        [InlineData(AlgorithmType.Dijkstra, MetricType.Euclidean, 19)]
        public void Case3(AlgorithmType algorithm, MetricType metric, int length) {
            var grid = TestGridBuilder.GraphType_3(algorithm, metric);
            var executor = new AlgorithmExecutor(new AlgorithmFactory(new GraphBuilder()));
            var result = executor.Execute(grid);
            Assert.Equal(length, result.PathLength);
        }
    }
}
