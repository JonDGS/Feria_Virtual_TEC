import { Component } from '@angular/core';

@Component({
  selector: 'app-client-selector',
  templateUrl: './client-selector.component.html',
  styleUrls: ['./client-selector.component.css']
})
export class ClientSelectorComponent  {
  currentActivate = 'login';
  constructor() {}

  onSelectView(view: string) {
    this.currentActivate = view;
  }
}