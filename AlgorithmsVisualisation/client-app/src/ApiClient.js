import axios from 'axios';

const ApiClient = {
    apiUrl: (path) => ('/api' + path),
    getAlgorithm: async function (grid, type) {
        try {
            const result = await axios.post(this.apiUrl('/PathFindingAlgorithms/' + type), { GridArray: grid });
            console.log(result.data.frames);
            return result.data.frames;

        }
        catch (error) {
            return [];
        }
    },
};

export default ApiClient;