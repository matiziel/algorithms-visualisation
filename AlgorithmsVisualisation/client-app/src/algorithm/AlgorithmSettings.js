import AlgorithmType from "./AlgorithmType";
import MetricType from "./MetricType";

class AlgorithmSettings {
    algorithm;
    metric;
    speed;

    constructor() {
        this.algorithm = AlgorithmType.AStar;
        this.metric = MetricType.Euclidean;
        this.speed = 1;
    }

    SetValues(algorithm, metric, speed) {
        this.algorithm = algorithm;
        this.metric = metric;
        this.speed = speed;
    }

    SetMetric = (metric) => {
        let settings = new AlgorithmSettings();
        settings.SetValues(this.algorithm, metric, this.speed);
        return settings;
    }

    GetMetric = () => this.metric;

    SetAlgorithm = (algorithm) => {
        let settings = new AlgorithmSettings();
        settings.SetValues(algorithm, this.metric, this.speed);
        return settings;
    }

    GetAlgorithm = () => this.algorithm;

    SetSpeed = (speed) => {
        let settings = new AlgorithmSettings();
        settings.SetValues(this.algorithm, this.metric, speed);
        return settings;
    }

    GetSpeed = () => this.speed;

    GetCurrentMetricName = () => this.GetMetricName(this.metric);

    GetMetricName(metric) {
        switch (metric) {
            case MetricType.Euclidean:
                return "Euclidean";
            case MetricType.Manhattan:
                return "Manhattan";
            case MetricType.Maximum:
                return "Maximum";
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

    GetCurrentSpeedName = () => this.GetSpeedName(this.speed);

    GetSpeedName(speed) {
        return speed + "x";
    }
}

export default AlgorithmSettings;