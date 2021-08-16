using GraphsAlgorithms.GraphModel;

namespace GraphsAlgorithms.Metrics {
    public interface IMetric {

        float VertexDiagonalDistance { get; }
        float GetDistance(Vertex start, Vertex end);

    }
}