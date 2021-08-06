import axios from 'axios';

const ApiClient = {
    apiUrl: (path) => ('/api' + path),
    getAlgorithm: async function (grid, startIndex, endIndex, algorithmType, metricType) {
        try {
            const result = await axios.post(
                this.apiUrl('/PathFindingAlgorithms/' + algorithmType),
                {
                    GridArray: grid,
                    Start: startIndex,
                    End: endIndex,
                    MetricType: metricType
                }
            );
            return result.data.frames;

        }
        catch (error) {
            return [];
        }
    },
};

export default ApiClient;