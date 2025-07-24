import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import './App.css';
import Home from './Home';
import TrainersList from './TrainersList';
import TrainerDetails from './TrainerDetails';

function App() {
  return (
    <Router>
      <div className="App">
        <nav style={{ 
          padding: '20px', 
          backgroundColor: '#f5f5f5',
          marginBottom: '20px'
        }}>
          <Link to="/" style={{ marginRight: '20px', textDecoration: 'none' }}>
            Home
          </Link>
          <Link to="/trainers" style={{ textDecoration: 'none' }}>
            Trainers
          </Link>
        </nav>
        
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/trainers" element={<TrainersList />} />
          <Route path="/trainer/:id" element={<TrainerDetails />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;