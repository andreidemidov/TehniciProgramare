import React, { Component } from 'react';
import { Link } from "react-router-dom";

export default class NavBar extends Component {
    constructor(props) {
        super(props);
        this.state = {
            isActive: false,
            redirect: ""
        }
    }

    handleShow = () => {
        const { isActive } = this.state;
        this.setState({
            isActive: !isActive,
        });
    }


    logOut = () => {
        localStorage.clear();
        window.location.href = '/Login';
    }

    render() {
        return (
        
            <nav className="navbar navbar-expand-lg navbar-light bg-light" style={{ width: "100%" }}>
                <a className="navbar-brand" href="http://localhost:3000/HomeEmployee">Free Lance Platform</a>
                <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>

                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav mr-auto">
                       
                    </ul>
                    <form className="form-inline my-2 my-lg-0">
                        <input className="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search" />
                        <button className="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
                    </form>
                    <i class="fa fa-envelope-o" style={{ fontSize: "25px", marginLeft: "10px", cursor: "pointer" }}></i>
                    <i className="fa fa-user-circle" style={{
                        fontSize: "25px", marginLeft: "10px", cursor: "pointer",
                        position: "relative",
                    }} onClick={this.handleShow}>
                        {this.state.isActive ? <div class="dropdown-menu dropdown-menu-right d-block"
                            aria-labelledby="dropdownMenuButton"
                            style={{

                            }}>
                            <Link to={{
                                pathname: "/ProfileDetails",
                                state: this.props.profile
                            }}><a class="dropdown-item">{this.props.profile.role} Details</a></Link>

                        </div> : null}
                    </i>

                    <i className="fa fa-sign-out" style={{ fontSize: "25px", marginLeft: "10px", cursor: "pointer" }} onClick={() => this.logOut()}></i>
                </div>
            </nav>

        )
    }
}
