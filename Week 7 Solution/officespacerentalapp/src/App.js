import React from 'react';
import './App.css';

function App() {
  // Office object with details
  const office = {
    name: "Premium Business Center",
    rent: 75000,
    address: "123 Business District, Mumbai"
  };

  // List of office spaces
  const officeSpaces = [
    {
      id: 1,
      name: "Luxury Office Suite A",
      rent: 85000,
      address: "Floor 12, Tower A, BKC Mumbai",
      image: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQQ9-EWJiAJ3TjRachAlGrtKNqEosDacJmXhw&s"
    },
    {
      id: 2,
      name: "Compact Business Space",
      rent: 45000,
      address: "Floor 5, Commercial Complex, Pune",
      image: "https://content.jdmagicbox.com/comp/pune/t9/020pxx20.xx20.220125045716.j6t9/catalogue/icc-trade-tower-gokhale-nagar-pune-commercial-buildings-1jzurrxtf6.jpg?clr="
    },
    {
      id: 3,
      name: "Executive Office Center",
      rent: 120000,
      address: "Floor 20, IT Park, Bangalore",
      image: "https://c.ndtvimg.com/2025-02/9dddpsq_google-bengaluru-office-ananta_625x300_20_February_25.jpeg"
    },
    {
      id: 4,
      name: "Startup Hub Workspace",
      rent: 35000,
      address: "Floor 3, Tech Center, Hyderabad",
      image: "https://media.telanganatoday.com/wp-content/uploads/2022/06/T-Hub-3.jpg"
    }
  ];

  // Inline CSS styles
  const containerStyle = {
    padding: '20px',
    fontFamily: 'Arial, sans-serif'
  };

  const headerStyle = {
    textAlign: 'center',
    color: '#333',
    marginBottom: '30px',
    fontSize: '2.5em'
  };

  const officeCardStyle = {
    border: '1px solid #ddd',
    borderRadius: '8px',
    margin: '20px 0',
    padding: '20px',
    boxShadow: '0 2px 4px rgba(0,0,0,0.1)'
  };

  const imageStyle = {
    width: '100%',
    maxWidth: '300px',
    height: '200px',
    objectFit: 'cover',
    borderRadius: '5px',
    marginBottom: '15px'
  };

  const nameStyle = {
    fontSize: '1.5em',
    fontWeight: 'bold',
    marginBottom: '10px',
    color: '#333'
  };

  const addressStyle = {
    color: '#666',
    marginBottom: '10px',
    fontSize: '1.1em'
  };

  // Function to get rent color based on value
  const getRentStyle = (rent) => ({
    fontSize: '1.3em',
    fontWeight: 'bold',
    color: rent < 60000 ? 'red' : 'green'
  });

  return (
    <div style={containerStyle}>
      <h1 style={headerStyle}>Office Space Rental Portal</h1>
      
      <div style={officeCardStyle}>
        <h2>Featured Office</h2>
        <div style={nameStyle}>{office.name}</div>
        <div style={addressStyle}>{office.address}</div>
        <div style={getRentStyle(office.rent)}>
          Monthly Rent: ₹{office.rent.toLocaleString()}
        </div>
      </div>

      <h2 style={{ textAlign: 'center', margin: '40px 0 20px 0' }}>
        Available Office Spaces
      </h2>
      
      {officeSpaces.map(space => (
        <div key={space.id} style={officeCardStyle}>
          <img 
            src={space.image} 
            alt={space.name}
            style={imageStyle}
          />
          <div style={nameStyle}>{space.name}</div>
          <div style={addressStyle}>{space.address}</div>
          <div style={getRentStyle(space.rent)}>
            Monthly Rent: ₹{space.rent.toLocaleString()}
          </div>
        </div>
      ))}
    </div>
  );
}

export default App;
