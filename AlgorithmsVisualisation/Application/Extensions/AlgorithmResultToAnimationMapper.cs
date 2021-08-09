using System;
using System.Collections.Generic;
using Contracts.DataTransferObjects;
using GraphsAlgorithms.Result;

namespace Application.Extensions {
    public static class AlgorithmResultExtensions {
        public static Animation CreateAnimation(this AlgorithmResult algorithmResult) {
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
            animation.Time = algorithmResult.TimeSpan.TotalSeconds;
            animation.PathLength = algorithmResult.PathLength;
            return animation;
        }

    }
}