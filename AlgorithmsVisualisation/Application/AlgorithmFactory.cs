using System;
using Common;
using Contracts.Services;
using GraphsAlgorithms.Algorithms;
using GraphsAlgorithms.GraphModel;


namespace Application {
    public class AlgorithmFactory : IAlgorithmFactory {

        public IPathFindingAlgorithm Create(Graph graph, int start, int end, AlgorithmType type) {
            return type switch {
                AlgorithmType.AStar => new AStar(graph, start, end),
                AlgorithmType.BreadthFirstSearch => new BreadthFirstSearch(graph, start, end),
                AlgorithmType.BestFirstSearch => new BestFirstSearch(graph, start, end),
                AlgorithmType.Dijkstra => new Dijkstra(graph, start, end),
                _ => throw new ArgumentException("Given algorithm does not exist")
            };
        }
    }
}
