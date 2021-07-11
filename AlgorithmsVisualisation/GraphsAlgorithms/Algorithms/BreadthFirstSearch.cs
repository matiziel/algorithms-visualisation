using System;
using System.Linq;
using System.Collections.Generic;
using GraphsAlgorithms.GraphModel;
using GraphsAlgorithms.Result;
using Common;
using GraphsAlgorithms.Extensions;

namespace GraphsAlgorithms.Algorithms {
    public class BreadthFirstSearch : IPathFindingAlgorithm {
        private readonly Graph _graph;
        private readonly int _startIndex;
        private readonly int _endIndex;
        public BreadthFirstSearch(Graph graph, int startIndex, int endIndex) {
            _graph = graph;
            _startIndex = startIndex;
            _endIndex = endIndex;
        }

        public AlgorithmResult Execute() {
            List<Frame> frames = new();

            var queue = new Queue<Vertex>();

            _graph[_startIndex].Visit();
            queue.Enqueue(_graph[_startIndex]);

            var cameFrom = new Dictionary<int, int>();

            while (queue.Count > 0) {
                var current = queue.Dequeue();

                if (current.Index == _endIndex) {
                    frames.AddPathFrame(_graph, cameFrom.ReconstructPath(_startIndex, current.Index));
                    break;
                }



                var frame = new Frame() {
                    FrameElements = new List<FrameElement>()
                };
                if (current.Index != _startIndex)
                    frame.AddVisitedVertexFrameElement(current);

                foreach (int neighborIndex in current.Edges.Keys) {
                    var neighbor = _graph[neighborIndex];

                    if (_graph[neighborIndex].IsVisited())
                        continue;

                    if (neighborIndex != _endIndex)
                        frame.AddOpenSetVertexFrameElement(neighbor);

                    cameFrom[neighborIndex] = current.Index;
                    neighbor.Visit();
                    queue.Enqueue(neighbor);
                }
                frames.Add(frame);
            }


            return new AlgorithmResult() {
                Frames = frames
            };
        }


    }
}