using System;
using GraphsAlgorithms.GraphModel;

namespace GraphsAlgorithms.Metrics {
    public class Maximum : IMetric {
        public float GetDistance(Vertex start, Vertex end) =>
            Math.Max(Math.Abs(end.X - start.X), Math.Abs(end.Y - start.Y));
    }
}