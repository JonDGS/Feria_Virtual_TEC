import { ServerService } from './server.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
/**
 * The main component, holds and attribute and a method for changing between the different views
 */
export class AppComponent {
  title = 'fv-front-end';
  shownView = 'producer';

  constructor(public server: ServerService){

  }
  /**
   * This method is for displaying the passed view
   * @param view to display
   */
  showView(view: string) {
    this.shownView = view;
  }
}
