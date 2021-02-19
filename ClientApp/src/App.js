import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Admin } from './components/Admin';
import { Register } from './components/Register';
import "moment";

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Register} />
            <Route path='/admin' component={Admin} />
      </Layout>
    );
  }
}
