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
        private readonly int startIndex = 176;
        private readonly int endIndex = 624;
        public BreadthFirstSearch(Graph graph) {
            _graph = graph;
        }

        public AlgorithmResult Execute() {
            List<Frame> frames = new();


            var queue = new Queue<Vertex>();
            queue.Enqueue(_graph.AdjacencyList[startIndex]);

            while (queue.Count > 0) {
                var vertex = queue.Dequeue();

                if (vertex.IsVisited())
                    continue;

                vertex.Visit();

                if (vertex.Index != startIndex)
                    frames.AddVisitedVertexFrame(vertex);

                var frame = new Frame() {
                    FrameElements = new List<FrameElement>()
                };

                foreach (int neighborIndex in vertex.Edges.Keys) {

                    if (neighborIndex == endIndex)
                        return new AlgorithmResult() {
                            Frames = frames
                        };

                    if (_graph.AdjacencyList[neighborIndex].IsVisited())
                        continue;

                    var tmpVertex = _graph.AdjacencyList[neighborIndex];

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