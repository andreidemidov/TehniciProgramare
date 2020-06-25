import React, { Component } from 'react';
import NavBar from './NavBar';
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import './Modal.css';
import { JobService } from '../../services/JobService';
import { userService } from '../../services/UserService';
import { EmployeeService } from '../../services/EmployeeService';

toast.configure();

class HomeEmployee extends Component {
    constructor(props) {
        super(props);
        this.state = {
            user: {},
            jobs: [],
            isShowing: false,
        }
    }

    componentDidMount = async () => {
        debugger;
        await userService.GetUser().then((result) => {
            this.setState({ user: result });
        });

        await JobService.GetAllJobs().then((result) => {
            debugger;
            if (result.message === "Success") {
                this.setState({ jobs: result.jobs });
            }

        });
        console.log(this.state.jobs);
    }

    openModalHandler(id) {
        debugger;
        const jobUpdated = this.state.jobs.map(jobs => {
            if (jobs.id === id) {
                jobs.isShowing = !jobs.isShowing;
            }
            return jobs;
        })
        this.setState({
            jobs: jobUpdated

        });
    }

    closeModalHandler = () => {
        this.setState({
            isShowing: false
        });
    }

    applyToJob = async (jobId) => {
        debugger;
        //toast.success('Success notification');
        let applicant = {
            userModelID: this.state.user.id,
            jobID: jobId
        }

        await EmployeeService.ApplyToJob(applicant).then((result) => {
            if (result.message === "Success") {
                toast.success("You successfully apply for this job");
            } else {
                toast.error("Something went wrong, please try again later!")
            }
        }) 
    }

    DateDifference = (date) => {
        debugger;
        let today = new Date();
        let dbDate = new Date(date);
        var diff = Math.abs(today.getTime() - dbDate.getTime());;
        var result = parseInt(diff/(24 * 60 * 60 * 1000), 10);

        if(result === 0){
            return "Today created"
        }else if(result === 1){
            return "One day ago created"
        }else if(result === 30){
            return "One month ago created"
        }else{
            return result + " ago created";
        }
    }

    render() {
        const redirect = "http://localhost:3000/HomeEmployee";
        return ( 
            <div>
                <NavBar profile={this.state.user} redirect = {redirect}></NavBar>
                <table className="table" style={{ marginLeft: "5%" }}>
                    <tbody>
                        <tr style={{
                            float: "left",
                            position: "relative",
                            width: "100%"
                        }}>
                            {
                                this.state.jobs.map((job, index) =>
                                    <td style={{
                                        float: "left",
                                        position: "relative",
                                        width: "33%"
                                    }}>
                                        <div className="card" style={{ width: "18rem" }} key={index}>
                                            <div className="card-body">
                                                <h5 className="card-title">{job.name}</h5>
                                                <p className="card-text">{job.description}</p>
                                                <p className="card-text">Salary: {job.salary} &euro;</p>
                                                <p className="card-text">{job.companyName}</p>
                                                <button className="btn btn-danger" style={{ margin: "5px" }} onClick={() => this.openModalHandler(job.id)}>Job Details</button>
                                                {
                                                    job.isShowing &&  (
                                                        <div className="modal-wrapper">
                                                            <div className="modal-content display-block">
                                                                <span className="close" onClick={ () => this.openModalHandler(job.id)}>&times;</span>
                                                                <h5>Job Details</h5>
                                                                <table className="table" >
                                                                    <tbody >
                                                                        <tr >
                                                                            <th scope="row">City</th>
                                                                            <td>{job.city}</td>
                                                                            <th scope="row">Career level</th>
                                                                            <td>{job.level}</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th scope="row">Study</th>
                                                                            <td>{job.study}</td>
                                                                            <th scope="row">Ocupation</th>
                                                                            <td>{job.occupation}</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th scope="row">Department</th>
                                                                            <td>{job.department}</td>
                                                                            <th scope="row">Industry</th>
                                                                            <td>{job.industry}</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th scope="row">Foreign Langauge</th>
                                                                            <td>{job.foreignLanguage}</td>
                                                                            <th scope="row">Salary</th>
                                                                            <td>{job.salary} &euro;</td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    )
                                                }

                                                <button className="btn btn-primary" onClick={(e) => {
                                                    e.target.setAttribute("disabled", true);
                                                    this.applyToJob(job.id);
                                                }}>Apply for job</button>
                                            </div>
                                        </div>
                                        <div class="card-footer text-muted" style={{ width: "18rem" }}>
                                            {this.DateDifference(job.addedDate)}
                                        </div>
                                    </td>

                                )}
                        </tr>
                    </tbody>
                </table>
            </div>
        )
    }
}

export default HomeEmployee