export interface User{
    id: any,
    username: string,
    password: string,
    firstname: string,
    lastname: string,
    email: string,
    role: string,
    signUpDate: any
}

export interface User_Guest{
    firstname: string,
    lastname: string,
    email: string,
}

export interface User_RegisterDTO{
    username: string,
    password: string,
    firstname: string,
    lastname: string,
    email: string,
}

export interface User_LoginDTO{
    email: string,
    password: string,
}

