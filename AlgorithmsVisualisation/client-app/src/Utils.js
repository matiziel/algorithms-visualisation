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
    }
};


export default Utils;