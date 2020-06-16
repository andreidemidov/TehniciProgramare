import React, { Component } from 'react';
import NavBar from '../Home/NavBar';
import "./Profile.css";
import '../../components/Home/Modal.css';
import { EmployeeService } from '../../services/EmployeeService';
import "react-image-crop/dist/ReactCrop.css";
import { toast } from 'react-toastify';

toast.configure();

export default class ProfileDetails extends Component {
    constructor(props) {
        super(props);
        this.state = {
            position: "",
            county: "",
            city: "",
            phone: "",
            personalDescription: "",
            selectedFile: "",
            selectedFileName: "",
            openModal: false
        }
    }

    showModalHandler = () => {
        debugger;
        this.setState({
            openModal: !this.state.openModal
        })
    }

    handleChange = (e) => {
        e.preventDefault();
        debugger;
        if (e.target.type == 'file') {
            let files = e.target.files;
            console.log(files);
            let reader = new FileReader();
            reader.onload = r => {
                this.setState({ selectedFile: r.target.result, selectedFileName: files[0].name });
            };
            reader.readAsDataURL(files[0]);
        } else {
            const { name, value } = e.target;
            this.setState({ [name]: value });

        }

    }

    handleSubmit = async (e) => {
        e.preventDefault();
        debugger;
        const employee = {
            userModelId: this.props.location.state.id,
            position: this.state.position,
            county: this.state.county,
            city: this.state.city,
            phone: this.state.phone,
            personalDescription: this.state.personalDescription,
            selectedFile: this.state.selectedFile,
            selectedFileName: this.state.selectedFileName
        };
        await EmployeeService.PostUserDetail(employee).then(result => {
            console.log(result);
            if (result.message === "Success") {
                toast.success("Details successfully added");
            } else {
                toast.error("Something went wrong, please try again later!")
            }
        });
    }

    render() {
        return (
            <div>
                <NavBar></NavBar>
                <div class="container contact">
                    <div class="row">
                        <div class="col-md-3">
                            <div class="contact-info">
                                <i class="fa fa-drivers-license-o" style={{ fontSize: "36px" }}></i>
                                <hr></hr>
                                <h4>Complete your general data</h4>
                                <hr></hr>
                                <h4>Upload your CV</h4>
                            </div>
                        </div>
                        <div class="col-md-9">
                            <div class="contact-form">
                                <div class="form-group">
                                    <label class="control-label col-sm-5" >Current position in your company:</label>
                                    <div class="col-sm-10">
                                        <input type="text" class="form-control" id="fname" placeholder="Enter company position" name="position" onChange={this.handleChange} />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-4" >County where you work:</label>
                                    <div class="col-sm-10">
                                        <input type="text" class="form-control" placeholder="County work" name="county" onChange={this.handleChange} />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-4" >Current city work:</label>
                                    <div class="col-sm-10">
                                        <input type="text" class="form-control" placeholder="City work" name="city" onChange={this.handleChange} />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-4" for="email">Phone:</label>
                                    <div class="col-sm-10">
                                        <input type="phone" class="form-control" id="email" placeholder="Phone number" name="phone" onChange={this.handleChange} />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-5" for="personalDescription">A few words for your description:</label>
                                    <div class="col-sm-10">
                                        <textarea class="form-control" rows="5" id="comment" name="personalDescription" onChange={this.handleChange}></textarea>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-4" for="resume">Add your resume here:</label>
                                    <div class="col-sm-10">
                                        <input type="file" class="form-control" placeholder="CV" name="selectedFile" onChange={this.handleChange} />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-offset-2 col-sm-10">
                                        <button type="submit" class="btn btn-default" style = {{cursor: "pointer"}} onClick = {this.handleSubmit}>Submit</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        )
    }
}
