import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Category } from '../category/category';
import { CategoryService } from '../category/category.service';

@Component({
  selector: 'app-dish-list',
  templateUrl: './dish-list.component.html',
  styleUrls: ['./dish-list.component.css']
})
export class DishListComponent implements OnInit {

  //constructor(private route: ActivatedRoute) { }
  constructor(private route: ActivatedRoute, private categoryService: CategoryService) { }


   // categoryId = 0;
    category: Category;

    ngOnInit() {
     // this.categoryId = +this.route.snapshot.paramMap.get('categoryId');
      // Das ergebnis von get ist immer ein string (kann ich an dieser stelle nicht zuweisen)
      // trick: ein string der eine Zahl beinhaltet an eine Zahl zuzuweisen einfach ein +
      // dadurch wird der string in eine Zahl umgewandelt

      //Hier machen wir aus dem Feld eine Konstante
      // und füge statt desen ein Feld namens category ein
     
      const categoryId = +this.route.snapshot.paramMap.get('categoryId');

      //Nun kann ich hier die Category initialisieren
      //Dazu muss ich noch ein Category service im constructor initialisieren
      //Der wird benötigt damit ich über diesen Service die Category anhand des URL parameters laden kann
      this.categoryService
        .getCategory(categoryId)
        .subscribe(category => this.category = category); //subscrpbe bekommt dann ein category übergeben, die weis ich dann meiner category zu
      //soweit ahbe ich dann auch das laden der Datem implementiert
      //jetzt fehlt nurmehr die darstellung (dish-list.component.html)



  }

}
