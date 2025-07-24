import React from 'react';
import { Link } from 'react-router-dom';
import trainers from './TrainersMock';

const TrainersList = () => {
  return (
    <div style={{ padding: '20px' }}>
      <h2>Trainers List</h2>
      <ul style={{ listStyle: 'none', padding: 0 }}>
        {trainers.map(trainer => (
          <li key={trainer.trainerId} style={{ margin: '10px 0' }}>
            <Link 
              to={`/trainer/${trainer.trainerId}`}
              style={{ 
                textDecoration: 'none', 
                color: 'blue',
                fontSize: '18px'
              }}
            >
              {trainer.name}
            </Link>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default TrainersList;