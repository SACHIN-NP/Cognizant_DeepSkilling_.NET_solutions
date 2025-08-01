import React from 'react';

const ListofPlayers = () => {
  // Array with 11 players using ES6 map feature
  const players = [
    { name: "Virat Kohli", score: 85 },
    { name: "Rohit Sharma", score: 92 },
    { name: "KL Rahul", score: 65 },
    { name: "Hardik Pandya", score: 45 },
    { name: "MS Dhoni", score: 78 },
    { name: "Ravindra Jadeja", score: 55 },
    { name: "Jasprit Bumrah", score: 25 },
    { name: "Mohammed Shami", score: 35 },
    { name: "Yuzvendra Chahal", score: 40 },
    { name: "Rishabh Pant", score: 88 },
    { name: "Shikhar Dhawan", score: 75 }
  ];

  // Filter players with scores below 70 using arrow functions
  const lowScorePlayers = players.filter(player => player.score < 70);

  return (
    <div style={{ padding: '20px' }}>
      <h2>List of Players</h2>
      <h3>All Players:</h3>
      <ul>
        {players.map((player, index) => (
          <li key={index}>
            {player.name} - Score: {player.score}
          </li>
        ))}
      </ul>

      <h3>Players with Score Below 70:</h3>
      <ul>
        {lowScorePlayers.map((player, index) => (
          <li key={index} style={{ color: 'red' }}>
            {player.name} - Score: {player.score}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default ListofPlayers;