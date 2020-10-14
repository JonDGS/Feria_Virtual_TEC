import {Component, OnInit, ViewChild} from '@angular/core';
import {NgForm} from '@angular/forms';
import {Product} from '../../../models/product';
import {Category} from '../../../models/category.model';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  @ViewChild('newProductForm') productForm: NgForm;
  product: Product;

  constructor() { }

  ngOnInit(): void {
  }

  onSubmit(){
    this.product = new Product(
      this.productForm.value.newProductName,
      new Category('', 0),
      '',
      this.productForm.value.newProductPrice,
      this.productForm.value.newProductUnit,
      this.productForm.value.newProductAvailability);

    console.log(this.product);

    this.productForm.reset();
  }
}
