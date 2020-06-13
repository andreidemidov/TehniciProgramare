import React, { Component } from 'react'
import { userService } from '../../services/UserService';
import NavBar from './NavBar';
import '../Home/Employeer.css';
import manAvatar from '../../man.png';
import womanAvatar from '../../woman.png';
import Avatar from 'react-avatar';
import './Modal.css';
import { JobService } from '../../services/JobService';
import { toast } from 'react-toastify';

toast.configure();

export default class HomeEmployeer extends Component {
    constructor(props) {
        super(props);
        this.state = {
            user: {},
            jobs: [],
            isShowing: false,
            showInput: false,
            name: "",
            description: "",
            salary: "",
            city: "",
            study: "",
            level: "",
            occupation: "",
            industry: "",
            department: "",
            companyName: "",
            foreignLanguage: "",
            isShowing: ""
        }
    }

    componentDidMount = async () => {
        await userService.GetUser().then((result) => {
            this.setState({ user: result });
        });

        await JobService.GetAllByUser(this.state.user.id).then((result) => {
            if (result.message == "Success") {
                this.setState({ jobs: result.jobs });
            }

        });

    }

    openCloseModal = () => {
        this.setState({ isShowing: !this.state.isShowing });
    }

    handleChange = (e) => {
        e.preventDefault();
        const { name, value } = e.target;
        this.setState({ [name]: value });
    }

    handleSubmit = async (e) => {
        e.preventDefault();
        let currentDate = new Date();
        debugger;
        let job = {
            employeerId: this.state.user.id,
            name: this.state.name,
            description: this.state.description,
            salary: this.state.salary,
            city: this.state.city,
            study: this.state.study,
            level: this.state.level,
            occupation: this.state.occupation,
            industry: this.state.industry,
            department: this.state.department,
            foreignLanguage: this.state.foreignLanguage,
            companyName: this.state.companyName,
            addedDate: currentDate
        }

        await JobService.CreateJob(job).then(result => {
            console.log(result);
            if (result.message === "Success") {
                toast.success("Job was added successfully");
            } else {
                toast.error("Something was wrong, please try again later!")
            }
        });
        window.location.reload(true);
    }

    DeleteJob = async (id) => {
        console.log(id);
        await JobService.DeleteJob(id).then(result => {
            debugger;
            if (result.message === "Success") {
                window.location.reload(true);
            } else {
                toast.error("Something was wrong, please try again later!")
            }
        });

    }

    openModalHandler(id) {
        debugger;
        const jobUpdated = this.state.jobs.map(jobs => {
            if (jobs.id === id) {
                jobs.isShowingUpdate = true;
            }
            return jobs;
        })
        this.setState({
            jobs: jobUpdated
        });

        jobUpdated.map(job => {
            if (job.isShowingUpdate === true) {
                this.setState({
                    name: job.name,
                    description: job.description,
                    salary: job.salary,
                    city: job.city,
                    study: job.study,
                    level: job.level,
                    occupation: job.occupation,
                    industry: job.industry,
                    department: job.department,
                    foreignLanguage: job.foreignLanguage,
                    companyName: job.companyName,
                });
            }
        });

    }

    closeModalHandler = (id) => {
        const jobUpdated = this.state.jobs.map(jobs => {
            if (jobs.id === id) {
                jobs.isShowingUpdate = false;
            }
            return jobs;
        })
        this.setState({
            jobs: jobUpdated
        });

        window.location.reload(true);
    }

    updateByField = async (id) => {
        debugger;
        let currentDate = new Date();
        let job = {
            id: id,
            employeerId: this.state.user.id,
            name: this.state.name,
            description: this.state.description,
            salary: this.state.salary,
            city: this.state.city,
            study: this.state.study,
            level: this.state.level,
            occupation: this.state.occupation,
            industry: this.state.industry,
            department: this.state.department,
            foreignLanguage: this.state.foreignLanguage,
            companyName: this.state.companyName,
            addedDate: currentDate
        };
        debugger;
        await JobService.UpdateJob(job).then(result => {
            debugger;
            console.log(result);
            if (result.message === "Success") {
                toast.success("Job was updated successfully");
            } else {
                toast.error("Something went wrong, please try again later!")
            }
        });
    }

    updateAllFields = () => {

    }

    render() {
        const { isShowing, showInput } = this.state;
        return (
            <div>
                <NavBar profile={this.state.user.role}></NavBar>

                <div className="container">
                    <button className="btn btn-primary" style={{ marginLeft: "80%", marginTop: "3%" }} onClick={() => this.openCloseModal()}>Add new Job</button>
                    {
                        isShowing && (
                            <div className="modal-wrapper">
                                <div className="modal-content display-block">
                                    <span className="close" onClick={() => this.openCloseModal()}>&times;</span>
                                    <h5 className="card-title" style={{ fontSize: "16px", color: "#2A333D" }}>Add new job</h5>
                                    <form onSubmit={this.handleSubmit}>
                                        <div class="form-group">
                                            <input type="text" class="form-control" name="name" placeholder="Name of job" onChange={this.handleChange} />
                                        </div>
                                        <div className="form-group">
                                            <input type="text" class="form-control" name="description" placeholder="Job description" onChange={this.handleChange} />
                                        </div>
                                        <div className="form-group">
                                            <input type="text" class="form-control" name="salary" placeholder="Job salary interval" onChange={this.handleChange} />
                                        </div>
                                        <div className="form-group">
                                            <input type="text" class="form-control" name="city" placeholder="Job city" onChange={this.handleChange} />
                                        </div>
                                        <div className="form-group">
                                            <input type="text" class="form-control" name="study" placeholder="Job study level needed" onChange={this.handleChange} />
                                        </div>
                                        <div className="form-group">
                                            <input type="text" class="form-control" name="level" placeholder="Job level status" onChange={this.handleChange} />
                                        </div>
                                        <div className="form-group">
                                            <input type="text" class="form-control" name="occupation" placeholder="Job occupation" onChange={this.handleChange} />
                                        </div>
                                        <div className="form-group">
                                            <input type="text" class="form-control" name="industry" placeholder="Job industry" onChange={this.handleChange} />
                                        </div>
                                        <div className="form-group">
                                            <input type="text" class="form-control" name="department" placeholder="Job department" onChange={this.handleChange} />
                                        </div>
                                        <div className="form-group">
                                            <input type="text" class="form-control" name="companyName" placeholder="Company Name" onChange={this.handleChange} />
                                        </div>
                                        <div className="form-group">
                                            <input type="text" class="form-control" name="foreignLanguage" placeholder="Job foreign language needed" onChange={this.handleChange} />
                                        </div>
                                        <button className="btn btn-primary" type="submit" style={{ marginLeft: "45%" }}>Add</button>
                                    </form>
                                </div>
                            </div>
                        )
                    }
                    <h5><p className="navbar-brand" style={{ fontSize: "16px", color: "#2A333D" }}>Your posted Jobs</p></h5>
                    {
                        this.state.jobs && this.state.jobs.map((job, index) =>
                            <div class="card" style={{ marginBottom: "2%" }} key={index}>
                                <div class="card-body">
                                    <h5 className="card-title" style={{ fontSize: "16px", color: "#2A333D" }}>{job.name} ({job.city})</h5>
                                    <p className="card-text" style={{ color: "#D6001C", font: "sans-serif", fontSize: "14px" }}>{job.department}, {job.city}</p>

                                    <h2 className="card-text" style={{ display: "inline-block", color: "#2A333D", font: "sans-serif", fontSize: "14px" }}>Applicants: </h2>
                                    <table style={{ display: "inline-block", marginLeft: "2%" }}>
                                        <td>
                                            <Avatar name="Wim Mostmans" size="50" round="40px" />
                                        </td>
                                        <td>
                                            <Avatar name="Wim Mostmans" size="50" round="40px" />
                                        </td>
                                    </table>
                                    <div style={{ marginLeft: "80%" }}>
                                        <button className="btn btn-danger" style={{ marginRight: "4%" }} onClick={() => this.openModalHandler(job.id)}>Edit job</button>
                                        {
                                            job.isShowingUpdate && (
                                                <div className="modal-wrapper">
                                                    <div className="modal-content display-block">
                                                        <span className="close" onClick={() => this.closeModalHandler(job.id)}>&times;</span>
                                                        <h5>Update job Details</h5>
                                                        <table className="table" >
                                                            <tbody >
                                                                <tr >
                                                                    <th scope="row">City</th>
                                                                    <td>{job.city}</td>
                                                                    <td>
                                                                        <input type="text" name="city" placeholder="Update name of job" onChange={this.handleChange} />
                                                                    </td>
                                                                    <i className="fa fa-edit" style={{ fontSize: "25px", marginTop: "14px", cursor: "pointer" }} onClick={() => this.updateByField(job.id)}></i>
                                                                </tr>
                                                                <tr >
                                                                    <th scope="row">Company Name</th>
                                                                    <td>{job.companyName}</td>
                                                                    <td>
                                                                        <input type="text" name="companyName" placeholder="Update company name of job" onChange={this.handleChange} />
                                                                    </td>
                                                                    <i className="fa fa-edit" style={{ fontSize: "25px", marginTop: "14px", cursor: "pointer" }} onClick={() => this.updateByField(job.id)}></i>
                                                                </tr>
                                                                <tr >
                                                                    <th scope="row">Description</th>
                                                                    <td>{job.description}</td>
                                                                    <td>
                                                                        <input type="text" name="description" placeholder="Update description of job" onChange={this.handleChange} />
                                                                    </td>
                                                                    <i className="fa fa-edit" style={{ fontSize: "25px", marginTop: "14px", cursor: "pointer" }} onClick={() => this.updateByField(job.id)}></i>
                                                                </tr>
                                                                <tr>
                                                                    <th scope="row">Career level</th>
                                                                    <td>{job.level}</td>
                                                                    <td>
                                                                        <input type="text" name="level" placeholder="Update career level" onChange={this.handleChange} />
                                                                    </td>
                                                                    <i className="fa fa-edit" style={{ fontSize: "25px", marginTop: "14px", cursor: "pointer" }} onClick={() => this.updateByField(job.id)}></i>
                                                                </tr>
                                                                <tr>
                                                                    <th scope="row">Study</th>
                                                                    <td>{job.study}</td>
                                                                    <td>
                                                                        <input type="text" name="study" placeholder="Update study" onChange={this.handleChange} />
                                                                    </td>
                                                                    <i className="fa fa-edit" style={{ fontSize: "25px", marginTop: "14px", cursor: "pointer" }} onClick={() => this.updateByField(job.id)}></i>
                                                                </tr>
                                                                <tr>
                                                                    <th scope="row">Ocupation</th>
                                                                    <td>{job.occupation}</td>
                                                                    <td>
                                                                        <input type="text" name="occupation" placeholder="Update ocupation" onChange={this.handleChange} />
                                                                    </td>
                                                                    <i className="fa fa-edit" style={{ fontSize: "25px", marginTop: "14px", cursor: "pointer" }} onClick={() => this.updateByField(job.id)}></i>
                                                                </tr>
                                                                <tr>
                                                                    <th scope="row">Department</th>
                                                                    <td>{job.department}</td>
                                                                    <td>
                                                                        <input type="text" name="department" placeholder="Update department" onChange={this.handleChange} />
                                                                    </td>
                                                                    <i className="fa fa-edit" style={{ fontSize: "25px", marginTop: "14px", cursor: "pointer" }} onClick={() => this.updateByField(job.id)}></i>
                                                                </tr>
                                                                <tr>
                                                                    <th scope="row">Industry</th>
                                                                    <td>{job.industry}</td>
                                                                    <td>
                                                                        <input type="text" name="industry" placeholder="Update industry" onChange={this.handleChange} />
                                                                    </td>
                                                                    <i className="fa fa-edit" style={{ fontSize: "25px", marginTop: "14px", cursor: "pointer" }} onClick={() => this.updateByField(job.id)}></i>
                                                                </tr>
                                                                <tr>
                                                                    <th scope="row">Foreign Langauge</th>
                                                                    <td>{job.foreignLanguage}</td>
                                                                    <td>
                                                                        <input type="text" name="foreignLanguage" placeholder="Update foreign Langauge" onChange={this.handleChange} />
                                                                    </td>
                                                                    <i className="fa fa-edit" style={{ fontSize: "25px", marginTop: "14px", cursor: "pointer" }} onClick={() => this.updateByField(job.id)}></i>

                                                                </tr>
                                                                <tr>
                                                                    <th scope="row">salary</th>
                                                                    <td>{job.salary} &euro;</td>
                                                                    <td>
                                                                        <input type="text" name="salary" placeholder="Update salary" onChange={this.handleChange} />
                                                                    </td>
                                                                    <i className="fa fa-edit" style={{ fontSize: "25px", marginTop: "14px", cursor: "pointer" }} onClick={() => this.updateByField(job.id)}></i>

                                                                </tr>

                                                            </tbody>
                                                        </table>
                                                        <button className="btn btn-primary" type="button" style={{ marginLeft: "45%" }} onClick={() => this.updateByField(job.id)}>Update All</button>
                                                    </div>
                                                </div>
                                            )
                                        }
                                        <a className="btn btn-danger" href="" onClick={() => this.DeleteJob(job.id)}>Delete job</a>
                                    </div>
                                </div>
                            </div>

                        )}
                </div>
            </div>

        )
    }
}
