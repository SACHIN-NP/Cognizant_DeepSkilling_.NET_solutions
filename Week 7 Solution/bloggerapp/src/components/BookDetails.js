import React from 'react';

const BookDetails = () => {
  const books = [
    { id: 1, title: 'React in Action', author: 'Mark Thomas', rating: 4.5 },
    { id: 2, title: 'Learning React', author: 'Alex Banks', rating: 4.8 },
    { id: 3, title: 'React Cookbook', author: 'David Griffiths', rating: 4.2 }
  ];

  return (
    <div style={{ padding: '20px', border: '2px solid #007bff', margin: '10px' }}>
      <h2 style={{ color: '#007bff' }}>📚 Book Details</h2>
      {books.map(book => (
        <div key={book.id} style={{ 
          backgroundColor: '#f8f9fa', 
          padding: '15px', 
          margin: '10px 0',
          borderRadius: '5px'
        }}>
          <h3>{book.title}</h3>
          <p><strong>Author:</strong> {book.author}</p>
          <p><strong>Rating:</strong> {book.rating}/5 ⭐</p>
        </div>
      ))}
    </div>
  );
};

export default BookDetails;

