// src/Posts.js
import React, { Component } from 'react';
import Post from './Post';

class Posts extends Component {
  constructor(props) {
    super(props);
    this.state = {
      posts: []
    };
  }

  loadPosts = async () => {
    try {
      const response = await fetch('https://jsonplaceholder.typicode.com/posts');
      const data = await response.json();
      const posts = data.slice(0, 10).map(post => 
        new Post(post.userId, post.id, post.title, post.body)
      );
      this.setState({ posts });
    } catch (error) {
      console.error('Error loading posts:', error);
    }
  }

  componentDidMount() {
    this.loadPosts();
  }

  componentDidCatch(error, errorInfo) {
    alert(`An error occurred: ${error.message}`);
    console.error('Error caught by componentDidCatch:', error, errorInfo);
  }

  render() {
    return (
      <div style={{ padding: '20px' }}>
        <h1>Blog Posts</h1>
        {this.state.posts.map(post => (
          <div key={post.id} style={{ 
            marginBottom: '20px', 
            padding: '15px', 
            border: '1px solid #ccc',
            borderRadius: '5px'
          }}>
            <h3>{post.title}</h3>
            <p>{post.body}</p>
          </div>
        ))}
      </div>
    );
  }
}

export default Posts;