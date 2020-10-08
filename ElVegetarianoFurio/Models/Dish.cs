using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ElVegetarianoFurio.Models
{
    public class Dish
    {
        public int Id { get; set; } // Das EF hat eine konvention das besagt: Wenn ein Feld entweder Id heißt, oder so heißt wie die Klasse und auf Id endet, dann ist diese Feld immer der Primär-Schlüssel
                                    //Im Fall eines Nummerischen Wertes wird davon ausgegeangen, dass es eine Identity-Spalte in ihrer Datenbank ist (Deren Id-Wert automatisch hochgezählt wird von der Datenbank)
        [Required]                  //Durch Required ist es in der Datenbank nicht Null
        [MaxLength(100)]
        public string Name { get; set; } // Stringfelder: Wenn hier nicht angepasst wird, würde EF varchar(max) verwenden
       
        [MaxLength(250)]
        public string Description { get; set; }

        [Range(0, 25)]
        public double Price { get; set; }

        public int CategoryId { get; set; } //Bedeutet für das EF CategoryId ein Fremdschöüssel werden wird zu der Tabelle Category
      
        [JsonIgnore] // Sonst Fehler im Postman GetCategories
        public Category Category { get; set; }

    }
}
