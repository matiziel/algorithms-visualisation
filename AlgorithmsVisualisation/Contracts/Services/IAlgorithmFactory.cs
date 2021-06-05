using System.Collections.Generic;
using Common;
using GraphsAlgorithms.Algorithms;
using GraphsAlgorithms.GraphModel;

namespace Contracts.Services {
    public interface IAlgorithmFactory {
        public IPathFindingAlgorithm Create(Graph graph, AlgorithmType type);
    }
}