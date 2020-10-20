import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-dish-list',
  templateUrl: './dish-list.component.html',
  styleUrls: ['./dish-list.component.css']
})
export class DishListComponent implements OnInit {

  constructor(private route: ActivatedRoute) { }
    categoryId = 0;
    ngOnInit() {
      this.categoryId = +this.route.snapshot.paramMap.get('categoryId');
      //Das ergebnis von get ist immer ein string (kann ich an dieser stelle nicht zuweisen)
      //trick: ein string der eine Zahl beinhaltet an eine Zahl zuzuweisen ein fach ein +this
      // dadurch wird der string in eine Zahl umgewandelt
  }

}
