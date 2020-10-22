import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-dish-edit',
  templateUrl: './dish-edit.component.html',
  styleUrls: ['./dish-edit.component.css']
})
export class DishEditComponent implements OnInit {

  //

  constructor(private route: ActivatedRoute, private location: Location) { }

  ngOnInit() {
    const dishId = +this.route.snapshot.paramMap.get('dishId');
  }

  saveDish() {

  }

  back() {
    this.location.back();
  }

}
