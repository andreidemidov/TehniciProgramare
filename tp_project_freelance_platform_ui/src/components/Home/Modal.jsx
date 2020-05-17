import React from 'react';
import './Modal.css';

const modal = (props) => {
    return (
        <div>
            <div className="modal-wrapper">
                <div className="modal-content display-block">
                    <span className="close" onClick={props.close}>&times;</span>
                    <h5>Job Details</h5>
                    {
                        console.log(props.job, props.jobId),
                        props.job && props.job.map((item, index) => 
                        <table className="table" >
                        <tbody >
                            <tr></tr>
                            <tr >
                                <th scope="row">City</th>
                                <td>{item.City}</td>
                                <th scope="row">Career level</th>
                                <td>{item.JobLevel}</td>
                            </tr>
                            <tr>
                                <th scope="row">Study</th>
                                <td>{item.Study}</td>
                                <th scope="row">Ocupattion</th>
                                <td>{item.Ocupattion}</td>
                            </tr>
                            <tr>
                                <th scope="row">Department</th>
                                <td>{item.Department}</td>
                                <th scope="row">Industry</th>
                                <td>{item.Industry}</td>
                            </tr>
                            <tr>
                                <th scope="row">Foreign Langauge</th>
                                <td>{item.ForeignLangauge}</td>
                                <th scope="row">Salary</th>
                                {/* <td>{job.salary}</td> */}
                            </tr>
                        </tbody>
                    </table>
                        )


                    }

                </div>
            </div>
        </div>
    )
}

export default modal;