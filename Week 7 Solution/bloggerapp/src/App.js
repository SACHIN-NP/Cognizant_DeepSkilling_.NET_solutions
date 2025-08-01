import React, { Component } from 'react';
import BookDetails from './components/BookDetails';
import BlogDetails from './components/BlogDetails';
import CourseDetails from './components/CourseDetails';
import './App.css';

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      selectedComponent: 'book', // 'book', 'blog', 'course'
      showComponents: true,
      userRole: 'admin' // 'admin', 'user', 'guest'
    };
  }

  // Method 1: If-Else Conditional Rendering
  renderWithIfElse = () => {
    if (this.state.selectedComponent === 'book') {
      return <BookDetails />;
    } else if (this.state.selectedComponent === 'blog') {
      return <BlogDetails />;
    } else {
      return <CourseDetails />;
    }
  };

  // Method 2: Ternary Operator
  renderWithTernary = () => {
    return this.state.selectedComponent === 'book' ? 
      <BookDetails /> : 
      this.state.selectedComponent === 'blog' ? 
        <BlogDetails /> : 
        <CourseDetails />;
  };

  // Method 3: Logical AND Operator
  renderWithLogicalAnd = () => {
    return (
      <>
        {this.state.selectedComponent === 'book' && <BookDetails />}
        {this.state.selectedComponent === 'blog' && <BlogDetails />}
        {this.state.selectedComponent === 'course' && <CourseDetails />}
      </>
    );
  };

  // Method 4: Switch Case
  renderWithSwitch = () => {
    switch (this.state.selectedComponent) {
      case 'book':
        return <BookDetails />;
      case 'blog':
        return <BlogDetails />;
      case 'course':
        return <CourseDetails />;
      default:
        return <BookDetails />;
    }
  };

  // Method 5: Object Map
  renderWithObjectMap = () => {
    const componentMap = {
      book: <BookDetails />,
      blog: <BlogDetails />,
      course: <CourseDetails />
    };
    return componentMap[this.state.selectedComponent] || <BookDetails />;
  };

  // Method 6: Element Variables
  renderWithElementVariable = () => {
    let component;
    if (this.state.selectedComponent === 'book') {
      component = <BookDetails />;
    } else if (this.state.selectedComponent === 'blog') {
      component = <BlogDetails />;
    } else {
      component = <CourseDetails />;
    }
    return component;
  };

  handleComponentChange = (componentType) => {
    this.setState({ selectedComponent: componentType });
  };

  toggleComponents = () => {
    this.setState({ showComponents: !this.state.showComponents });
  };

  render() {
    const buttonStyle = {
      margin: '5px',
      padding: '10px 15px',
      border: 'none',
      borderRadius: '5px',
      cursor: 'pointer',
      fontWeight: 'bold'
    };

    const activeButtonStyle = {
      ...buttonStyle,
      backgroundColor: '#007bff',
      color: 'white'
    };

    const inactiveButtonStyle = {
      ...buttonStyle,
      backgroundColor: '#f8f9fa',
      color: '#333'
    };

    return (
      <div className="App">
        <header style={{ backgroundColor: '#333', color: 'white', padding: '20px', textAlign: 'center' }}>
          <h1>Blogger App - Conditional Rendering Demo</h1>
          <p>Demonstrating Multiple Ways of Conditional Rendering</p>
        </header>
        <div style={{ padding: '20px' }}>
          <div style={{ marginBottom: '20px', textAlign: 'center' }}>
            <h3>Select Component to Display:</h3>
            <button
              style={this.state.selectedComponent === 'book' ? activeButtonStyle : inactiveButtonStyle}
              onClick={() => this.handleComponentChange('book')}
            >
              📚 Books
            </button>
            <button
              style={this.state.selectedComponent === 'blog' ? activeButtonStyle : inactiveButtonStyle}
              onClick={() => this.handleComponentChange('blog')}
            >
              📝 Blogs
            </button>
            <button
              style={this.state.selectedComponent === 'course' ? activeButtonStyle : inactiveButtonStyle}
              onClick={() => this.handleComponentChange('course')}
            >
              🎓 Courses
            </button>
          </div>
          <div style={{ marginBottom: '20px', textAlign: 'center' }}>
            <button
              onClick={this.toggleComponents}
              style={{
                ...buttonStyle,
                backgroundColor: this.state.showComponents ? '#dc3545' : '#28a745',
                color: 'white'
              }}
            >
              {this.state.showComponents ? 'Hide Components' : 'Show Components'}
            </button>
          </div>
          {/* Show/hide main component display */}
          {this.state.showComponents && (
            <div>
              <h3 style={{ textAlign: 'center', color: '#666' }}>
                Currently showing: {this.state.selectedComponent.toUpperCase()} component
              </h3>
              {/* Use one of these render methods for demonstration: */}
              {this.renderWithIfElse()}
              {/* {this.renderWithTernary()} */}
              {/* {this.renderWithLogicalAnd()} */}
              {/* {this.renderWithSwitch()} */}
              {/* {this.renderWithObjectMap()} */}
              {/* {this.renderWithElementVariable()} */}
            </div>
          )}
          {/* User Role Control */}
          <div style={{ marginTop: '30px', padding: '20px', backgroundColor: '#f8f9fa', borderRadius: '5px' }}>
            <h3>Role-based Access Control:</h3>
            <p>Current Role: <strong>{this.state.userRole}</strong></p>
            {this.state.userRole === 'admin' && (
              <div style={{ color: 'green' }}>
                ✅ Admin: Full access to all components
              </div>
            )}
            {this.state.userRole === 'user' && (
              <div style={{ color: 'orange' }}>
                ⚠️ User: Limited access - can view content but cannot modify
              </div>
            )}
            {this.state.userRole === 'guest' && (
              <div style={{ color: 'red' }}>
                ❌ Guest: Please login to access content
              </div>
            )}
            <div style={{ marginTop: '10px' }}>
              <button
                onClick={() => this.setState({ userRole: 'admin' })}
                style={this.state.userRole === 'admin' ? activeButtonStyle : inactiveButtonStyle}
              >
                Admin
              </button>
              <button
                onClick={() => this.setState({ userRole: 'user' })}
                style={this.state.userRole === 'user' ? activeButtonStyle : inactiveButtonStyle}
              >
                User
              </button>
              <button
                onClick={() => this.setState({ userRole: 'guest' })}
                style={this.state.userRole === 'guest' ? activeButtonStyle : inactiveButtonStyle}
              >
                Guest
              </button>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default App;