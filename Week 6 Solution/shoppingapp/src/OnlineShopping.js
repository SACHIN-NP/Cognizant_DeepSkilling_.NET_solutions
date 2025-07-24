// src/OnlineShopping.js
import React, { Component } from 'react';
import Cart from './Cart';

class OnlineShopping extends Component {
  constructor(props) {
    super(props);
    this.cartItems = [
      new Cart(
        'Laptop',
        99999,
        'https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&w=400&q=80'
      ),
      new Cart(
        'Mouse',
        599,
        'https://images.unsplash.com/photo-1527864550417-7fd91fc51a46?q=80&w=1167&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D'
      ),
      new Cart(
        'Keyboard',
        2100,
        'https://images.unsplash.com/photo-1587829741301-dc798b83add3?q=80&w=1165&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D'
      ),
      new Cart(
        'Monitor',
        43099,
        'https://images.unsplash.com/photo-1527443224154-c4a3942d3acf?w=1000&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8TW9uaXRvcnxlbnwwfHwwfHx8MA%3D%3D'
      ),
      new Cart(
        'Headphones',
        7999,
        'https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=1000&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8aGVhZHBob25lc3xlbnwwfHwwfHx8MA%3D%3D'
      ),
    ];
  }

  render() {
    const totalPrice = this.cartItems.reduce((sum, item) => sum + item.price, 0).toFixed(2);

    return (
      <div
        style={{
          padding: '30px',
          fontFamily: "'Segoe UI', Tahoma, Geneva, Verdana, sans-serif",
          background: '#f5f6fa',
          minHeight: '100vh',
        }}
      >
        <h1 style={{ textAlign: 'center', marginBottom: '30px', color: '#222' }}>Online Shopping Cart</h1>
        <div
          style={{
            display: 'grid',
            gridTemplateColumns: 'repeat(auto-fit, minmax(250px, 1fr))',
            gap: '25px',
          }}
        >
          {this.cartItems.map((item, index) => (
            <div
              key={index}
              style={{
                border: '1px solid #ddd',
                boxShadow: '0 4px 8px rgba(0,0,0,0.12)',
                borderRadius: '14px',
                padding: '22px',
                backgroundColor: '#fff',
                textAlign: 'center',
                transition: 'transform 0.3s',
                cursor: 'pointer',
              }}
              onMouseEnter={e => (e.currentTarget.style.transform = 'scale(1.05)')}
              onMouseLeave={e => (e.currentTarget.style.transform = 'scale(1)')}
            >
              <img
                src={item.imageUrl}
                alt={item.itemname}
                style={{
                  width: '120px',
                  height: '100px',
                  objectFit: 'cover',
                  marginBottom: '15px',
                  borderRadius: '7px',
                }}
              />
              <h3 style={{ color: '#2948ff', marginBottom: '10px' }}>{item.itemname}</h3>
              <p style={{ fontSize: '20px', fontWeight: '700', color: '#27ae60' }}>INR. {item.price}</p>
            </div>
          ))}
        </div>
        <div style={{ marginTop: '40px', textAlign: 'center', color: '#2c3e50' }}>
          <p style={{ fontSize: '19px', fontWeight: '600' }}>
            Total Items: {this.cartItems.length}
          </p>
          <p style={{ fontSize: '22px', fontWeight: '700', color: '#e74c3c' }}>
            Total Price: INR. {totalPrice}
          </p>
        </div>
      </div>
    );
  }
}

export default OnlineShopping;
