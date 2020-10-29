import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';

import { Emailer } from './lib/api/dist/emailer';




function App() {

  const [customers, setCustomers] = useState([]);

  var e = new Emailer({
    baseUri: 'http://localhost:5000'
  });

  useEffect(() => {
    e.getCustomers().then(r => setCustomers(r));
  }, [setCustomers]);
  

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
        </a>
        {customers.map(c => (
          <div>{c.firstName} {c.lastName}</div>
        ))}
      </header>
    </div>
  );
}

export default App;
