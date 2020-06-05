import React from "react";
import { userService } from '../../services/UserService';
import { Route, Redirect } from "react-router-dom";

export const PrivateRoute = ({ component: Component, ...rest }) => {
    return (
        <Route {...rest} render={props => (
            userService.isLogin() ?
                <Component {...props} />
                : <Redirect to="/Login" />
        )} />
    )
};
