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
import Coordinates from '../drawing/Coordinates.js';

function Grid(props) {

    const [animation, setAnimation] = useState(new Animation(props.gridWidth, props.gridHeight));
    const [drawingHandler, setDrawingHandler] = useState(new DrawingHandler(props.size));
    const [grid, setGrid] = useState([...animation.GetEmptyGrid()]);

    const frameTime = 1;

    useEffect(() => {
        const fetchData = () => {
        };
        fetchData();
    }, [grid, animation]);

    const handleMouseDown = (e) => {
        if (!animation.HasInitState())
            return;

        let xarg = drawingHandler.ComputeCoordinate(Coordinates.X, e);
        let yarg = drawingHandler.ComputeCoordinate(Coordinates.Y, e);

        let newGraph = [...grid];

        newGraph[xarg][yarg] = drawingHandler.HandleMouseDown(grid[xarg][yarg]);

        setGrid(newGraph);
    }

    const handleMouseEnter = (e) => {
        if (!animation.HasInitState())
            return;

        if (drawingHandler.GetState() === DrawingState.None)
            return;

        let xarg = drawingHandler.ComputeCoordinate(Coordinates.X, e);
        let yarg = drawingHandler.ComputeCoordinate(Coordinates.Y, e);

        let newGrid = drawingHandler.HandleMouseEnter(animation, grid, xarg, yarg);

        setGrid(newGrid);
    }

    const handleMouseUp = (e) => {
        drawingHandler.SetState(DrawingState.None);
    }

    const runAlgorithm = async () => {
        if (!animation.CanRun())
            return;

        if (animation.HasInitState()) {
            await animation.SetFrames(grid, AlgorithmType.AStar);
        }
        animation.SetState(AnimationState.Run);

        for (let i = animation.currentFrame; i < animation.frames.length; ++i) {
            if (animation.GetState() === AnimationState.Pause)
                return;

            setGrid(animation.Step(grid));

            await Utils.sleep(frameTime);
        }
        animation.SetState(AnimationState.Init);
    }

    const pauseAlgorithm = (e) => {
        animation.SetState(AnimationState.Pause);
    }

    const clearGrid = (e) => {
        animation.Reset();
        setGrid([...animation.GetEmptyGrid(props.gridWidth, props.gridHeight)]);
    }

    return (
        <div>
            <svg height={props.gridHeight * props.size} width={props.gridWidth * props.size}>
                {
                    Utils.range(0, props.gridWidth).map(xarg =>
                        Utils.range(0, props.gridHeight).map(yarg => (
                            <rect x={xarg * props.size} y={yarg * props.size} width={props.size} height={props.size}
                                fill={drawingHandler.VertexColour(grid[xarg][yarg])} stroke="#000" strokeOpacity="0.2"
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
