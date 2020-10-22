import { Component, Input } from '@angular/core';

@Component({
  selector: 'zippy',
  templateUrl: './zippy.component.html',
  styleUrls: ['./zippy.component.css'],
})
export class ZippyComponent {
  @Input('title') title: string;

  isExpanded: boolean;
/*
  funtion: toggle
  Description: change the state of the componet zippy
  Params : 
  Return: void
*/
  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
