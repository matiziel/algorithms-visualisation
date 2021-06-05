using System.Collections.Generic;
using GraphsAlgorithms.GraphModel;
using GraphsAlgorithms.Result;

namespace GraphsAlgorithms.Algorithms {
    public class AStar : IPathFindingAlgorithm {
        private readonly Graph _graph;
        public AStar(Graph graph) {
            _graph = graph;
        }
        public AlgorithmResult Execute() {
            throw new System.NotImplementedException();
        }
    }
}