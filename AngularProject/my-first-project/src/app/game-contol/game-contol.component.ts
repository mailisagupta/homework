import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-game-contol',
  templateUrl: './game-contol.component.html',
  styleUrls: ['./game-contol.component.css']
})
export class GameContolComponent implements OnInit {
  @Output() intervalFired= new EventEmitter<number>();
  interval: any;
  lastnumber = 0;
  constructor() { }

  ngOnInit(): void {
  }

  onStartGame() {
    this.interval = setInterval(() => {
      this.intervalFired.emit(this.lastnumber + 1);
      this.lastnumber++;}, 1000);
  }

  onPauseGame() {
    clearInterval(this.interval);
  }

}
