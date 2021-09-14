import Utils from '../Utils.js';
import AnimationState from './AnimationState.js';
import ApiClient from '../ApiClient.js';
import VertexState from '../algorithm/VertexState.js';
import AlgorithmType from '../algorithm/AlgorithmType.js';
import MetricType from '../algorithm/MetricType.js';

class Animation {
    state;
    currentFrame;
    frames;
    width;
    height;
    start;
    end;
    algorithmType;
    metricType;
    speed;

    constructor(width, height) {
        this.state = AnimationState.Init;
        this.currentFrame = 0;
        this.width = width;
        this.height = height;
        this.frames = [];
        this.start = 1;
        this.end = 2;
        this.algorithmType = AlgorithmType.AStar;
        this.metricType = MetricType.Euclidean;
        this.speed = 1;
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

    GetGridWithoutPath(grid) {
        for (let i = 0; i < this.width; ++i) {
            for (let k = 0; k < this.height; ++k) {
                let val = grid[i][k];
                let isPath = val !== VertexState.Begin
                    && val !== VertexState.End
                    && val !== VertexState.Disabled;
                if (isPath)
                    grid[i][k] = VertexState.Blank;
            }
        }
        return grid;
    }

    async SetFrames(grid) {
        let result = await ApiClient.getAlgorithm(grid, this.start, this.end, this.algorithmType, this.metricType, this.speed);
        this.frames = result.frames;
        return { time: result.time, length: result.pathLength }
    }

    SetAlgorithmType = (type) => this.algorithmType = type;

    GetAlgorithmType = () => this.algorithmType;

    SetMetricType = (type) => this.metricType = type;

    GetMetricType = () => this.metricType;

    SetSpeed = (speed) => this.speed = speed;

    GetSpeed = () => this.speed;

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

    HasInitState = () => this.GetState() === AnimationState.Init;

    CanRun = () => this.HasInitState() || this.GetState() === AnimationState.Pause;

    GetState = () => this.state;

    SetState = (state) => this.state = state;

    GetStart() {
        return {
            x: this.GetX(this.start),
            y: this.GetY(this.start)
        };
    }

    GetEnd() {
        return {
            x: this.GetX(this.end),
            y: this.GetY(this.end)
        };
    }

    SetStart = (x, y) => this.start = x * this.height + y;

    SetEnd = (x, y) => this.end = x * this.height + y;

    GetX = (index) => Math.trunc(index / this.height);

    GetY = (index) => index % this.height;

}

export default Animation;
