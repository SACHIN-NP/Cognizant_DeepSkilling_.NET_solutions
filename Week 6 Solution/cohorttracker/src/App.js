import React from 'react';
import './App.css';
import CohortDetails from './CohortDetails';

function App() {
  const cohorts = [
    {
      id: 1,
      name: 'React Fundamentals',
      status: 'ongoing',
      startDate: '2025-04-15',
      duration: '4 weeks',
      coach: 'Sachin',
      trainer: 'Bhavesh',
      participants: 25
    },
    
    {
      id: 2,
      name: 'Java Full-stack-Dev',
      status: 'ongoing',
      startDate: '2025-06-07',
      duration: '12 weeks',
      coach: 'Archi',
      trainer: 'Sweta',
      participants: 120
    },
    {
      id: 3,
      name: 'Advanced JavaScript',
      status: 'completed',
      startDate: '2024-11-01',
      duration: '8 weeks',
      coach: 'Himanshu',
      trainer: 'Priyank',
      participants: 75
    }
  ];

  return (
    <div className="App">
      <CohortDetails cohorts={cohorts} />
    </div>
  );
}

export default App;