import AlgorithmType from "./AlgorithmType";
import MetricType from "./MetricType";

class AlgorithmSettings {
    type;
    metric;
    constructor() {
        this.type = AlgorithmType.AStar;
        this.metric = MetricType.Euclidean;
    }

    SetMetric = (metric) => this.metric = metric;

    GetMetric = () => this.metric;
}

export default AlgorithmSettings;