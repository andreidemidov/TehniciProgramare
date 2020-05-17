import React, { Component } from 'react';
import { withRouter } from 'react-router-dom';

export default class NavBar extends Component {
    constructor(props) {
        super(props);
    }

    state = {
        isActive: false
    }

    handleShow = () => {
        const { isActive } = this.state;
        this.setState({
            isActive: !isActive,
        });
    }

    RouteToProfle(){
        this.props.history.push('/ProfileDetails');
    }

    render() {
        return (
            <nav className="navbar navbar-expand-lg navbar-light bg-light" style={{ width: "100%" }}>
                <a className="navbar-brand" href="#">Free Lance Platform</a>
                <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>

                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav mr-auto">
                        <li className="nav-item active">
                            <a className="nav-link" href="#">Home <span className="sr-only">(current)</span></a>
                        </li>
                    </ul>
                    <form className="form-inline my-2 my-lg-0">
                        <input className="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search" />
                        <button className="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
                    </form>
                    <i class="fa fa-envelope-o" style={{fontSize: "25px", marginLeft: "10px", cursor: "pointer"}}></i>
                    <i className="fa fa-user-circle" style={{
                        fontSize: "25px", marginLeft: "10px", cursor: "pointer",
                        position: "relative",
                    }} onClick={this.handleShow}>
                        {this.state.isActive ? <div class="dropdown-menu dropdown-menu-right d-block"
                            aria-labelledby="dropdownMenuButton"
                            style={{

                            }}>
                            <a class="dropdown-item" onClick = {this.RouteToProfle}>Profile details</a>
                            <a class="dropdown-item" >Edit profile</a>
                        </div> : null}
                    </i>
                    
                    <i className="fa fa-sign-out" style={{fontSize: "25px", marginLeft: "10px", cursor: "pointer"}} ></i>
                </div>
            </nav>

        )
    }
}
