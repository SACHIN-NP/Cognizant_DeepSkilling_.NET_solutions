import React, { Component } from 'react';

class UserPage extends Component {
  constructor(props) {
    super(props);
    this.state = {
      bookedTickets: []
    };
  }

  bookTicket = (flight) => {
    const booking = {
      ...flight,
      bookingId: Date.now(),
      bookingTime: new Date().toLocaleString()
    };
    this.setState({
      bookedTickets: [...this.state.bookedTickets, booking]
    });
    alert(`Ticket booked successfully! Booking ID: ${booking.bookingId}`);
  };

  render() {
    const { onLogout } = this.props;
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
      backgroundColor: '#f0f8ff'
    };

    return (
      <div style={{ padding: '20px' }}>
        <h2>Welcome User! Book Your Flights</h2>
        <button 
          onClick={onLogout}
          style={{ 
            padding: '10px 20px', 
            backgroundColor: '#dc3545', 
            color: 'white', 
            border: 'none',
            borderRadius: '5px',
            marginBottom: '20px'
          }}>
          Logout
        </button>
        <div>
          <h3>Available Flights:</h3>
          {flights.map(flight => (
            <div key={flight.id} style={cardStyle}>
              <h4>{flight.from} → {flight.to}</h4>
              <p>Price: {flight.price}</p>
              <p>Duration: {flight.time}</p>
              <button 
                onClick={() => this.bookTicket(flight)}
                style={{ 
                  padding: '5px 10px', 
                  backgroundColor: '#28a745', 
                  color: 'white',
                  border: 'none',
                  borderRadius: '3px'
                }}>
                Book Now
              </button>
            </div>
          ))}
        </div>
        {this.state.bookedTickets.length > 0 && (
          <div style={{ marginTop: '30px' }}>
            <h3>Your Bookings:</h3>
            {this.state.bookedTickets.map(ticket => (
              <div key={ticket.bookingId} style={{ ...cardStyle, backgroundColor: '#d4edda' }}>
                <h4>Booking ID: {ticket.bookingId}</h4>
                <p>{ticket.from} → {ticket.to}</p>
                <p>Price: {ticket.price}</p>
                <p>Booked on: {ticket.bookingTime}</p>
              </div>
            ))}
          </div>
        )}
      </div>
    );
  }
}

export default UserPage;