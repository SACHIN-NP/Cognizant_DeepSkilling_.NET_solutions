import React from 'react';
import { useParams } from 'react-router-dom';
import trainers from './TrainersMock';

const TrainerDetails = () => {
  const { id } = useParams();
  const trainer = trainers.find(t => t.trainerId === id);

  if (!trainer) {
    return <div>Trainer not found</div>;
  }

  return (
    <div style={{
      display: 'flex',
      justifyContent: 'center',  
      alignItems: 'center',      
      height: '75vh',           
      padding: '20px',
      backgroundColor: 'skyblue'  // optional: light background for contrast
    }}>
      <div style={{
        maxWidth: '500px',
        border: '1px solid #ccc',
        padding: '50px',
        borderRadius: '50px',
        boxShadow: '0 2px 8px rgba(0,0,0,0.1)',
        backgroundColor: '#fff'
      }}>
        <h2>Trainer Details</h2>
        <p><strong>ID:</strong> {trainer.trainerId}</p>
        <p><strong>Name:</strong> {trainer.name}</p>
        <p><strong>Email:</strong> {trainer.email}</p>
        <p><strong>Phone:</strong> {trainer.phone}</p>
        <p><strong>Technology:</strong> {trainer.technology}</p>
        <p><strong>Skills:</strong> {trainer.skills.join(', ')}</p>
      </div>
    </div>
  );
};

export default TrainerDetails;
