import DrawingState from "./DrawingState";
import VertexState from '../animation/VertexState.js';

class DrawingHandler {
    state;
    size;
    width;
    height;
    start;
    end;
    constructor(size, width, height) {
        this.state = DrawingState.None;
        this.size = size;
        this.width = width;
        this.height = height;
        this.start = 176;
        this.end = 624;
    }
    GetStartIndex() {
        return this.start;
    }
    GetEndIndex() {
        return this.end;
    }
    SetState(state) {
        this.state = state;
    }
    GetState() {
        return this.state;
    }
    HandleMouseDown(value) {
        if (value === VertexState.Begin) {
            this.SetState(DrawingState.MovingBegin);
        }
        else if (value === VertexState.End) {
            this.SetState(DrawingState.MovingEnd);
        }
        else if (value === VertexState.Disabled) {
            this.SetState(DrawingState.ErasingWalls);
            return VertexState.Blank;
        }
        else {
            this.SetState(DrawingState.DrawingWalls);
            return VertexState.Disabled;
        }
    }
    HandleMouseEnter() {

    }
}

export default DrawingHandler;
