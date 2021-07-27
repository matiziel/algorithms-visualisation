using System;
using GraphsAlgorithms.GraphModel;

namespace GraphsAlgorithms.Metrics {
    public class Euclidean : IMetric {
        public double VertexDiagonalDistance => Math.Sqrt(2.0);

        public double GetDistance(Vertex start, Vertex end) =>
            Math.Sqrt(
                (end.X - start.X) * (end.X - start.X) + (end.Y - start.Y) * (end.Y - start.Y)
            );
    }
}