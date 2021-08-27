using System;
using System.Collections.Generic;
using Contracts.DataTransferObjects;
using GraphsAlgorithms.Result;

namespace Application.Extensions {
    public static class AlgorithmResultExtensions {
        private static Animation CreateAnimation(this AlgorithmResult algorithmResult) {
            Animation animation = new();
            animation.Frames = new List<List<List<int>>>(algorithmResult.Frames.Count);

            for (int i = 0; i < algorithmResult.Frames.Count; i++) {
                animation.Frames.Add(new List<List<int>>());
                foreach (var frameElement in algorithmResult.Frames[i].FrameElements) {
                    animation.Frames[i].Add(
                        new List<int> {
                            frameElement.X, frameElement.Y, (int)frameElement.State
                        }
                    );
                }
            }
            animation.Time = algorithmResult.TimeSpan.TotalMilliseconds;
            animation.PathLength = algorithmResult.PathLength;
            return animation;
        }

        public static Animation CreateAnimationOptimized(this AlgorithmResult algorithmResult, int factor = 2) {
            if (factor == 1)
                return algorithmResult.CreateAnimation();

            Animation animation = new();
            int size = algorithmResult.Frames.Count / factor;
            animation.Frames = new List<List<List<int>>>(size) {
                new List<List<int>>()
            };

            for (int i = 0, counter = 0; i < algorithmResult.Frames.Count - 1; ++i) {
                foreach (var frameElement in algorithmResult.Frames[i].FrameElements) {
                    animation.Frames[counter].Add(
                        new List<int> {
                            frameElement.X, frameElement.Y, (int)frameElement.State
                        }
                    );
                }
                if (i % factor == 0) {
                    animation.Frames.Add(new List<List<int>>());
                    ++counter;
                }
            }
            //final path in different frame
            animation.Frames.Add(new List<List<int>>());
            foreach (var frameElement in algorithmResult.Frames[^1].FrameElements) {
                animation.Frames[^1].Add(
                    new List<int> {
                        frameElement.X, frameElement.Y, (int)frameElement.State
                    }
                );
            }

            animation.Time = algorithmResult.TimeSpan.TotalMilliseconds;
            animation.PathLength = algorithmResult.PathLength;
            return animation;
        }
    }
}