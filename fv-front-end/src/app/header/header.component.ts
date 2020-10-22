import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
/**
 * This class works as the header for selecting the different views
 */
export class HeaderComponent implements OnInit {
  @Output() viewSelected = new EventEmitter<string>();

  constructor() {}
  currentActivate = 'producer';

  ngOnInit(): void {}

  /**
   * This method emits the event for when a view was selected
   * @param view that was selected
   */
  onSelectView(view: string) {
    this.viewSelected.emit(view);
    this.currentActivate = view;
  }
}
