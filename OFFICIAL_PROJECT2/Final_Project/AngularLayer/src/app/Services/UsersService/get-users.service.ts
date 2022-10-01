import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProfileComponent } from 'src/app/Components/User/profile/profile.component';
@Injectable({
  providedIn: 'root'
})
export class GetUsersService {

  constructor(private http: HttpClient) { 
    this.http;
  }
  private APIURL: string = "https://localhost:7116/";
  getUserProfile()
  {
    
  }
}
