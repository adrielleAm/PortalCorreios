import React from 'react';
import './App.css';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";
import Trecho from './Trecho/Trecho';
import Encomendas from './Encomenda/Encomenda';

function App() {
  return (
    <Router>
      <div>
        <nav>
          <ul>
            <li>
              <Link to="/trechos">Trechos</Link>
            </li>
            <li>
              <Link to="/encomendas">Encomendas</Link>
            </li>
          </ul>
        </nav>
        <Switch>
          <Route path="/trechos">
            <Trecho />
          </Route>
          <Route path="/encomendas">
            <Encomendas />
          </Route>
        </Switch>
      </div>
    </Router>
  );
}

export default App;
