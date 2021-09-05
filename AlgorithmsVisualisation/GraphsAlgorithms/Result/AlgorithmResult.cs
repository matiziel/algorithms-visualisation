using System;
using System.Collections.Generic;

namespace GraphsAlgorithms.Result {
    public class AlgorithmResult {
        public List<Frame> Frames { get; set; }
        public int PathLength { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public int VisitedVertices { get; set; }

    }
}