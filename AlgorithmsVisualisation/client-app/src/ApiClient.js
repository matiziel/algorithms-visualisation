import axios from 'axios';

const ApiClient = {
    apiUrl: (path) => ('/api' + path),
    getAlgorithm: async function (grid, type, startIndex, endIndex) {
        try {
            const result = await axios.post(
                this.apiUrl('/PathFindingAlgorithms/' + type),
                {
                    GridArray: grid,
                    Start: startIndex,
                    End: endIndex,
                    MetricType: 0
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