import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})



export class AppComponent {
  title = 'fv-front-end';
  shownView = 'admin';

  showView(view: string){
    this.shownView = view;
  }
}
