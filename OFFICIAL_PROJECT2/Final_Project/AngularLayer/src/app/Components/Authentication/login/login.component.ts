import { Component, OnInit } from '@angular/core';
import { GetUsersService } from 'src/app/Services/UsersService/get-users.service';
import { AuthService } from '@auth0/auth0-angular';
import { Observable } from 'rxjs';
import { User } from '@auth0/auth0-angular';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  private User: any
  constructor(public auth: AuthService) { 
    this.auth;
  }

  ngOnInit(): void {
  }
  loginWITHRedirect():void{
    let User = this.auth.loginWithRedirect();
    this.User = this.auth.getIdTokenClaims()
    // console.log(`THe user logged in with ${User}, ${JSON.parse(this.User)}`)
    this.User = this.auth.getUser();
    // console.log(`THe user logged in with ${User}, ${JSON.parse(this.User)}`)
  }

}
