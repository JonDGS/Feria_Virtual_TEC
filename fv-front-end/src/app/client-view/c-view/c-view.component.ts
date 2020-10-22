import { ServerService } from './../../server.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'c-view',
  templateUrl: './c-view.component.html',
  styleUrls: ['./c-view.component.css']
})
export class CViewComponent{
  products: any;

  constructor(private server:ServerService) { 
    this.getProdructs();
  }
/*
  funtion: getProdructs
  Description: get all the products and suscribe to parse the message to json object 
  Params : 
  Return: void
*/
  getProdructs(){
    this.server.products().subscribe( list =>{
      let products;
      products = list;
      this.products = JSON.parse(products);
      console.log(this.products[0].pName)
      }

    )
  }

}
