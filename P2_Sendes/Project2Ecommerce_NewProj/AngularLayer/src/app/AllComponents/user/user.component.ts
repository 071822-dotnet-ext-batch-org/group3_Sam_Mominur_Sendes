import { Component, OnInit } from '@angular/core';
import { UserService } from '../../Services/user.service';
import { User, User_Guest, User_LoginDTO, User_RegisterDTO } from '../../Models/User';
//The protect authentication
import { AuthService} from '@auth0/auth0-angular';
//To protect the route endpoints if user doesnt have credentials
// import { AuthGuard } from '@auth0/auth0-angular';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  
   allUsers?: User[] = [];
  
  constructor(private UserRequest: UserService, public auth: AuthService) { }
  ngOnInit(): void {
    this.getALLUSERS();
    // this.auth.user$.subscribe( profile =>
    //   (this.profileJson = JSON.parse(profile))
  }
  getALLUSERS(){
    return this.UserRequest.getUsers().subscribe(users =>
      this.allUsers = users);
  }
}
