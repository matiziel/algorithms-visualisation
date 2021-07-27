using System;
using GraphsAlgorithms.GraphModel;

namespace GraphsAlgorithms.Metrics {
    public class Manhattan : IMetric {
        public double VertexDiagonalDistance => 2.0;

        public double GetDistance(Vertex start, Vertex end) =>
            Math.Abs(end.X - start.X) + Math.Abs(end.Y - start.Y);
    }
}