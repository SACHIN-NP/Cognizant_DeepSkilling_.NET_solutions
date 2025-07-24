// src/CountPeople.js
import React, { Component } from 'react';

class CountPeople extends Component {
  constructor(props) {
    super(props);
    this.state = {
      entrycount: 0,
      exitcount: 0
    };
  }

  updateEntry = () => {
    this.setState(prevState => ({
      entrycount: prevState.entrycount + 1
    }));
  }

  updateExit = () => {
    this.setState(prevState => ({
      exitcount: prevState.exitcount + 1
    }));
  }

  render() {
    return (
      <div style={{ 
        textAlign: 'center', 
        padding: '50px',
        maxWidth: '500px',
        margin: '0 auto'
      }}>
        <h1>Mall People Counter</h1>
        
        <div style={{ 
          backgroundColor: '#f5f5f5',
          padding: '30px',
          borderRadius: '10px',
          margin: '20px 0'
        }}>
          <h2>Current Count</h2>
          <p style={{ fontSize: '24px', margin: '15px 0' }}>
            <strong>People Entered: {this.state.entrycount}</strong>
          </p>
          <p style={{ fontSize: '24px', margin: '15px 0' }}>
            <strong>People Exited: {this.state.exitcount}</strong>
          </p>
          <p style={{ fontSize: '20px', color: 'blue' }}>
            <strong>Currently Inside: {this.state.entrycount - this.state.exitcount}</strong>
          </p>
        </div>

        <div style={{ margin: '30px 0' }}>
          <button 
            onClick={this.updateEntry}
            style={{
              padding: '15px 30px',
              fontSize: '18px',
              margin: '10px',
              backgroundColor: 'green',
              color: 'white',
              border: 'none',
              borderRadius: '5px',
              cursor: 'pointer'
            }}
          >
            Entry (+1)
          </button>
          
          <button 
            onClick={this.updateExit}
            style={{
              padding: '15px 30px',
              fontSize: '18px',
              margin: '10px',
              backgroundColor: 'red',
              color: 'white',
              border: 'none',
              borderRadius: '5px',
              cursor: 'pointer'
            }}
          >
            Exit (+1)
          </button>
        </div>
      </div>
    );
  }
}

export default CountPeople;