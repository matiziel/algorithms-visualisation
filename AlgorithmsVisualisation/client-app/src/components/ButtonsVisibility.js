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
    }

    Run() {
        let visibility = new ButtonsVisibility();
        visibility.run = false;
        visibility.pause = true;
        visibility.clear = false;
        visibility.clearPath = false;
        visibility.algorithmSettings = false;
        return visibility;
    }

    Pause() {
        let visibility = new ButtonsVisibility();
        visibility.run = true;
        visibility.pause = false;
        visibility.clear = true;
        visibility.clearPath = true;
        visibility.algorithmSettings = false;
        return visibility;
    }

    Init() {
        let visibility = new ButtonsVisibility();
        visibility.run = true;
        visibility.pause = false;
        visibility.clear = true;
        visibility.clearPath = true;
        visibility.algorithmSettings = true;
        return visibility;
    }

    GetRun = () => this.run;

    GetPause = () => this.pause;

    GetClear = () => this.clear;

    GetClearPath = () => this.clearPath;

    GetAlgorithmSettings = () => this.algorithmSettings;

}

export default ButtonsVisibility;