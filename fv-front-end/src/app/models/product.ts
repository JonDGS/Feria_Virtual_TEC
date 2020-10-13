import {Category} from './category.model';

export class Product{
  constructor(public name: string,
              public category: Category,
              public image: string,
              public price: number,
              public unit: string,
              public availability: number){}
}
