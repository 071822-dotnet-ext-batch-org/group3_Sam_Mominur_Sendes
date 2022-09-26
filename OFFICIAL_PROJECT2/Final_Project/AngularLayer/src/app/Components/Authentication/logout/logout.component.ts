import { Component, Inject, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { DOCUMENT } from '@angular/common';


@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {

  constructor(public auth: AuthService, @Inject(DOCUMENT) private doc: Document) { 
    this.auth;
  }

  ngOnInit(): void {
  }
  logout():void{
    let User = this.auth.logout(
      {
        returnTo: this.doc.location.origin
      }
    );
    console.log(`The user logged out`)
  }

  showLogout(){
    // if(this.auth.)
  }

}
