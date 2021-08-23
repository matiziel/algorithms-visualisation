using System;
using GraphsAlgorithms.GraphModel;

namespace GraphsAlgorithms.Metrics {
    public class Manhattan : IMetric {
        public float GetDistance(Vertex start, Vertex end) =>
            Math.Abs(end.X - start.X) + Math.Abs(end.Y - start.Y);
    }
}