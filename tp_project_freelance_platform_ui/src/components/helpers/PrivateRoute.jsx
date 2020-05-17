import React from "react";
import { userService } from '../../services/UserService';
import { Route, Redirect } from "react-router-dom";

export const PrivateRoute = ({ component: Component, ...rest }) => (
    <Route {...rest} render={(props) => (
        userService.isAuthenticated().then(result => {
            if (result.message === "authorized") {
                return true;
            }
            if (result.message === "unauthorized") {
                localStorage.removeItem('login');
                return false;
            }
        })
            ? <Component {...props} />
            : <Redirect to='/Login' />
    )} />
);