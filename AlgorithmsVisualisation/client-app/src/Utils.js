import VertexState from "./animation/VertexState";

const Utils = {
    range: (min, max) => Array.from({ length: max - min }, (_, i) => min + i),

    getGrid: (width, heigth) => {
        let grid = Array(width);
        for (let i = 0; i < width; ++i) {
            grid[i] = Array(heigth);
            for (let k = 0; k < heigth; ++k) {
                if (i === 5 && k === 16)
                    grid[i][k] = VertexState.Begin;
                else if (i === 19 && k === 16)
                    grid[i][k] = VertexState.End;
                else
                    grid[i][k] = VertexState.Blank;
            }

        }
        return grid;
    },

    getRandomFrames: (amount, width, height) => {
        let frames = [];

        for (let i = 0; i < amount; ++i) {
            let numberOfChangedVertices = Math.floor(Math.random() * 11);
            let frame = [];
            for (let k = 0; k < numberOfChangedVertices; ++k) {
                frame.push([Math.floor(Math.random() * width), Math.floor(Math.random() * height), 3]);
            }
            frames.push(frame);
        }
        return frames;

    },
    sleep: (ms) => {
        return new Promise(resolve => setTimeout(resolve, ms));
    }
};

export default Utils;
