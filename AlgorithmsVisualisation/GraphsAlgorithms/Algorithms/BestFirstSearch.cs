using System;
using System.Linq;
using System.Collections.Generic;
using GraphsAlgorithms.GraphModel;
using GraphsAlgorithms.Result;
using Common;
using GraphsAlgorithms.Extensions;
using Priority_Queue;

namespace GraphsAlgorithms.Algorithms {
    public class BestFirstSearch : IPathFindingAlgorithm {

        private readonly Graph _graph;
        private readonly int _startIndex;
        private readonly int _endIndex;
        public BestFirstSearch(Graph graph, int startIndex, int endIndex) {
            _graph = graph;
            _startIndex = startIndex;
            _endIndex = endIndex;
        }
        public AlgorithmResult Execute() {
            List<Frame> frames = new();

            var cameFrom = new Dictionary<int, int>();

            var openSet = new SimplePriorityQueue<Vertex, double>();
            openSet.Enqueue(_graph[_startIndex], HeuristicFunction(_startIndex));

            while (openSet.Count > 0) {
                var current = openSet.Dequeue();

                if (current.Index == _endIndex) {
                    frames.AddPathFrame(_graph, cameFrom.ReconstructPath(_startIndex, current.Index));
                    break;
                }

                if (current.IsVisited())
                    continue;

                current.Visit();

                var frame = new Frame() {
                    FrameElements = new List<FrameElement>()
                };
                if (current.Index != _startIndex)
                    frame.AddVisitedVertexFrameElement(current);

                foreach (int neighborIndex in current.Edges.Keys) {
                    var neighbor = _graph[neighborIndex];

                    if (neighbor.IsVisited())
                        continue;

                    if (!openSet.Contains(neighbor)) {
                        openSet.Enqueue(neighbor, HeuristicFunction(neighborIndex));
                        cameFrom[neighborIndex] = current.Index;
                    }




                    if (neighborIndex != _endIndex)
                        frame.AddOpenSetVertexFrameElement(neighbor);
                }
                frames.Add(frame);
            }
            return new AlgorithmResult() {
                Frames = frames
            };
        }

        private double HeuristicFunction(int start) =>
            _graph.GetDistance(start, _endIndex);
    }
}