import {Component, OnInit, ViewChild} from '@angular/core';
import {NgForm} from '@angular/forms';
import {Product} from '../../../models/product';
import {Category} from '../../../models/category.model';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  @ViewChild('newProductForm') productForm: NgForm;
  product: Product;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  onSubmit(newProductForm){
    this.product = new Product(
      this.productForm.value.newProductName,
      new Category('', 0),
      '',
      this.productForm.value.newProductPrice,
      this.productForm.value.newProductUnit,
      this.productForm.value.newProductAvailability);

    console.log(this.product);

    this.productForm.reset();

    this.http.post(
      'http://localhost:4200/#', this.product
    ).subscribe(responseData => {
      console.log(responseData);
      });
  }
}
