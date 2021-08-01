import Utils from '../Utils.js';
import Animation from '../animation/Animation.js';
import AnimationState from '../animation/AnimationState.js';
import VertexState from '../animation/VertexState.js';
import AlgorithmType from '../animation/AlgorithmType.js';
import React, { useState, useEffect } from 'react';
import { Button } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import DrawingHandler from '../drawing/DrawingHandler.js';
import DrawingState from '../drawing/DrawingState.js';



const VertexColour = (state) => {
    switch (state) {
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

function Grid(props) {

    const [animation, setAnimation] = useState(new Animation(props.gridWidth, props.gridHeight));
    const [drawingHandler, setDrawingHandler] = useState(new DrawingHandler());
    const [grid, setGrid] = useState([...animation.GetEmptyGrid()]);

    const frameTime = 1;

    useEffect(() => {
        const fetchData = () => {
        };
        fetchData();
    }, [grid, animation]);

    const handleMouseDown = (e) => {
        if (animation.GetState() !== AnimationState.Init)
            return;

        let xarg = computeCoordinateX(e);
        let yarg = computeCoordinateY(e);
        let newGraph = [...grid];

        if (grid[xarg][yarg] === VertexState.Begin) {
            drawingHandler.SetState(DrawingState.MovingBegin);
        }
        else if (grid[xarg][yarg] === VertexState.End) {
            drawingHandler.SetState(DrawingState.MovingEnd);
        }
        else if (grid[xarg][yarg] === VertexState.Disabled) {
            drawingHandler.SetState(DrawingState.ErasingWalls);
            newGraph[xarg][yarg] = VertexState.Blank;
        }
        else {
            drawingHandler.SetState(DrawingState.DrawingWalls);
            newGraph[xarg][yarg] = VertexState.Disabled;
        }
        setGrid(newGraph);
    }

    const handleMouseEnter = (e) => {
        if (animation.GetState() !== AnimationState.Init)
            return;

        if (drawingHandler.GetState() === DrawingState.None)
            return;

        let xarg = computeCoordinateX(e);
        let yarg = computeCoordinateY(e);
        let newGraph = [...grid];

        if (drawingHandler.GetState() === DrawingState.MovingBegin) {

        }
        else if (drawingHandler.GetState() === DrawingState.MovingEnd) {

        }
        else if (drawingHandler.GetState() === DrawingState.ErasingWalls) {
            newGraph[xarg][yarg] = VertexState.Blank;
        }
        else if (drawingHandler.GetState() === DrawingState.DrawingWalls) {
            newGraph[xarg][yarg] = VertexState.Disabled;
        }
        setGrid(newGraph);
    }

    const handleMouseUp = (e) => {
        drawingHandler.SetState(DrawingState.None);
    }

    const computeCoordinateX = (e) => {
        return parseInt(e.target.getAttribute("x")) / props.size;
    }
    const computeCoordinateY = (e) => {
        return parseInt(e.target.getAttribute("y")) / props.size;
    }

    const runAlgorithm = async (e) => {
        if (animation.GetState() !== AnimationState.Init && animation.GetState() !== AnimationState.Pause)
            return;

        if (animation.GetState() === AnimationState.Init) {
            await animation.SetFrames(grid, AlgorithmType.AStar);
        }

        animation.SetState(AnimationState.Run);

        for (let i = animation.currentFrame; i < animation.frames.length; ++i) {
            if (animation.GetState() === AnimationState.Pause)
                return;

            setGrid(animation.Step([...grid]));

            await Utils.sleep(frameTime);
        }
        animation.SetState(AnimationState.Init);
    }

    const pauseAlgorithm = (e) => {
        animation.SetState(AnimationState.Pause);
    }

    const clearGrid = (e) => {
        animation.Reset();
        setGrid([...animation.GetEmptyGrid()]);
    }
    return (
        <div>
            <svg height={props.gridHeight * props.size} width={props.gridWidth * props.size}>
                {
                    Utils.range(0, props.gridWidth).map(xarg =>
                        Utils.range(0, props.gridHeight).map(yarg => (
                            <rect x={xarg * props.size} y={yarg * props.size} width={props.size} height={props.size}
                                fill={VertexColour(grid[xarg][yarg])} stroke="#000" strokeOpacity="0.2"
                                onMouseDown={handleMouseDown}
                                onMouseEnter={handleMouseEnter}
                                onMouseUp={handleMouseUp}
                            >
                            </rect>
                        ))
                    )
                }
            </svg>
            <br></br>
            <Button className="btn btn-primary" onClick={runAlgorithm}>Run</Button>
            <Button className="btn btn-primary" onClick={pauseAlgorithm}>Pause</Button>
            <Button className="btn btn-primary" onClick={clearGrid}>Clear</Button>
        </div>
    );
}

export default Grid;
