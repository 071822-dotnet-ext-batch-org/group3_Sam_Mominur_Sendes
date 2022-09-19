import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from '@auth0/auth0-angular';
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(public auth: AuthService, public mod:CommonModule) { }

  authenticatedUserProfile?: string = undefined;

  ngOnInit(): void {
    //Will get the userprofile info Only IF the user has an Auth0 authentication token already
    this.auth.user$.subscribe(
      (profileData) => (this.authenticatedUserProfile = JSON.stringify(profileData, null, 2))
    );
  }

}
