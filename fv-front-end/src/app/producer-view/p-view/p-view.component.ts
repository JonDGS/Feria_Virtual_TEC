import { ServerService } from './../../server.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'p-view',
  templateUrl: './p-view.component.html',
  styleUrls: ['./p-view.component.css']
})
export class PViewComponent implements OnInit {
  products: any;

  constructor(private server : ServerService) { }

  ngOnInit(): void {
    this.getProdcuts();
  }
/*
  funtion: getProdcuts
  Description: get the list of products to fill the componets
  Params : 
  Return: listProducts fill
*/
  getProdcuts(){
      this.server.products().subscribe(res => {
        let products;
        products = res;
        this.products = JSON.parse(products)
        console.log(this.products)
      })
    }

}
