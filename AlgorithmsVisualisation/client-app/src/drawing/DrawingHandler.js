import DrawingState from "./DrawingState";

class DrawingHandler {
    state;
    constructor() {
        this.state = DrawingState.None;
    }
    SetState(state) {
        this.state = state;
    }
    GetState() {
        return this.state;
    }
}

export default DrawingHandler;
