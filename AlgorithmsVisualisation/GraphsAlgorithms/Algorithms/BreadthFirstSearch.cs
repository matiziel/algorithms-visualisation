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
            queue.Enqueue(_graph[_startIndex]);

            while (queue.Count > 0) {
                var vertex = queue.Dequeue();

                if (vertex.IsVisited())
                    continue;

                vertex.Visit();

                if (vertex.Index != _startIndex)
                    frames.AddVisitedVertexFrame(vertex);

                var frame = new Frame() {
                    FrameElements = new List<FrameElement>()
                };

                foreach (int neighborIndex in vertex.Edges.Keys) {

                    if (neighborIndex == _endIndex)
                        return new AlgorithmResult() {
                            Frames = frames
                        };

                    if (_graph[neighborIndex].IsVisited())
                        continue;

                    var tmpVertex = _graph[neighborIndex];

                    frame.AddOpenSetVertexFrameElement(tmpVertex);

                    queue.Enqueue(tmpVertex);

                }
                frames.Add(frame);
            }


            return new AlgorithmResult() {
                Frames = frames
            };
        }


    }
}