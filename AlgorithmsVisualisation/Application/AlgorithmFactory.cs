using System;
using Common;
using Contracts.Services;
using GraphsAlgorithms.Algorithms;
using GraphsAlgorithms.GraphModel;


namespace Application {
    public class AlgorithmFactory : IAlgorithmFactory {
        public IPathFindingAlgorithm Create(Graph graph, AlgorithmType type) {
            return type switch {
                AlgorithmType.AStar => new AStar(graph),
                AlgorithmType.BreadthFirstSearch => new BreadthFirstSearch(graph),
                AlgorithmType.Dijkstra => new Dijkstra(graph),
                _ => throw new ArgumentException("Given algorithm does not exist")
            };
        }
    }
}
