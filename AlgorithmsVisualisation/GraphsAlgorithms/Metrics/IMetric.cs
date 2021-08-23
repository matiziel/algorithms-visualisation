using GraphsAlgorithms.GraphModel;

namespace GraphsAlgorithms.Metrics {
    public interface IMetric {
        float GetDistance(Vertex start, Vertex end);

    }
}