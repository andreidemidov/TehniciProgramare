import { LOGIN_URL, REGISTER_URL, GET_AUTH } from "../constants";

export const userService = {
    Login,
    Register,
    isAuthenticated
};

// function Login(email, pass) {
//     const data = {
//         emailAddress: email,
//         password: pass
//     }
//     fetch(LOGIN_URL, {
//         method: "POST",
//         headers: { 'Content-Type': 'application/json' },
//         body: JSON.stringify(data),
//     }).then(response => {
//              response.json().then((result) => {
//             console.warn("result", result);
//             localStorage.setItem('login', JSON.stringify({
//                 login: true,
//                 token: result.token
//             }))
//         })
//     })
// }

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

async function Register(user) {
    debugger;
   let response = await fetch(REGISTER_URL, {
        method: "POST",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(user),
    });
    return await response.json();
    
}

async function isAuthenticated() {
    const jwttoken = localStorage.getItem('login');
    const bearer = 'Bearer ' + jwttoken;
    let response = await fetch(GET_AUTH, {
        method: "GET",
        headers: {
            'Authorization': bearer,
        },
    });

    return await response.json();
    // }).then(
    //     response => {
    //         response.json()
    //             .then((res) => {
    //                 if (result.message === "authorized") {
    //                     return true;
    //                 }
    //                 if (result.message === "unauthorized") {
    //                     localStorage.removeItem('login');
    //                      return false;
    //                 }
    //             })
    //     }
    // ).catch((err) => {
    //     console.log(err)
    // });
    // return await authenticated;
}
