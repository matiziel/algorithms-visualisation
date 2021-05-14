import Utils from '../Utils.js';
import AnimationState from '../animation/AnimationState.js';

class Animation {
    state;
    currentFrame;
    frames;
    constructor() {
        this.state = AnimationState.Init;
        this.currentFrame = 0;
        this.frames = [];
    }
    SetRandomFrames(amount) {
        frames = Utils.getRandomFrames();
    }
    Step() {
    }
    GetEmptyGrid(width, height) {
        return Utils.getGrid(width, height);
    }
}


export default Animation;
