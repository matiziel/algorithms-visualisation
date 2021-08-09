import AlgorithmType from "../algorithm/AlgorithmType";

class ButtonsVisibility {
    run;
    pause;
    clear;
    clearPath;
    algorithmSettings;

    constructor() {
        this.run = true;
        this.pause = false;
        this.clear = true;
        this.clearPath = true;
        this.algorithmSettings = true;
        this.heuristicSettings = true;
    }

    Run() {
        let visibility = new ButtonsVisibility();
        visibility.run = false;
        visibility.pause = true;
        visibility.clear = false;
        visibility.clearPath = false;
        visibility.algorithmSettings = false;
        visibility.heuristicSettings = false;
        return visibility;
    }

    Pause() {
        let visibility = new ButtonsVisibility();
        visibility.run = true;
        visibility.pause = false;
        visibility.clear = true;
        visibility.clearPath = true;
        visibility.algorithmSettings = false;
        visibility.heuristicSettings = false;
        return visibility;
    }

    Init(algorithmType) {
        let visibility = new ButtonsVisibility();
        visibility.run = true;
        visibility.pause = false;
        visibility.clear = true;
        visibility.clearPath = true;
        visibility.algorithmSettings = true;
        visibility.heuristicSettings = this.IsHeuristic(algorithmType)
        return visibility;
    }

    AlgorithmChange(algorithmType) {
        let visibility = new ButtonsVisibility();
        visibility.run = this.run;
        visibility.pause = this.pause;
        visibility.clear = this.clear;
        visibility.clearPath = this.clearPath;
        visibility.algorithmSettings = this.algorithmSettings;
        visibility.heuristicSettings = this.IsHeuristic(algorithmType);
        return visibility;
    }

    GetRun = () => this.run;

    GetPause = () => this.pause;

    GetClear = () => this.clear;

    GetClearPath = () => this.clearPath;

    GetAlgorithmSettings = () => this.algorithmSettings;

    GetHeuristicSettings = () => this.heuristicSettings;

    IsHeuristic = (algorithmType) =>
        algorithmType === AlgorithmType.AStar || algorithmType === AlgorithmType.BestFirstSearch;


}

export default ButtonsVisibility;