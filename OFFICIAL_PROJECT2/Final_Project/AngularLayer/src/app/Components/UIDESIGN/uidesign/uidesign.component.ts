import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-uidesign',
  templateUrl: './uidesign.component.html',
  styleUrls: ['./uidesign.component.css']
})
export class UIDESIGNComponent implements OnInit {

  constructor(public auth: AuthService) { }

  ngOnInit(): void {
  }

}
