import Utils from '../Utils.js';
import AnimationState from './AnimationState.js';
import ApiClient from '../ApiClient.js';

class Animation {
    state;
    currentFrame;
    frames;
    constructor() {
        this.state = AnimationState.Init;
        this.currentFrame = 0;
        this.frames = [];
    }
    GetEmptyGrid(width, height) {
        return Utils.getGrid(width, height);
    }
    GetState() {
        return this.state;
    }
    SetState(state) {
        this.state = state;
    }
    async SetFrames(grid, type, startIndex, endIndex) {
        this.frames = await ApiClient.getAlgorithm(grid, startIndex, endIndex, type)
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
}

export default Animation;
