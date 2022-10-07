
export interface Product{
    id?: number,
    title?: string,
    description?: string,
    price?: number,
    inventory?: number,
    dateAdded?: Date
}

export interface User{
    UserID: any,
    Auth0ID: string,
    username:string,
    password: string,
    signUpDate: Date,
    role: number,
    firstname: string,
    lastname:string,
    email: string
}

export interface Cart{
    id?: string,
    cart?: Product[],
    cartTotal?:number,
    lastUpdated?:Date
}