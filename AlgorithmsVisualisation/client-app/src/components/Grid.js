import Utils from '../Utils.js';
import Animation from '../animation/Animation.js';
import AnimationState from '../animation/AnimationState.js';
import VertexState from '../animation/VertexState.js';
import React, { useState, useEffect } from 'react';




const VertexColour = (state) => {
}

function Grid(props) {
    let animation = new Animation();
    animation.SetRandomFrames(15);
    const [grid, setGrid] = useState(animation.GetEmptyGrid(props.gridWidth, props.gridHeight));

    useEffect(() => {
        const fetchData = () => {
        };
        fetchData();
    }, [grid]);

    const disableVertex = (e) => {
        let xarg = parseInt(e.target.getAttribute("x")) / props.size;
        let yarg = parseInt(e.target.getAttribute("y")) / props.size;
        if (grid[xarg][yarg] === VertexState.Begin || grid[xarg][yarg] === VertexState.End)
            return;

        let newGraph = [...grid];
        if (grid[xarg][yarg] === VertexState.Disabled) {
            console.log("disabled");
            newGraph[xarg][yarg] = VertexState.Blank
            e.target.setAttribute("fill", "#ffffff");
        }
        else {
            console.log("notdisabled");
            newGraph[xarg][yarg] = VertexState.Disabled;
            e.target.setAttribute("fill", "#707070");
        }
        setGrid(newGraph);
        console.log(JSON.stringify(grid));
    }
    const runAlgorithm = (e) => {
        for (let i = 0; i < animation.frames.length; ++i) {

        }
    }

    return (
        <div>
            <svg height={props.gridHeight * props.size} width={props.gridWidth * props.size}>
                {
                    Utils.range(0, props.gridHeight).map(yarg =>
                        Utils.range(0, props.gridWidth).map(xarg => (
                            <rect x={xarg * props.size} y={yarg * props.size} width={props.size} height={props.size} fill="#ffffff" stroke="#000" stroke-opacity="0.2" onClick={disableVertex}></rect>
                        ))
                    )
                }
            </svg>
        </div>
    );
}

export default Grid;