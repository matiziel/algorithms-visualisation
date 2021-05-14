const Utils = {
    range: (min, max) => Array.from({ length: max - min + 1 }, (_, i) => min + i),

    getGrid: (width, heigth) => {
        let grid = Array(width);
        for (let i = 0; i < width; ++i) {
            grid[i] = Array(heigth);
            for (let k = 0; k < heigth; ++k)
                grid[i][k] = 0;

        }
        return grid;
    },

    getRandomFrames: (amount, width, height) => {
        let frames = [];

        for (let i = 0; i < amount; ++i) {
            let numberOfChangedVertices = Math.floor(Math.random() * 11);
            let frame = [];
            for (let k = 0; k < numberOfChangedVertices; ++k) {
                frame.push([Math.floor(Math.random() * width), Math.floor(Math.random() * height)], 3);
            }
        }
        return frames;
    }
};


export default Utils;