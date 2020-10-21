import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from './category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }

  //Nur in der Lage eine aktuelle Liste der Categorien zu laden (keine dishes)
  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>('/api/categories');
  }

  getCategory(id: number): Observable<Category> {
    return this.http.get<Category>(`api/categories/${id}`); //Backstick schreibeweise "`" Axion (rechts oben von ß), somit kann man ${id} als platzhalter in den String schreiben
    //Jetzt noch die category.ts datei erweitern (dishes:Dish[];)
    //Weiter in der dish-list.component.ts
  }



}

//Hauptaufgabe des Service soll sein die Liste der Categorien zurückzugeben
// Dies geschied über einen HttP aufruf
// Bedeutet zunächst in den Constroctor dass Http-Module inizieren

// Durch das "private" im Construktor, wird für mich direkt eine Eigenschaft angelegt
// Als nächstes benötigen wir eine Methode die mir die Categorien zurück gibt "getCategories"

// return this.http.get('/api/categories'); damit wären wir schon annähernd fertig
// allerdings sieht es so aus, dass diese Methode "get" Generisch ist,
// ich kann also angeben was für einen Typ ich zurückbekomme
// der Typ ist "category" muss aber erst angelegt werden
// Dazu wird ein Interface angelegt "category.ts"
// in Typscript ist es gang und gebe das kein "I" für Interface vorran gestellt wird. Wie z.B. in C# 
// Ich bekomme alse den Typ <Category[]> zurück

// Was nämlich "get" zurück gibt das ist jetzt ein Observable vom Typ <Category[]>
// Damit ist die Methode korrekt Typisiert

// So ein Observable hat die Eigenheit, dass der eigentliche Aufruf "this.http.get<Category[]>('/api/categories')"
// erst abgeschickz wird, wenn sich jemand drauf subscript
// bedeutet ein Observable ist ein Objekt was irgentwann einmal eine Antwort geben wird
// und wenn ich die wissen will muss ich mich drauf registrieren, sonst erhalte ich nichts.

// weiter in category.component.ts

// Wichtig: services müssen immer als Provider registriert werden (app.module.ts)

