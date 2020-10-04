import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { AdminViewComponent } from './admin-view/admin-view.component';
import { ProducerViewComponent } from './producer-view/producer-view.component';
import { ClientViewComponent } from './client-view/client-view.component';
import { FormProducerComponent } from './producer-view/form-producer/form-producer.component';
import { ServerService } from './server.service';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    AdminViewComponent,
    ProducerViewComponent,
    ClientViewComponent,
    FormProducerComponent,
  ],
  imports: [BrowserModule],
  providers: [ServerService],
  bootstrap: [AppComponent],
})
export class AppModule {}
