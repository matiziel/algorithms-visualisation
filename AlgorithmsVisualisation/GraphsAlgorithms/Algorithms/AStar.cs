using System;
using System.Collections.Generic;
using GraphsAlgorithms.GraphModel;
using GraphsAlgorithms.Result;

namespace GraphsAlgorithms.Algorithms {
    public class AStar : IPathFindingAlgorithm {
        private readonly Graph _graph;
        private readonly int startIndex = 176;
        private readonly int endIndex = 624;
        public AStar(Graph graph) {
            _graph = graph;
        }

        public AlgorithmResult Execute() {
            throw new System.NotImplementedException();
        }

        private static double GetHeuristicFunctionValue(Vertex start, Vertex end) =>
            Math.Sqrt((end.X - start.X) * (end.X - start.X) + (end.Y - start.Y) * (end.Y - start.Y));

    }
}