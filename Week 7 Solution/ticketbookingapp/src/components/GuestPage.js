import React from 'react';

const GuestPage = ({ onLogin }) => {
  const flights = [
    { id: 1, from: 'Mumbai', to: 'Delhi', price: '₹5,500', time: '2h 15m' },
    { id: 2, from: 'Bangalore', to: 'Chennai', price: '₹3,200', time: '1h 30m' },
    { id: 3, from: 'Pune', to: 'Hyderabad', price: '₹4,100', time: '1h 45m' },
    { id: 4, from: 'Kolkata', to: 'Mumbai', price: '₹6,200', time: '2h 30m' }
  ];

  const cardStyle = {
    border: '1px solid #ddd',
    borderRadius: '8px',
    padding: '15px',
    margin: '10px 0',
    backgroundColor: '#f9f9f9'
  };

  return (
    <div style={{ padding: '20px' }}>
      <h2>Welcome Guest! Browse Available Flights</h2>
      <p style={{ color: '#666', marginBottom: '20px' }}>
        Please login to book tickets
      </p>
      <button 
        onClick={onLogin}
        style={{ 
          padding: '10px 20px', 
          backgroundColor: '#007bff', 
          color: 'white', 
          border: 'none',
          borderRadius: '5px',
          marginBottom: '20px'
        }}>
        Login
      </button>
      <div>
        <h3>Available Flights:</h3>
        {flights.map(flight => (
          <div key={flight.id} style={cardStyle}>
            <h4>{flight.from} → {flight.to}</h4>
            <p>Price: {flight.price}</p>
            <p>Duration: {flight.time}</p>
            <button disabled style={{ padding: '5px 10px', backgroundColor: '#ccc' }}>
              Login to Book
            </button>
          </div>
        ))}
      </div>
    </div>
  );
};

export default GuestPage;
