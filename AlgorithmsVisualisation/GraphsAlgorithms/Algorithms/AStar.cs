using System;
using System.Collections.Generic;
using GraphsAlgorithms.GraphModel;
using GraphsAlgorithms.Result;
using Priority_Queue;

namespace GraphsAlgorithms.Algorithms {
    public class AStar : IPathFindingAlgorithm {
        private readonly Graph _graph;
        private readonly int _startIndex;
        private readonly int _endIndex;
        public AStar(Graph graph, int startIndex, int endIndex) {
            _graph = graph;
            _startIndex = startIndex;
            _endIndex = endIndex;
        }

        public AlgorithmResult Execute() {
            List<Frame> frames = new();

            var openSet = new SimplePriorityQueue<Vertex, double>();
            // openSet.Enqueue(_graph)

            return new AlgorithmResult() {
                Frames = frames
            };
        }

        private static double GetHeuristicFunctionValue(Vertex start, Vertex end) =>
            Math.Sqrt((end.X - start.X) * (end.X - start.X) + (end.Y - start.Y) * (end.Y - start.Y));

    }
}