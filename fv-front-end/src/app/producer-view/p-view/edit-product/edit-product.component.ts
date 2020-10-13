import { Component, OnInit, Input} from '@angular/core';
import {Product} from '../../../models/product';
import {Category} from '../../../models/category.model';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {
  @Input() product: Product;

  constructor() { }

  ngOnInit(): void {
    this.product = new Product('papas', new Category('verduras', 6), '', 800, 'kg', 100);
  }
}
