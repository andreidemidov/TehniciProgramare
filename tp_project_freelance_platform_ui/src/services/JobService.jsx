import { JOB } from "../constants";

export const JobService = {
    CreateJob,
    GetAllByUser,
    GetAllJobs,
    DeleteJob,
    UpdateJob
}

async function CreateJob(job){
    debugger;
    const jwttoken = localStorage.getItem('JWT');
    const bearer = 'Bearer ' + jwttoken;

    let response = await fetch(JOB, {
        method: "POST",
        headers: { 
            'Authorization': bearer,
            'Content-Type': 'application/json' 
        },
        body: JSON.stringify(job)
    });
    return await response.json();
}

async function GetAllByUser(id){
    const jwttoken = localStorage.getItem('JWT');
    const bearer = 'Bearer ' + jwttoken;

    let response = await fetch(JOB + `/${id}`, {
        method: "GET",
        headers: { 
            'Authorization': bearer 
        },
    });
    return await response.json();
}

async function GetAllJobs(){
    const jwttoken = localStorage.getItem('JWT');
    const bearer = 'Bearer ' + jwttoken;

    let response = await fetch(JOB, {
        method: "GET",
        headers: { 
            'Authorization': bearer 
        },
    });

    return await response.json();
}

async function DeleteJob(id){
    const jwttoken = localStorage.getItem('JWT');
    const bearer = 'Bearer ' + jwttoken;

    let response = await fetch(JOB + `/${id}`, {
        method: "DELETE",
        headers: { 
            'Authorization': bearer 
        },
    });
    return await response.json();
}

async function UpdateJob(job){
    debugger;
    const jwttoken = localStorage.getItem('JWT');
    const bearer = 'Bearer ' + jwttoken;

    let response = await fetch(JOB + `/Update`, {
        method: "POST",
        headers: { 
            'Authorization': bearer,
            'Content-Type': 'application/json' 
        },
        body: JSON.stringify(job)
    });
    return await response.json();
}