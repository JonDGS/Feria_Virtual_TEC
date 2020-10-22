import { Component } from '@angular/core';

@Component({
  selector: 'app-client-selector',
  templateUrl: './client-selector.component.html',
  styleUrls: ['./client-selector.component.css']
})
export class ClientSelectorComponent  {
  currentActivate = 'login';
  constructor() {}
/*
  funtion: onSelectView
  Description: this method chacnge the current selecte compnent shown on the view 
  Params : view
  Return: void
*/
  onSelectView(view: string) {
    this.currentActivate = view;
  }
}