import Utils from '../Utils.js';
import React, { useState, useEffect } from 'react';


const VertexState = {
    Blank: 0,
    Disabled: 1,
    Path: 2,
    Visited: 3,
    OpenSet: 4,
    Begin: 5,
    End: 6
}

function Grid(props) {
    const [grid, setGrid] = useState([]);
    useEffect(() => {
        const fetchData = () => {
            let graphArray = Array(props.gridWidth);
            for (let i = 0; i < props.gridWidth; ++i) {
                graphArray[i] = Array(props.gridHeight);
                for (let k = 0; k < props.gridHeight; ++k)
                    graphArray[i][k] = VertexState.Blank;
            }
            setGrid(graphArray);
            console.log("ELOELO");
            console.log(grid.graph);
        };
        fetchData();
    }, [props.size]);

    const disableVertex = (e) => {

        let xarg = parseInt(e.target.getAttribute("x")) / props.size;
        let yarg = parseInt(e.target.getAttribute("y")) / props.size;
        if (grid[xarg][yarg] === VertexState.Begin || grid[xarg][yarg] === VertexState.End)
            return;

        let newGraph = [...grid];
        if (grid[xarg][yarg] === VertexState.Disabled) {
            newGraph[xarg][yarg] = VertexState.Blank
            e.target.setAttribute("fill", "#ffffff");
        }
        else {
            newGraph[xarg][yarg] = VertexState.Disabled;
            e.target.setAttribute("fill", "#ffffff");
        }
        setGrid(newGraph);

        // console.log(xarg);
        // console.log(yarg);
        // console.log(e.target.style);
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