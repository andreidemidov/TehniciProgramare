import React, { Component } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import { Link } from "react-router-dom";

class App extends Component {
  render(){
    return(
      <Link to = "/Login"></Link>
    );
  }
}

export default App;
