import React from 'react';
import './App.css';
import CalculateScore from './Components/CalculateScore';

function App() {
  return (
    <div className="App">
      <CalculateScore 
        name="Sachin Ray"
        school="Kalinga Institute of Industrial Technology"
        total={93}
        goal={100}
      />
    </div>
  );
}

export default App;