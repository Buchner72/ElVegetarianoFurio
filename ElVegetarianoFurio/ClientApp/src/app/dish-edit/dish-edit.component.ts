import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { DishService } from '../dish/dish.service';
import { Dish } from '../dish/dish';

@Component({
  selector: 'app-dish-edit',
  templateUrl: './dish-edit.component.html',
  styleUrls: ['./dish-edit.component.css']
})
export class DishEditComponent implements OnInit {

  dish: Dish;

  constructor(private route: ActivatedRoute, private location: Location, private dishService: DishService) { }

  ngOnInit() {
    const dishId = +this.route.snapshot.paramMap.get('dishId');
    this.dishService
      .getDish(dishId)
      .subscribe(dish => this.dish = dish);
  }

  saveDish() {
    this.dishService
      .updateDish(this.dish)
      .subscribe(() => this.back());
  }

  back() {
    this.location.back();
  }

  delete() {
    this.dishService
      .deleteDish(this.dish.id)
      .subscribe(() => this.back());
  }

}
