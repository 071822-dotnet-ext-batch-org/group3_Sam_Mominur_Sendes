import { Component, OnInit } from '@angular/core';
import { GetUsersService } from 'src/app/Services/UsersService/get-users.service';
import { AuthService } from '@auth0/auth0-angular';
import { User } from '@auth0/auth0-angular';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  // private userProfile:User = {}
  constructor(public auth: AuthService, private GUS: GetUsersService) {
    this.GUS;
  }

  public userProfile?: string = "";

  ngOnInit(): void {
    this.getUserProfile();
    this.auth.user$.subscribe(
      userProfile => {
        this.userProfile = JSON.stringify(userProfile) ;
        console.log(`Your id is ${this.userProfile}`)
      }
    )
  }

  getUserProfile(){
  }


}
