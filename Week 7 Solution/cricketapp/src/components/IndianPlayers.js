import React from 'react';

const IndianPlayers = () => {
  const teamPlayers = [
    "Virat Kohli", "Rohit Sharma", "KL Rahul", "Hardik Pandya", 
    "MS Dhoni", "Ravindra Jadeja", "Jasprit Bumrah", "Mohammed Shami"
  ];

  // Destructuring to separate odd and even team players
  const [first, second, third, fourth, fifth, sixth, seventh, eighth] = teamPlayers;
  const oddTeamPlayers = [first, third, fifth, seventh];
  const evenTeamPlayers = [second, fourth, sixth, eighth];

  // T20 and Ranji Trophy players arrays
  const T20players = ["Virat Kohli", "Rohit Sharma", "KL Rahul", "Hardik Pandya"];
  const RanjiTrophyPlayers = ["Prithvi Shaw", "Mayank Agarwal", "Hanuma Vihari", "Wriddhiman Saha"];

  // Merge arrays using ES6 spread operator
  const mergedPlayers = [...T20players, ...RanjiTrophyPlayers];

  return (
    <div style={{ padding: '20px' }}>
      <h2>Indian Players</h2>
      <h3>Odd Team Players:</h3>
      <ul>
        {oddTeamPlayers.map((player, index) => (
          <li key={index}>{player}</li>
        ))}
      </ul>

      <h3>Even Team Players:</h3>
      <ul>
        {evenTeamPlayers.map((player, index) => (
          <li key={index}>{player}</li>
        ))}
      </ul>

      <h3>Merged T20 and Ranji Trophy Players:</h3>
      <ul>
        {mergedPlayers.map((player, index) => (
          <li key={index}>{player}</li>
        ))}
      </ul>
    </div>
  );
};

export default IndianPlayers;
