using ElVegetarianoFurio.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ElVegetarianoFurio.Repositories
{
    public class FileDishRepository : IDishRepository
    {
        private readonly string _path;

        public FileDishRepository(IWebHostEnvironment env)
        {
            _path = Path.Combine(env.ContentRootPath, "data", "dishes.json");
        }

        public Dish CreateDish(Dish dish)
        {
            var dishes = GetDishes()?.ToList() ?? new List<Dish>();

            if (dishes.Count == 0)
            {
                dish.Id = 1;
            }
            else
            {
                dish.Id = dishes.Max(x => x.Id) + 1;
            }
            dishes.Add(dish);
            var option = new JsonSerializerOptions
            {
                WriteIndented = true  // Zeilenumbruch im Textfile
            };
            var json = JsonSerializer.Serialize(dishes, option);
            File.WriteAllText(_path, json);
            return dish;
        }

        public Dish DeleteDish(int id)
        {
            throw new NotImplementedException();
        }

        public Dish GetDishById(int id)
        {
            return GetDishes()?.SingleOrDefault(x => x.Id == id); //(elvis operator) Gibt ein Null zurückgeben wenn id nicht vorhanden
        }

        public IEnumerable<Dish> GetDishes()
        {
            // var jsonString = File.ReadAllText(_path);
            // var weatherForecast = System.Text.Json.JsonSerializer.Deserialize<Dish[]>(jsonString);

            var json = File.ReadAllText(_path);

            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,             //true: Wenn ein zusätzliches Komma am Ende einer Liste von JSON-Values in einem Objekt oder Array zulässig ist (und ignoriert wird)
                PropertyNameCaseInsensitive = true      //true: So vergleichen Sie Propertys unter Berücksichtigung der Groß-/Kleinschreibung
            };
            //var dishes = JsonSerializer.Deserialize<Dish[]>(json);  //Funkt nicht
            var dishes = JsonSerializer.Deserialize<Dish[]>(json, options);

            return dishes;
        }

        public Dish UpdateDish(Dish dish)
        {
            throw new NotImplementedException();
        }
    }

}
