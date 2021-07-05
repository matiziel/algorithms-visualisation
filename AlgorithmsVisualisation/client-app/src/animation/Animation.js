import Utils from '../Utils.js';
import AnimationState from './AnimationState.js';
import ApiClient from '../ApiClient.js';

class Animation {
    state;
    currentFrame;
    frames;
    width;
    height;
    startIndex;
    endIndex;
    constructor(width, height) {
        this.state = AnimationState.Init;
        this.currentFrame = 0;
        this.frames = [];
        this.width = width;
        this.height = height;
        this.startIndex = 176;
        this.endIndex = 624;
    }
    GetEmptyGrid() {
        return Utils.getGrid(this.width, this.height);
    }
    GetState() {
        return this.state;
    }
    SetState(state) {
        this.state = state;
    }
    SetStartPoint(x, y) {
        this.startIndex = x * this.height + y;
    }
    SetStartPoint(x, y) {
        this.endIndex = x * this.height + y;
    }
    async SetFrames(grid, type) {
        this.frames = await ApiClient.getAlgorithm(grid, this.startIndex, this.endIndex, type)
    }
    SetRandomFrames(amount) {
        this.frames = Utils.getRandomFrames(amount);
    }
    Step(iteration) {
        return this.frames[iteration];
    }
    Reset() {
        this.state = AnimationState.Init;
        this.currentFrame = 0;
    }


}

export default Animation;
