import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-selector',
  templateUrl: './selector.component.html',
  styleUrls: ['./selector.component.css'],
})
export class SelectorComponent {
  currentActivate = 'producer-users';
  constructor() {}

  onSelectView(view: string) {
    this.currentActivate = view;
    
  }
}
