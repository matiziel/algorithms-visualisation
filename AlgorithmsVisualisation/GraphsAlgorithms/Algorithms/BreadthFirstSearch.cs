using System;
using System.Linq;
using System.Collections.Generic;
using GraphsAlgorithms.GraphModel;
using GraphsAlgorithms.Result;
using Common;

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

            var visited = new List<Vertex>();



            // var queue = new Queue<int>();
            // queue.Enqueue(startIndex);

            // while (queue.Count > 0) {
            //     var vertex = queue.Dequeue();

            //     if (visited.Contains(vertex))
            //         continue;

            //     visited.Add(vertex);

            //     foreach (var neighbor in _graph.AdjacencyList[vertex].Edges)
            //         if (!visited.Contains(neighbor.Key))
            //         {
            //             queue.Enqueue(neighbor);
            //         }
            // }


            var queue = new Queue<Vertex>();
            queue.Enqueue(_graph.AdjacencyList[startIndex]);

            while (queue.Count > 0) {
                var vertex = queue.Dequeue();

                if (visited.Any(v => v.Index == vertex.Index))
                    continue;


                visited.Add(vertex);

                if (vertex.Index != startIndex)
                    frames.Add(new Frame {
                        FrameElements = new List<FrameElement> {
                            new FrameElement() {
                                X = vertex.X, Y = vertex.Y, State = GridElementState.Visited
                            }
                        }
                    });

                var frame = new Frame() {
                    FrameElements = new List<FrameElement>()
                };
                foreach (int neighborIndex in vertex.Edges.Keys) {

                    if (neighborIndex == endIndex)
                        return new AlgorithmResult() {
                            Frames = frames
                        };

                    if (!visited.Any(v => v.Index == neighborIndex)) {
                        var tmpVertex = _graph.AdjacencyList[neighborIndex];
                        if (tmpVertex.Index != endIndex)
                            frame.FrameElements.Add(
                                new FrameElement() {
                                    X = tmpVertex.X, Y = tmpVertex.Y, State = GridElementState.OpenSet
                                }
                            );
                        queue.Enqueue(tmpVertex);
                    }
                }
                frames.Add(frame);
            }


            return new AlgorithmResult() {
                Frames = frames
            };
        }


    }
}