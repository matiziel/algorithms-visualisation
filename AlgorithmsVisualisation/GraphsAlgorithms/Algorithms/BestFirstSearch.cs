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
            int pathLength = 0;
            int visitedVertices = 0;

            var cameFrom = new Dictionary<int, int>();


            var openSet = new FastPriorityQueue<Vertex>(_graph.Count);
            openSet.Enqueue(_graph[_startIndex], HeuristicFunction(_startIndex));

            while (openSet.Count > 0) {
                var current = openSet.Dequeue();

                if (current.Index == _endIndex) {
                    var path = cameFrom.ReconstructPath(_startIndex, current.Index);
                    pathLength = path.Count;
                    frames.AddPathFrame(_graph, path);
                    break;
                }

                if (current.IsVisited())
                    continue;

                current.Visit();
                ++visitedVertices;

                var frame = new Frame() {
                    FrameElements = new List<FrameElement>()
                };
                if (current.Index != _startIndex)
                    frame.AddVisitedVertexFrameElement(current);

                foreach (int neighborIndex in current.Edges.Keys) {
                    var neighbor = _graph[neighborIndex];

                    if (neighbor.IsVisited() || openSet.Contains(neighbor))
                        continue;

                    openSet.Enqueue(neighbor, HeuristicFunction(neighborIndex));
                    cameFrom[neighborIndex] = current.Index;

                    if (neighborIndex != _endIndex)
                        frame.AddOpenSetVertexFrameElement(neighbor);
                }
                frames.Add(frame);
            }
            return new AlgorithmResult() {
                Frames = frames,
                PathLength = pathLength,
                VisitedVertices = visitedVertices
            };
        }

        private float HeuristicFunction(int start) =>
            _graph.GetDistance(start, _endIndex);
    }
}