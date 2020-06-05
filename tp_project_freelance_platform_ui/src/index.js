import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router } from 'react-router-dom'
import './index.css';
import App from './App';
import Login from './components/AuthComponents/Login';
import Register from './components/AuthComponents/Register';
import { PrivateRoute } from './components/helpers/PrivateRoute';
import HomeEmployee from './components/Home/HomeEmployee';
import HomeEmployeer from './components/Home/HomeEmployeer';
import ProfileDetails from './components/Account/ProfileDetails';

const routing = (
    // <Router>
    //     <div>
    //         
    //         <Route path="/HomeEmployee" component = {HomeEmployee}></Route>
    //         <Route path ="/ProfileDetails" component = {ProfileDetails}></Route>
    //         <Route path ="/ProfileEdit" component = {ProfileEdit}></Route>
    //     </div>
    // </Router>
    <Router>
        <div>
            <Route path = "/" component = {App}></Route>
            <Route path = "/Login" component = {Login}></Route>          
            <Route path = "/Register" component = {Register}></Route>
            <PrivateRoute exact path = "/HomeEmployee"  component={HomeEmployee}></PrivateRoute>
            <PrivateRoute exact path = "/HomeEmployeer"  component={HomeEmployeer}></PrivateRoute>
            <PrivateRoute exact path = "/ProfileDetails"  component={ProfileDetails}></PrivateRoute>
        </div>
      </Router>
)

ReactDOM.render(routing, document.getElementById('root'));

