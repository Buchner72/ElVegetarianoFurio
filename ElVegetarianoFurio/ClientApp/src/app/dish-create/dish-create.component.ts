import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../category/category.service';
import { Dish } from '../dish/dish';
import { DishService } from '../dish/dish.service';
import { Location } from '@angular/common'
import { Category } from '../category/category';

@Component({
  selector: 'app-dish-create',
  templateUrl: './dish-create.component.html',
  styleUrls: ['./dish-create.component.css']
})
export class DishCreateComponent implements OnInit {
  dish: Dish = {} as Dish;
  categories: Category[] = [];

  constructor(private dishService: DishService,
    private categoryService: CategoryService,
    private location:Location) { }

  ngOnInit() {
    this.categoryService
      .getCategories()
      .subscribe(categories=> this.categories = categories);
  }

  saveDish() {
    this.dishService
      .createDish(this.dish)
      .subscribe(() => this.back());       
  }

  back() {
    this.location.back();
  }

}
