import { LOGIN_URL, REGISTER_URL, GET_AUTH, GET_USER, USER } from "../constants";

export const userService = {
    Login,
    Register,
    isLogin,
    GetUser,
    GetUserById
};

async function Login(email, pass) {
    debugger;
    const data = {
        emailAddress: email,
        password: pass
    }

    let response = await fetch(LOGIN_URL, {
        method: "POST",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(data),
    });
    return await response.json();
}

function isLogin() {
    if (localStorage.getItem('JWT')) {
        return true;
    }
    return false;
}

async function Register(user) {
    debugger;
    let response = await fetch(REGISTER_URL, {
        method: "POST",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(user),
    });
    return await response.json();

}

async function GetUser() {
    const jwttoken = localStorage.getItem('JWT');
    const bearer = 'Bearer ' + jwttoken;
    let response = await fetch(GET_USER, {
        method: "GET",
        headers: {
            'Authorization': bearer,
      },
    });


    return await response.json();
}

async function GetUserById(id){
    const jwttoken = localStorage.getItem('JWT');
    const bearer = 'Bearer ' + jwttoken;

    let response = await fetch(USER + `/${id}`, {
        method: "GET",
        headers: { 
            'Authorization': bearer 
        },
    });
    return await response.json();
}
