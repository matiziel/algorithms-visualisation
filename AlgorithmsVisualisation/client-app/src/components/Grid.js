import Utils from '../Utils.js';
import Animation from '../animation/Animation.js';
import AnimationState from '../animation/AnimationState.js';
import VertexState from '../animation/VertexState.js';
import AlgorithmType from '../animation/AlgorithmType.js';
import React, { useState, useEffect } from 'react';
import { Button } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';




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

    const [animation, setAnimation] = useState(new Animation(props.gridWidth, props.gridHeight))
    const [grid, setGrid] = useState([...animation.GetEmptyGrid()]);

    let frameTime = 1;

    useEffect(() => {
        const fetchData = () => {
        };
        fetchData();
    }, [grid, animation]);

    const disableVertex = (e) => {
        if (animation.GetState() !== AnimationState.Init)
            return;

        let xarg = parseInt(e.target.getAttribute("x")) / props.size;
        let yarg = parseInt(e.target.getAttribute("y")) / props.size;
        if (grid[xarg][yarg] === VertexState.Begin || grid[xarg][yarg] === VertexState.End)
            return;

        let newGraph = [...grid];
        if (grid[xarg][yarg] === VertexState.Disabled)
            newGraph[xarg][yarg] = VertexState.Blank
        else
            newGraph[xarg][yarg] = VertexState.Disabled;

        setGrid(newGraph);
    }

    const runAlgorithm = async (e) => {
        if (animation.GetState() !== AnimationState.Init && animation.GetState() !== AnimationState.Pause)
            return;

        if (animation.GetState() === AnimationState.Init) {
            await animation.SetFrames(grid, AlgorithmType.BestFirstSearch);
            console.log(animation.frames);
        }


        animation.SetState(AnimationState.Run);

        for (let i = animation.currentFrame; i < animation.frames.length; ++i) {

            if (animation.GetState() === AnimationState.Pause)
                return;
            step(animation.frames[i]);

            await Utils.sleep(frameTime);
        }
        animation.SetState(AnimationState.Init);

    }

    const step = (frame) => {
        let newGrid = [...grid];
        for (let i = 0; i < frame.length; ++i) {
            let x = frame[i][0];
            let y = frame[i][1];
            newGrid[x][y] = frame[i][2];
        }
        setGrid(newGrid);
        animation.currentFrame += 1;
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
                                fill={VertexColour(grid[xarg][yarg])} stroke="#000" strokeOpacity="0.2" onClick={disableVertex}>
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
