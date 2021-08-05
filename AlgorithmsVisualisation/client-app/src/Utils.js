import VertexState from "./animation/VertexState";

const Utils = {
    range: (min, max) => Array.from({ length: max - min }, (_, i) => min + i),

    sleep: (ms) => {
        return new Promise(resolve => setTimeout(resolve, ms));
    }
};

export default Utils;
