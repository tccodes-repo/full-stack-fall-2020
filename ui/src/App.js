import React from 'react';
import './App.css';


import { BrowserRouter as Router, Switch, Route, Link } from 'react-router-dom';

import Customers from './containers/Customers';
import EmailBlasts from './containers/EmailBlasts';
import Recipients from './containers/Recipients';
import Templates from './containers/Templates';

function App() { 
  return (
    <div className="App">
      <Router>
        <div className="sidebar">
            <ul>
              <li><Link to="/customers">Customers</Link></li>
              <li><Link to="/recipients">Recipients</Link></li>
              <li><Link to="/emailblasts">EmailBlasts</Link></li>
              <li><Link to="/templates">Templates</Link></li>
            </ul>
        </div>
        <div className="content">
            <Switch>
              <Route path="/customers" component={Customers} />
              <Route path="/recipients" component={Recipients} />
              <Route path="/templates" component={Templates} />
              <Route path="/emailblasts" component={EmailBlasts} />
              <Route exact path="/">
                <div>Home Page, Hello</div>
              </Route>
            </Switch>
        </div>
      </Router>
    </div>
  );
}

export default App;
