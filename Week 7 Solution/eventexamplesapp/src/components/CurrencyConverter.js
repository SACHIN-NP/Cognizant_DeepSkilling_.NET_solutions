import React, { Component } from 'react';

class CurrencyConverter extends Component {
  constructor(props) {
    super(props);
    this.state = {
      rupees: '',
      euros: 0,
      conversionRate: 0.011 // 1 INR = 0.011 EUR
    };
  }

  handleInputChange = (e) => {
    this.setState({ rupees: e.target.value });
  };

  handleSubmit = (e) => {
    e.preventDefault();
    const { rupees, conversionRate } = this.state;
    const convertedEuros = parseFloat(rupees) * conversionRate;
    this.setState({ euros: convertedEuros.toFixed(2) });
  };

  render() {
    return (
      <div style={{ padding: '20px', border: '1px solid #ccc', margin: '20px' }}>
        <h2>Currency Converter (INR to EUR)</h2>
        <form onSubmit={this.handleSubmit}>
          <div style={{ marginBottom: '10px' }}>
            <label>Enter amount in Indian Rupees: </label>
            <input
              type="number"
              value={this.state.rupees}
              onChange={this.handleInputChange}
              placeholder="Enter rupees"
              style={{ padding: '5px', marginLeft: '10px' }}
            />
          </div>
          <button
            type="submit"
            style={{
              padding: '10px 20px',
              backgroundColor: '#007bff',
              color: 'white',
              border: 'none'
            }}>
            Convert to EUR
          </button>
        </form>
        {this.state.euros > 0 && (
          <div style={{ marginTop: '20px', padding: '10px', backgroundColor: '#f8f9fa' }}>
            <h3>Conversion Result:</h3>
            <p>₹{this.state.rupees} = €{this.state.euros}</p>
          </div>
        )}
      </div>
    );
  }
}

export default CurrencyConverter;