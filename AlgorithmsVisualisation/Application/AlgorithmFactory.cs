using System;
using Common;
using Contracts.Services;
using GraphsAlgorithms.Algorithms;
using GraphsAlgorithms.GraphModel;


namespace Application {
    public class AlgorithmFactory : IAlgorithmFactory {
        public IPathFindingAlgorithm Create(Graph graph, AlgorithmType type) {
            throw new NotImplementedException();
        }
    }
}
