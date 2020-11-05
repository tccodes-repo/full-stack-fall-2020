import React from 'react';
import './App.css';

import { Switch, Route } from 'react-router';
import { Link } from 'react-router-dom';

import Customers from './containers/Customers';
import EmailBlasts from './containers/EmailBlasts';
import Recipients from './containers/Recipients';
import Templates from './containers/Templates';

function App() { 
  return (
    <div className="App">
      <div className="sidebar">
          <ul>
            <li><Link to="/customers">Customers</Link></li>
            <li><Link to="/recipients">Recipients</Link></li>
            <li><Link to="/templates">Templates</Link></li>
            <li><Link to="/emailblasts">Email Blasts</Link></li>
          </ul>
      </div>
      <div className="content">
          <Switch>
            <Route path="/customers">
              <Customers />
            </Route>
            <Route path="/recipients">
              <Recipients />
            </Route>
            <Route path="/templates">
              <Templates />
            </Route>
            <Route path="/emailblasts">
              <EmailBlasts />
            </Route>
            <Route path="/">
              <div>Home Page, Hello</div>
            </Route>
          </Switch>
      </div>
    </div>
  );
}

export default App;
