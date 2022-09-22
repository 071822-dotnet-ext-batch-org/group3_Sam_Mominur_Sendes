export interface Product{
    id?: number,
    title?: string,
    description?: string,
    price?: number,
    inventory?: number,
    dateAdded?: Date
}

export interface User{
    pK_UserID: string,
    username:string,
    password: string,
    signUpDate: Date,
    role: number,
    firstname: string,
    lastname:string,
    email: string
}