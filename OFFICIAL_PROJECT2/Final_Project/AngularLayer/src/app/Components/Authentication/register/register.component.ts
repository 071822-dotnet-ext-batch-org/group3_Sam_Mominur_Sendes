import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private auth: AuthService) { 
    this.auth;
  }

  ngOnInit(): void {
  }
  register():void{
    let User = this.auth.loginWithRedirect()
    console.log(`THe user logged in with ${User}`)
  }

  showRegister(){
    // if(this.auth.)
  }

}
