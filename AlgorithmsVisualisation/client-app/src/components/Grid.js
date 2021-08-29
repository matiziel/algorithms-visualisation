import Utils from '../Utils.js';
import Animation from '../animation/Animation.js';
import AnimationState from '../animation/AnimationState.js';
import AlgorithmType from '../algorithm/AlgorithmType.js';
import React, { useState, useEffect } from 'react';
import { Button, Dropdown, DropdownButton } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import DrawingHandler from '../drawing/DrawingHandler.js';
import DrawingState from '../drawing/DrawingState.js';
import Coordinates from '../drawing/Coordinates.js';
import AlgorithmSettings from '../algorithm/AlgorithmSettings.js';
import MetricType from '../algorithm/MetricType.js';
import ButtonsVisibility from './ButtonsVisibility.js';

function Grid(props) {

    const [animation, setAnimation] = useState(new Animation(props.gridWidth, props.gridHeight));
    const [drawingHandler, setDrawingHandler] = useState(new DrawingHandler(props.size));
    const [grid, setGrid] = useState([...animation.GetEmptyGrid()]);
    const [algorithmSettings, setAlgorithmSettings] = useState(new AlgorithmSettings());
    const [buttonsVisibility, setButtonsVisibility] = useState(new ButtonsVisibility());
    const [algorithmResults, setAlgorithmResults] = useState({ time: 0, length: 0 })
    const frameTime = 1;

    useEffect(() => {
        const fetchData = () => {
        };
        fetchData();
    }, [grid, animation, drawingHandler, algorithmSettings]);

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
        console.log(JSON.stringify(grid));
        console.log(animation.start);
        console.log(animation.end);

        if (animation.HasInitState()) {
            clearPath();
            let result = await animation.SetFrames(grid);
            setAlgorithmResults(result);
        }
        animation.SetState(AnimationState.Run);
        setButtonsVisibility(prev => prev.Run());

        for (let i = animation.currentFrame; i < animation.frames.length; ++i) {
            if (animation.GetState() === AnimationState.Pause)
                return;

            setGrid(animation.Step(grid));

            await Utils.sleep(frameTime);
        }
        animation.SetState(AnimationState.Init);
        setButtonsVisibility(prev => prev.Init(algorithmSettings.GetAlgorithm()));
    }

    const pauseAlgorithm = (e) => {
        animation.SetState(AnimationState.Pause);
        setButtonsVisibility(prev => prev.Pause());

    }

    const clearGrid = () => {
        animation.Reset();
        setButtonsVisibility(prev => prev.Init(algorithmSettings.GetAlgorithm()));
        setGrid(animation.GetEmptyGrid());
        setAlgorithmResults({ time: 0, length: 0 });
    }

    const clearPath = () => {
        animation.Reset();
        setButtonsVisibility(prev => prev.Init(algorithmSettings.GetAlgorithm()));
        setGrid(animation.GetGridWithoutPath([...grid]));
        setAlgorithmResults({ time: 0, length: 0 });
    }

    const handleSelectAlgorithm = (e) => {
        let value = parseInt(e);
        animation.SetAlgorithmType(value);
        setAlgorithmSettings(prev => prev.SetAlgorithm(value));
        setButtonsVisibility(prev => prev.AlgorithmChange(value));
    }

    const handleSelectMetric = (e) => {
        let value = parseInt(e);
        animation.SetMetricType(value);
        setAlgorithmSettings(prev => prev.SetMetric(value));
    }

    const handleSelectSpeed = (e) => {
        let value = parseInt(e);
        animation.SetSpeed(value);
        setAlgorithmSettings(prev => prev.SetSpeed(value));
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
            <Button className="btn btn-primary" disabled={!buttonsVisibility.GetRun()} onClick={runAlgorithm}>Run</Button>
            <Button className="btn btn-primary" disabled={!buttonsVisibility.GetPause()} onClick={pauseAlgorithm}>Pause</Button>
            <Button className="btn btn-primary" disabled={!buttonsVisibility.GetClear()} onClick={clearGrid}>Clear</Button>
            <Button className="btn btn-primary" disabled={!buttonsVisibility.GetClearPath()} onClick={clearPath}>Clear Path</Button>

            <br></br>
            <label>Algorithm:</label>
            <DropdownButton
                title={algorithmSettings.GetCurrentAlgorithmName()}
                disabled={!buttonsVisibility.GetAlgorithmSettings()}
                id="dropdown-menu-align-right"
                onSelect={handleSelectAlgorithm}>
                {
                    Object.values(AlgorithmType).map(item =>
                        <Dropdown.Item eventKey={item}>{algorithmSettings.GetAlgorithmName(item)}</Dropdown.Item>
                    )
                }
            </DropdownButton>

            <label>Heuristic:</label>
            <DropdownButton
                title={algorithmSettings.GetCurrentMetricName()}
                disabled={!buttonsVisibility.GetHeuristicSettings()}
                id="dropdown-menu-align-right"
                onSelect={handleSelectMetric}>
                {
                    Object.values(MetricType).map(item =>
                        <Dropdown.Item eventKey={item}>{algorithmSettings.GetMetricName(item)}</Dropdown.Item>
                    )
                }
            </DropdownButton>

            <label>Speed:</label>
            <DropdownButton
                title={algorithmSettings.GetCurrentSpeedName()}
                disabled={!buttonsVisibility.GetAlgorithmSettings()}
                id="dropdown-menu-align-right"
                onSelect={handleSelectSpeed}>
                {
                    [1, 2, 4, 8].map(item =>
                        <Dropdown.Item eventKey={item}>{algorithmSettings.GetSpeedName(item)}</Dropdown.Item>
                    )
                }
            </DropdownButton>

            <label>Time: {algorithmResults.time}ms</label>
            <br></br>
            <label>Path length: {algorithmResults.length}</label>
        </div>
    );
}

export default Grid;
