import React, { Component } from 'react';
import ListofPlayers from './components/ListofPlayers.js';
import IndianPlayers from './components/IndianPlayers.js';
import './App.css';

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      flag: true
    };
  }

  toggleFlag = () => {
    this.setState({ flag: !this.state.flag });
  };

  render() {
    const { flag } = this.state;

    return (
      <div className="App">
        <header className="App-header">
          <h1>Cricket App - ES6 Features Demo</h1>
          <button onClick={this.toggleFlag} style={{ marginBottom: '20px', padding: '10px 20px' }}>
            Toggle Component (Flag: {flag.toString()})
          </button>   
          {flag ? <ListofPlayers /> : <IndianPlayers />}
        </header>
      </div>
    );
  }
}

export default App;