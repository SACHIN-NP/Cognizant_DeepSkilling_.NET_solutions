import React from 'react';
import Counter from './components/Counter';
import CurrencyConverter from './components/CurrencyConverter';
import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header" style={{ backgroundColor: '#f5f5f5', color: '#333' }}>
        <h1>Event Examples App</h1>
        <Counter />
        <CurrencyConverter />
      </header>
    </div>
  );
}

export default App;