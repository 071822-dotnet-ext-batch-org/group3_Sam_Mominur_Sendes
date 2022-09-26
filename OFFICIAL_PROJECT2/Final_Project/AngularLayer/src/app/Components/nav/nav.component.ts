import { Component, OnInit } from '@angular/core';
import { GetUsersService } from 'src/app/Services/UsersService/get-users.service';
import { AuthService, User } from '@auth0/auth0-angular';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  private User: any
  constructor(public auth:AuthService) { 
    this.auth;
  }

  ngOnInit(): void {
    this.auth.user$.subscribe(
      user => {
        this.User = user
        console.log(`This is the user: ${this.User}`)
      }
    )
  }


}
