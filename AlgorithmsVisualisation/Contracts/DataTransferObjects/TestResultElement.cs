using Common;

namespace Contracts.DataTransferObjects {

    public class TestResult {
        public AlgorithmType AlgorithmType { get; set; }
        public MetricType MetricType { get; set; }
        public double AverageTime { get; set; }
        public int VisitedVertices { get; set; }
    }
}