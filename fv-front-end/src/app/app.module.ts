import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
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
import { CategoryManagementComponent } from './admin-view/category-management/category-management.component';
import { CategoryListComponent } from './admin-view/category-management/category-list/category-list.component';
import { CategoryEditComponent } from './admin-view/category-management/category-list-changes/category-edit/category-edit.component';
import { CategoryListChangesComponent } from './admin-view/category-management/category-list-changes/category-list-changes.component';
import { CategoryCreateComponent } from './admin-view/category-management/category-list-changes/category-create/category-create.component';
import { LoginProducerComponent } from './producer-view/login-producer/login-producer.component';
import { SelectorComponent } from './producer-view/selector/selector.component';
import { PViewComponent } from './producer-view/p-view/p-view.component';
import { ZippyComponent } from './producer-view/zippy/zippy.component';
import { ClientFormComponent } from './client-view/client-form/client-form.component';
import { ClientLogInComponent } from './client-view/client-log-in/client-log-in.component';
import { ClientSelectorComponent } from './client-view/client-selector/client-selector.component';
import { AddProductComponent } from './producer-view/p-view/add-product/add-product.component';
import { EditProductComponent } from './producer-view/p-view/edit-product/edit-product.component';
import { FormsModule } from '@angular/forms';
import { CViewComponent } from './client-view/c-view/c-view.component';
import { CardsComponent } from './client-view/c-view/cards/cards.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { ProfileComponent } from './profile/profile.component';

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
    CategoryManagementComponent,
    CategoryListComponent,
    CategoryEditComponent,
    CategoryListChangesComponent,
    CategoryCreateComponent,
    LoginProducerComponent,
    SelectorComponent,
    PViewComponent,
    ZippyComponent,
    ClientFormComponent,
    ClientLogInComponent,
    ClientSelectorComponent,
    AddProductComponent,
    EditProductComponent,
    CViewComponent,
    CardsComponent,
    ShoppingCartComponent,
    ProfileComponent,
  ],
  imports: [BrowserModule,
            HttpClientModule,
            FormsModule
    ],
  providers: [ServerService],
  bootstrap: [AppComponent],
})
export class AppModule {}
