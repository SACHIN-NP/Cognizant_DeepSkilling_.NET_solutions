import React, { Component } from 'react';
import GuestPage from './components/GuestPage';
import UserPage from './components/UserPage';
import './App.css';

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      isLoggedIn: false
    };
  }

  handleLogin = () => {
    this.setState({ isLoggedIn: true });
  };

  handleLogout = () => {
    this.setState({ isLoggedIn: false });
  };

  render() {
    const { isLoggedIn } = this.state;
    return (
      <div className="App">
        <header style={{ backgroundColor: '#333', color: 'white', padding: '20px', textAlign: 'center' }}>
          <h1>Flight Ticket Booking System</h1>
          <p>Status: {isLoggedIn ? 'Logged In' : 'Guest User'}</p>
        </header>
        <main>
          {isLoggedIn ? (
            <UserPage onLogout={this.handleLogout} />
          ) : (
            <GuestPage onLogin={this.handleLogin} />
          )}
        </main>
      </div>
    );
  }
}

export default App;
