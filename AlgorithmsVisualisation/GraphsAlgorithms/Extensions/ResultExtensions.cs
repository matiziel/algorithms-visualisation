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

    }
}