import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  @Output() viewSelected = new EventEmitter<string>();

  constructor() {}
  current = 'admin';
  isActivate = false;

  ngOnInit(): void {}

  onSelectView(view: string) {
    this.viewSelected.emit(view);
    this.current = view;
  }
}
