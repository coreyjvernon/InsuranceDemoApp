import React, { useState } from 'react';

function App() {
  const [personalInfo, setPersonalInfo] = useState('');
  const [vehicleInfo, setVehicleInfo] = useState('');
  const [quote, setQuote] = useState(null);

  const handleSubmit = async (e) => {
    e.preventDefault();

    // Example: calculate quote based on input length (placeholder logic)
    const calculatedQuote = personalInfo.length + vehicleInfo.length;

    const newQuote = {
      personalInfo,
      vehicleInfo,
      quoteAmount: calculatedQuote
    };

    // Post the new quote to the backend API
    try {
      const response = await fetch('http://localhost:5063/api/quotes', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newQuote)
      });
      if (response.ok) {
        const result = await response.json();
        setQuote(result);
      } else {
        console.error('Error posting quote');
      }
    } catch (error) {
      console.error('Error:', error);
    }
  };

  return (
    <div style={{ padding: '20px' }}>
      <h1>Vehicle Insurance Quote</h1>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Personal Information:</label>
          <br />
          <input
            type="text"
            value={personalInfo}
            onChange={(e) => setPersonalInfo(e.target.value)}
            required
          />
        </div>
        <br />
        <div>
          <label>Vehicle Information:</label>
          <br />
          <input
            type="text"
            value={vehicleInfo}
            onChange={(e) => setVehicleInfo(e.target.value)}
            required
          />
        </div>
        <br />
        <button type="submit">Get Quote</button>
      </form>
      {quote && (
        <div style={{ marginTop: '20px' }}>
          <h2>Quote Details</h2>
          <p><strong>ID:</strong> {quote.id}</p>
          <p><strong>Personal Info:</strong> {quote.personalInfo}</p>
          <p><strong>Vehicle Info:</strong> {quote.vehicleInfo}</p>
          <p><strong>Quote Amount:</strong> ${quote.quoteAmount}</p>
        </div>
      )}
    </div>
  );
}

export default App;
