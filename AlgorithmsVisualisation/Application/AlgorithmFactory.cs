using System;
using Common;
using Contracts.DataTransferObjects;
using Contracts.Services;
using GraphsAlgorithms.Algorithms;
using GraphsAlgorithms.GraphModel;


namespace Application {
    public class AlgorithmFactory : IAlgorithmFactory {
        private readonly IGraphBuilder _builder;
        public AlgorithmFactory(IGraphBuilder builder) =>
            _builder = builder;

        public IPathFindingAlgorithm Create(Grid grid) {
            var graph = _builder.BuildGraphFromGrid(grid.GridArray, grid.MetricType);

            return grid.AlgorithmType switch {
                AlgorithmType.AStar => new AStar(graph, grid.Start, grid.End),
                AlgorithmType.BreadthFirstSearch => new BreadthFirstSearch(graph, grid.Start, grid.End),
                AlgorithmType.BestFirstSearch => new BestFirstSearch(graph, grid.Start, grid.End),
                AlgorithmType.Dijkstra => new Dijkstra(graph, grid.Start, grid.End),
                _ => throw new ArgumentException("Given algorithm does not exist")
            };
        }
    }
}
