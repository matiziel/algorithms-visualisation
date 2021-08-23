using System;
using GraphsAlgorithms.GraphModel;

namespace GraphsAlgorithms.Metrics {
    public class Euclidean : IMetric {
        public float GetDistance(Vertex start, Vertex end) =>
            (float)Math.Sqrt(
                (end.X - start.X) * (end.X - start.X) + (end.Y - start.Y) * (end.Y - start.Y)
            );
    }
}