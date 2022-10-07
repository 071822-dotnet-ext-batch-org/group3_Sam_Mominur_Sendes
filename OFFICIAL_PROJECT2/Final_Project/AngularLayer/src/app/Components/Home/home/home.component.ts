import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    this.playSound();
  }

  playSound()
  {
    console.log(`The sound on the homepage just played`)
    let audio = new Audio();
    audio.src = "../../../assets/Audio/Yoink_SELLORDER_WILLSMITH.mp3";
    audio.load();
    audio.play();
  }

}
