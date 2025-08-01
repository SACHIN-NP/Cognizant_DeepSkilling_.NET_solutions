import React, { Component } from 'react';

class Counter extends Component {
  constructor(props) {
    super(props);
    this.state = {
      count: 0,
      message: ''
    };
  }

  incrementCounter = () => {
    this.setState({ count: this.state.count + 1 });
  };

  sayHello = () => {
    this.setState({ message: 'Hello! Counter was incremented!' });
  };

  handleIncrease = () => {
    this.incrementCounter();
    this.sayHello();
  };

  decrementCounter = () => {
    this.setState({ count: this.state.count - 1 });
  };

  sayWelcome = (welcomeMsg) => {
    alert(`Welcome! ${welcomeMsg}`);
  };

  handleOnPress = (e) => {
    console.log('Synthetic Event:', e);
    alert('I was clicked');
  };

  render() {
    return (
      <div style={{ padding: '20px', border: '1px solid #ccc', margin: '20px' }}>
        <h2>Counter Component</h2>
        <h3>Count: {this.state.count}</h3>
        <button onClick={this.handleIncrease}
          style={{ margin: '5px', padding: '10px 15px' }}>
          Increment (Multiple Methods)
        </button>
        <button onClick={this.decrementCounter}
          style={{ margin: '5px', padding: '10px 15px' }}>
          Decrement
        </button>
        <button onClick={() => this.sayWelcome('to our application!')}
          style={{ margin: '5px', padding: '10px 15px' }}>
          Say Welcome
        </button>
        <button onClick={this.handleOnPress}
          style={{ margin: '5px', padding: '10px 15px' }}>
          OnPress (Synthetic Event)
        </button>
        {this.state.message && (
          <p style={{ color: 'green', marginTop: '10px' }}>
            {this.state.message}
          </p>
        )}
      </div>
    );
  }
}

export default Counter;