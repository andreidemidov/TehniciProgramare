import React, { Component } from 'react';
import { userService } from '../../services/UserService';
import {Link} from "react-router-dom";
import NavBar from '../Home/NavBar';

export default class UserDetails extends Component {
    constructor(props) {
        super(props);
        this.state = {
            userDetail: {}
        }
    }

    componentDidMount = async () => {
        const userId = this.props.location.state.id;
        debugger;
        await userService.GetUserById(userId).then((result) => {
            if (result.message === "Success") {
                this.setState({ userDetail: result.user });
                console.log(this.state.userDetail);
            } else {

            }


        });
    }

    render() {

        return (
            <div>
                <NavBar></NavBar>
                <table className="table" style={{ margin: "8%" }}>
                    <tbody>
                        <tr style={{
                            float: "left",
                            position: "relative",
                            width: "100%"
                        }}>
                            <div className="card" style={{ width: "30rem" }} >
                                <div className="card-body">
                                     <h5 className="card-title">Profile Detail</h5>
                                     <hr></hr>
                                     <p className="card-text"><strong>FirstName:</strong> { this.props.location.state.firstName}</p>
                                     <hr></hr>
                                     <p className="card-text"><strong>LastName:</strong> { this.props.location.state.lastName}</p>
                                     <hr></hr>
                                     <p className="card-text"><strong>EmailName:</strong> { this.props.location.state.emailAddress}</p>
                                     <hr></hr>
                                     <p className="card-text"><strong>Personal description:</strong> {this.state.userDetail.personalDescription}</p>
                                     <hr></hr>
                                     <p className="card-text"><strong>Position: </strong>{this.state.userDetail.position}</p>
                                     <hr></hr>
                                     <p className="card-text"><strong>Phone: </strong>{this.state.userDetail.phone}</p>
                                     <hr></hr>
                                     <p className="card-text"><strong>County: </strong>{this.state.userDetail.county}</p>
                                     <hr></hr>
                                     <p className="card-text"><strong>City: </strong>{this.state.userDetail.city}</p>
                                     <hr></hr>
                                     <p className="card-text"><strong>Resume: </strong>{this.state.userDetail.selectedFileName} <Link to={this.state.userDetail.selectedFile} target="_blank" download>Download</Link></p> 
                                     
                                </div>
                            </div>
                        </tr>
                    </tbody>
                </table>
            </div>
        )
    }
}
