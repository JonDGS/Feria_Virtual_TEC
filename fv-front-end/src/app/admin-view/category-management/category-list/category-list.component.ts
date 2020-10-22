import { Component, OnInit } from '@angular/core';
import {ServerService} from '../../../server.service';
import {Category} from '../../../models/category.model';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
/**
 * This component works as a list of the available categories
 */
export class CategoryListComponent implements OnInit {
  public categoryL: Category[] = [];

  constructor(private serverService: ServerService) { }

  ngOnInit(): void {
    this.categoryL = this.serverService.categoryList;
  }

}
