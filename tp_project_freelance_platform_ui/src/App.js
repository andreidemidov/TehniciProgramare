import React, { Component } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import Login from './components/AuthComponents/Login';
import Register from './components/AuthComponents/Register';
import { PrivateRoute } from './components/helpers/PrivateRoute';
import HomeEmployee from './components/Home/HomeEmployee';
import HomeEmployeer from './components/Home/HomeEmployeer';
import ProfileDetails from './components/Account/ProfileDetails';

class App extends Component {
  render(){
    return(
      <div></div>
    );
  }
}

export default App;
