using System.Collections.Generic;
using Common;
using GraphsAlgorithms.GraphModel;
using GraphsAlgorithms.Result;

namespace GraphsAlgorithms.Extensions {
    public static class ResultExtensions {
        public static void AddVisitedVertexFrame(this List<Frame> frames, Vertex vertex) {
            frames.Add(new Frame {
                FrameElements = new List<FrameElement> {
                    new FrameElement() {
                        X = vertex.X, Y = vertex.Y, State = GridElementState.Visited
                    }
                }
            });
        }

        public static void AddOpenSetVertexFrameElement(this Frame frame, Vertex vertex) {
            frame.FrameElements.Add(
                new FrameElement() {
                    X = vertex.X, Y = vertex.Y, State = GridElementState.OpenSet
                }
            );
        }

        public static void AddPathFrame(this List<Frame> frames, Graph graph, List<int> path) {
            var frame = new Frame {
                FrameElements = new()
            };
            foreach (var index in path) {
                frame.FrameElements.Add(
                    new FrameElement() {
                        X = graph[index].X, Y = graph[index].Y, State = GridElementState.Path
                    }
                );
            }
            frames.Add(frame);
        }

        public static List<int> ReconstructPath(this Dictionary<int, int> cameFrom, int start, int current) {
            List<int> totalPath = new();

            while (cameFrom.ContainsKey(current)) {
                current = cameFrom[current];
                if (current != start)
                    totalPath.Insert(0, current);
            }
            return totalPath;
        }

    }
}