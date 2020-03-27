import React from "react";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";

import Wizard from "./components/wizard/index";
import PersonList from "./components/person/List/index";
import "./global.css";
import "./app.css";

const App = () => {
  return (
    <div id="app">
      <Router>
        <aside>
          <Link to="/">
            <button type="button">
              <span>Inicio</span>
            </button>
          </Link>
          <Link to="/register">
            <button type="button">
              <span>Inserir</span>
            </button>
          </Link>
        </aside>

        <main>
          <Switch>
            <Route path="/register">
              <Wizard />
            </Route>
            <Route path="/" exact={true}>
              <PersonList />
            </Route>
            <Route path="*" render={() => "Página inválida"} />
          </Switch>
        </main>
      </Router>
    </div>
  );
};

export default App;
