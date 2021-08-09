import DrawingState from "./DrawingState";
import VertexState from '../algorithm/VertexState.js';

class DrawingHandler {
    state;
    size;
    constructor(size) {
        this.state = DrawingState.None;
        this.size = size;
    }
    GetStartIndex = () => this.start;

    GetEndIndex = () => this.end;

    SetState = (state) => this.state = state;

    GetState = () => this.state;

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
    HandleMouseEnter(animation, grid, xarg, yarg) {
        let newGrid = [...grid];

        if (this.state === DrawingState.MovingBegin) {

            let oldStart = animation.GetStart();

            if (newGrid[xarg][yarg] !== VertexState.End && newGrid[xarg][yarg] !== VertexState.Disabled) {
                newGrid[oldStart.x][oldStart.y] = VertexState.Blank;
                newGrid[xarg][yarg] = VertexState.Begin;
                animation.SetStart(xarg, yarg);
            }
        }
        else if (this.state === DrawingState.MovingEnd && newGrid[xarg][yarg] !== VertexState.Disabled) {
            let oldEnd = animation.GetEnd();

            if (newGrid[xarg][yarg] !== VertexState.Begin) {
                newGrid[oldEnd.x][oldEnd.y] = VertexState.Blank;
                newGrid[xarg][yarg] = VertexState.End;
                animation.SetEnd(xarg, yarg);
            }
        }
        else if (this.state === DrawingState.ErasingWalls) {
            if (newGrid[xarg][yarg] !== VertexState.Begin && newGrid[xarg][yarg] !== VertexState.End)
                newGrid[xarg][yarg] = VertexState.Blank;
        }
        else if (this.state === DrawingState.DrawingWalls) {
            if (newGrid[xarg][yarg] !== VertexState.Begin && newGrid[xarg][yarg] !== VertexState.End)
                newGrid[xarg][yarg] = VertexState.Disabled;
        }
        return newGrid;
    }

    VertexColour(vertexState) {
        switch (vertexState) {
            case VertexState.Blank:
                return "#ffffff";
            case VertexState.Disabled:
                return "#707070";
            case VertexState.Path:
                return "#74c1ec";
            case VertexState.OpenSet:
                return "#77cf56";
            case VertexState.Visited:
                return "#cef0da";
            case VertexState.Begin:
                return "#3338ff";
            case VertexState.End:
                return "#e24e54";
            default:
                return "#ffffff";
        }
    }

    ComputeCoordinate = (name, e) => parseInt(e.target.getAttribute(name)) / this.size;
}
export default DrawingHandler;
