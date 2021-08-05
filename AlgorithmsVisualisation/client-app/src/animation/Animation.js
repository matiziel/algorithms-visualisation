import Utils from '../Utils.js';
import AnimationState from './AnimationState.js';
import ApiClient from '../ApiClient.js';
import VertexState from './VertexState.js';

class Animation {
    state;
    currentFrame;
    frames;
    width;
    height;
    start;
    end;

    constructor(width, height) {
        this.state = AnimationState.Init;
        this.currentFrame = 0;
        this.width = width;
        this.height = height;
        this.frames = [];
        this.start = 176;
        this.end = 624;
    }

    GetEmptyGrid() {
        let grid = Array(this.width);

        let startPoint = this.GetStart();
        let endPoint = this.GetEnd();

        for (let i = 0; i < this.width; ++i) {
            grid[i] = Array(this.height);
            for (let k = 0; k < this.height; ++k) {
                if (i === startPoint.x && k === startPoint.y)
                    grid[i][k] = VertexState.Begin;
                else if (i === endPoint.x && k === endPoint.y)
                    grid[i][k] = VertexState.End;
                else
                    grid[i][k] = VertexState.Blank;
            }
        }
        return grid;
    }

    async SetFrames(grid, type) {
        this.frames = await ApiClient.getAlgorithm(grid, type, this.start, this.end);
    }

    Reset() {
        this.state = AnimationState.Init;
        this.currentFrame = 0;
    }

    Step(grid) {
        let newGrid = [...grid];
        let frame = this.frames[this.currentFrame];
        for (let i = 0; i < frame.length; ++i) {
            let x = frame[i][0];
            let y = frame[i][1];
            newGrid[x][y] = frame[i][2];
        }
        this.currentFrame += 1;
        return newGrid;
    }

    HasInitState() {
        return this.GetState() === AnimationState.Init;
    }

    CanRun() {
        return this.HasInitState() || this.GetState() === AnimationState.Pause;
    }

    GetState() {
        return this.state;
    }

    SetState(state) {
        this.state = state;
    }

    GetStart() {
        return {
            x: this.getX(this.start),
            y: this.getY(this.start)
        };
    }

    SetStart(x, y) {
        this.start = x * this.height + y;
    }

    GetEnd() {
        return {
            x: this.getX(this.end),
            y: this.getY(this.end)
        };
    }

    SetEnd(x, y) {
        this.end = x * this.height + y;
    }

    getX(index) {
        return Math.trunc(index / this.height);
    }

    getY(index) {
        return index % this.height;
    }
}

export default Animation;
