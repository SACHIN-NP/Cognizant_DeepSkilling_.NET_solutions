
import React from 'react';

const BlogDetails = () => {
  const blogs = [
    { 
      id: 1, 
      title: '10 React Best Practices', 
      author: 'John Doe', 
      date: '2024-01-15',
      excerpt: 'Learn the best practices for writing clean React code...'
    },
    { 
      id: 2, 
      title: 'Understanding React Hooks', 
      author: 'Jane Smith', 
      date: '2024-01-20',
      excerpt: 'A comprehensive guide to React Hooks and their usage...'
    },
    { 
      id: 3, 
      title: 'State Management in React', 
      author: 'Mike Johnson', 
      date: '2024-01-25',
      excerpt: 'Exploring different state management solutions...'
    }
  ];

  return (
    <div style={{ padding: '20px', border: '2px solid #28a745', margin: '10px' }}>
      <h2 style={{ color: '#28a745' }}>📝 Blog Details</h2>
      {blogs.map(blog => (
        <div key={blog.id} style={{ 
          backgroundColor: '#f8fff8', 
          padding: '15px', 
          margin: '10px 0',
          borderRadius: '5px'
        }}>
          <h3>{blog.title}</h3>
          <p><strong>Author:</strong> {blog.author}</p>
          <p><strong>Date:</strong> {blog.date}</p>
          <p><em>{blog.excerpt}</em></p>
        </div>
      ))}
    </div>
  );
};

export default BlogDetails;