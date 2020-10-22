import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {ServerService} from '../../../../server.service';
import {Category} from '../../../../models/category.model';

@Component({
  selector: 'app-category-create',
  templateUrl: './category-create.component.html',
  styleUrls: ['./category-create.component.css']
})
/**
 * This component is used for adding a new category
 */
export class CategoryCreateComponent implements OnInit {
  @ViewChild('nameInput') nameInputRef: ElementRef;

  constructor(private serverService: ServerService) { }

  ngOnInit(): void {
  }

  /**
   * This method is called when the form for adding a new category is submitted
   */
  onAddCategory(){
    const catName = this.nameInputRef.nativeElement.value;
    const catID = this.serverService.categoryID;
    const newCategory = new Category(catName, catID);
    this.serverService.addCategory(newCategory);
  }
}
