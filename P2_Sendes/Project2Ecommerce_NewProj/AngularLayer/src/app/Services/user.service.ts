import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { User, User_Guest, User_LoginDTO, User_RegisterDTO } from '../Models/User';
@Injectable({
  providedIn: 'root'
})
export class UserService {
  // private currentUser : User = {id : "00000000-0000-0000-0000-000000000000", username : 'Dr. Not', password: 'Pass0', firstname: 'First', lastname: 'Last', email:'default@email.com', role: 'User', signUpDate: Date.now};
  // private currentUser_Login: User_LoginDTO = { email:'default@email.com', password: 'Pass0'}
  // private currentUser_Register: User_RegisterDTO = { username : 'Dr. Not', password: 'Pass0', firstname: 'First', lastname: 'Last', email:'default@email.com'}
  // private currentUser_Guest: User_Guest = { firstname: 'First', lastname: 'Last', email:'default@email.com'}
  private APIURL = 'https://localhost:7116';

  constructor(private http: HttpClient) { this.http; }

  getUsers():Observable<User[]>{
    return this.http.get<User[]>(this.APIURL + `/User`);
  }

  loginUser():Observable<User>{
    return this.http.get<User>(this.APIURL + `​/User​/login`);
  }
  registerUser():Observable<boolean>{
    return this.http.get<boolean>(this.APIURL + `​/User​/register`);
  }

  // getUser(): Observable<User>{
  //     return this.http.get<User>(this.APIURL + `/api/UserAuth/Login`);
  // }

  // registerUser(userRegister: User_RegisterDTO):Observable<User>{
  //   return this.http.post<User>(this.APIURL + `/api/UserAuth/Register`, userRegister)
  // }

}
