import Utils from '../Utils.js';
import AnimationState from '../animation/AnimationState.js';

class Animation {
    state;
    currentFrame;
    frames;
    width;
    height;
    constructor(width, height) {
        this.state = AnimationState.Init;
        this.currentFrame = 0;
        this.frames = Utils.getRandomFrames(15, width, height);
        this.width = width;
        this.height = height;
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
