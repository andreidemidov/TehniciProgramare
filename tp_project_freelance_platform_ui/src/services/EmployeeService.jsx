import { EMPLOYEE } from "../constants";


export const EmployeeService = {
    PostUserDetail,
}

async function PostUserDetail(employee){
    debugger;
    const jwttoken = localStorage.getItem('JWT');
    const bearer = 'Bearer ' + jwttoken;

    let response = await fetch(EMPLOYEE, {
        method: "POST",
        headers: { 
            'Authorization': bearer,
            'Content-Type': 'application/json' 
        },
        body: JSON.stringify(employee)
    });
    return await response.json();
}
