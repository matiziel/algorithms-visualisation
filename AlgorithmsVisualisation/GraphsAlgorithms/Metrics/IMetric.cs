using GraphsAlgorithms.GraphModel;

namespace GraphsAlgorithms.Metrics {
    public interface IMetric {

        double VertexDiagonalDistance { get; }
        double GetDistance(Vertex start, Vertex end);

    }
}