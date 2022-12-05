import React from 'react';
import { Route, Switch } from 'react-router-dom/cjs/react-router-dom.min';
import Contact from '../pages/Contact';
import Home from '../pages/Home';

function MainRoute() {
  return (
    <Switch>
      <Route path="/home">
        <Home></Home>
      </Route>
      <Route path="/contact">
        <Contact />
      </Route>
      <Route path="*">
        <Home />
      </Route>

    </Switch>
  )
}

export default MainRoute