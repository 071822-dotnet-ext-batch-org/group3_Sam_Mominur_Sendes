import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { DOCUMENT } from '@angular/common';
import { User_LoginDTO } from '../../Models/User';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(public auth: AuthService) { }

  ngOnInit(): void {
    // this.loginUser();
  }

  loginUser(): void{
    // this.auth.loginWithCredentials();
    this.auth.loginWithRedirect();
  }


}
