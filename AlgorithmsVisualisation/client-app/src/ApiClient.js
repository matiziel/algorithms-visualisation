import axios from 'axios';

const ApiClient = {
    apiUrl: (path) => ('/api' + path),
    getAlgorithm: async function (grid, startIndex, endIndex, algorithmType, metricType, speed) {
        try {
            const result = await axios.post(
                this.apiUrl('/PathFindingAlgorithms'),
                {
                    GridArray: grid,
                    Start: startIndex,
                    End: endIndex,
                    AlgorithmType: algorithmType,
                    MetricType: metricType,
                    Speed: speed
                }
            );
            return result.data;
        }
        catch (error) {
            return [];
        }
    },
};
export default ApiClient;