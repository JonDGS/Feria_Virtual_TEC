import { ServerService } from './../../server.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-selector',
  templateUrl: './selector.component.html',
  styleUrls: ['./selector.component.css'],
})
export class SelectorComponent {
  currentActivate = 'login';
  constructor(public server : ServerService) {}

  onSelectView(view: string) {
    this.currentActivate = view;
    
  }
}
