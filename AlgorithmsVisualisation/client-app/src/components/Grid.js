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
    const [grid, setGrid] = useState(Utils.getGrid(props.gridWidth, props.gridHeight));

    useEffect(() => {
        const fetchData = () => {
            // console.log(grid);
            console.log("elo");
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