import React, { Component } from 'react';
import NavBar from './NavBar';
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import Modal from "../Home/Modal";
import './Modal.css';

toast.configure();

export default class HomeEmployee extends Component {
    constructor(props) {
        super(props);
        this.state = {
            jobs: [
                {
                    id: 1, name: "Junior Software Engineer", description: "software engineer with at least one year of experience on react framework", salary: "500-800$", postingDate: "2 days ago", employee: "Microsoft",
                    jobDetails:
                        { id: 1, City: "Brasov", Study: "Graduate", JobLevel: "Entry-Level", Ocupattion: "Full time", Industry: "Software", Department: "IT", ForeignLangauge: "English" },
                },

                {
                    id: 2, name: "Middle Software Engineer", description: "software engineer with at least two years of experience on react framework", salary: "800-2000$", postingDate: "2 days ago", employee: "Microsoft",
                    jobDetails:
                        { id: 2, City: "Bucuresti", Study: "Graduate", JobLevel: "Mid-Level", Ocupattion: "Full time", Industry: "Software", Department: "IT", ForeignLangauge: "English" },
                },
                {
                    id: 3, name: "Middle Software Engineer", description: "software engineer with at least five years of experience on react framework", salary: "2000-4000$", postingDate: "2 days ago", employee: "Microsoft",
                    jobDetails: 
                        { id: 3, City: "Cluj", Study: "Graduate", JobLevel: "Mid-Level", Ocupattion: "Full time", Industry: "Software", Department: "IT", ForeignLangauge: "English" },
                    
                },
                { id: 4, name: "Senior Software Engineer", description: "software engineer with at least five years of experience on react framework", salary: "2000-4000$", postingDate: "2 days ago", employee: "Microsoft",
                jobDetails: 
                        { id: 4, City: "Timisoara", Study: "Graduate", JobLevel: "Mid-Level", Ocupattion: "Full time", Industry: "Software", Department: "IT", ForeignLangauge: "English" },
            },
                { id: 5, name: "Senior Software Engineer", description: "software engineer with at least five years of experience on react framework", salary: "2000-4000$", postingDate: "2 days ago", employee: "Microsoft",
                jobDetails: 
                        { id: 5, City: "Cluj", Study: "Graduate", JobLevel: "Mid-Level", Ocupattion: "Full time", Industry: "Software", Department: "IT", ForeignLangauge: "English" },
            },
                { id: 6, name: "Junior Software Engineer", description: "software engineer with at least five years of experience on react framework", salary: "2000-4000$", postingDate: "2 days ago", employee: "Microsoft",
                jobDetails: 
                        { id: 3, City: "Brasov", Study: "Graduate", JobLevel: "Entry-Level", Ocupattion: "Full time", Industry: "Software", Department: "IT", ForeignLangauge: "English" },
            }
            ],

            isShowing: false,
        }
    }

    openModalHandler(id) {
        debugger;
        const jobUpdated = this.state.jobs.map(jobs => {
            if (jobs.jobDetails.id === id) {
                jobs.jobDetails.isShowing = !jobs.jobDetails.isShowing;
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

    notify = () => {
        toast.success('Success notification');
    }

    render() {
        return (
            <div>
                <NavBar></NavBar>
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
                                                <p className="card-text">Salary: {job.salary}</p>
                                                <p className="card-text">{job.employee}</p>
                                                <button className="btn btn-danger" style={{ margin: "5px" }} onClick={() => this.openModalHandler(job.id)}>Job Details</button>
                                                {
                                                    job.jobDetails.isShowing &&  (
                                                        <div className="modal-wrapper">
                                                            <div className="modal-content display-block">
                                                                <span className="close" onClick={ () => this.openModalHandler(job.id)}>&times;</span>
                                                                <h5>Job Details</h5>
                                                                <table className="table" >
                                                                    <tbody >
                                                                        <tr >
                                                                            <th scope="row">City</th>
                                                                            <td>{job.jobDetails.City}</td>
                                                                            <th scope="row">Career level</th>
                                                                            <td>{job.jobDetails.JobLevel}</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th scope="row">Study</th>
                                                                            <td>{job.jobDetails.Study}</td>
                                                                            <th scope="row">Ocupattion</th>
                                                                            <td>{job.jobDetails.Ocupattion}</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th scope="row">Department</th>
                                                                            <td>{job.jobDetails.Department}</td>
                                                                            <th scope="row">Industry</th>
                                                                            <td>{job.jobDetails.Industry}</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th scope="row">Foreign Langauge</th>
                                                                            <td>{job.jobDetails.ForeignLangauge}</td>
                                                                            <th scope="row">Salary</th>
                                                                            <td>{job.salary}</td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    )
                                                }

                                                <button className="btn btn-primary" onClick={this.notify}>Apply for job</button>
                                            </div>
                                        </div>
                                        <div class="card-footer text-muted" style={{ width: "18rem" }}>
                                            {job.postingDate}
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
