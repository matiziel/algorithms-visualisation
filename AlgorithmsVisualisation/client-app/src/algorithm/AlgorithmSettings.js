import AlgorithmType from "./AlgorithmType";
import MetricType from "./MetricType";

class AlgorithmSettings {
    algorithm;
    metric;

    constructor() {
        this.algorithm = AlgorithmType.AStar;
        this.metric = MetricType.Euclidean;
    }

    SetValues(algorithm, metric) {
        this.algorithm = algorithm;
        this.metric = metric;
    }

    SetMetric = (metric) => {
        let settings = new AlgorithmSettings();
        settings.SetValues(this.algorithm, metric);
        return settings;
    }

    GetMetric = () => this.metric;

    SetAlgorithm = (algorithm) => {
        let settings = new AlgorithmSettings();
        settings.SetValues(algorithm, this.metric);
        return settings;
    }

    GetAlgorithm = () => this.algorithm;

    GetCurrentMetricName = () => this.GetMetricName(this.metric);

    GetMetricName(metric) {
        switch (metric) {
            case MetricType.Euclidean:
                return "Euclidean";
            case MetricType.Manhattan:
                return "Manhattan";
            default:
                return "";
        }
    }

    GetCurrentAlgorithmName = () => this.GetAlgorithmName(this.algorithm);

    GetAlgorithmName(algorithm) {
        switch (algorithm) {
            case AlgorithmType.AStar:
                return "A-Star";
            case AlgorithmType.BreadthFirstSearch:
                return "Breadth-First-Search";
            case AlgorithmType.BestFirstSearch:
                return "Best-First-Search";
            case AlgorithmType.Dijkstra:
                return "Dijkstra";
            default:
                return "";
        }
    }
}

export default AlgorithmSettings;