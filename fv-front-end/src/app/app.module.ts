import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { AdminViewComponent } from './admin-view/admin-view.component';
import { ProducerViewComponent } from './producer-view/producer-view.component';
import { ClientViewComponent } from './client-view/client-view.component';
import { ProducerManagementComponent } from './admin-view/producer-management/producer-management.component';
import { ProducerListComponent } from './admin-view/producer-management/producer-list/producer-list.component';
import { ProducerDetailsComponent } from './admin-view/producer-management/producer-details/producer-details.component';
import { ProducerItemComponent } from './admin-view/producer-management/producer-list/producer-item/producer-item.component';

import { FormProducerComponent } from './producer-view/form-producer/form-producer.component';
import { ServerService } from './server.service';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    AdminViewComponent,
    ProducerViewComponent,
    ClientViewComponent,
    ProducerManagementComponent,
    ProducerListComponent,
    ProducerDetailsComponent,
    ProducerItemComponent,
    FormProducerComponent,
  ],
  imports: [BrowserModule],
  providers: [ServerService],
  bootstrap: [AppComponent],
})
export class AppModule {}
