import logo from './logo.svg';
import './App.css';
import Grid from './components/Grid.js'

function App() {
  return (
    <div>
      {/* <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header> */}
      <Grid size={30} gridWidth={64} gridHeight={32}></Grid>
    </div>
  );
}

export default App;
