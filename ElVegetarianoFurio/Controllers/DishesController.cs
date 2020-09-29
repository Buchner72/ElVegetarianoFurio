using ElVegetarianoFurio.Models;
using ElVegetarianoFurio.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElVegetarianoFurio.Controllers
{
    // Daten von Backend to Frontend
    //Test Für GiTGub

    [ApiController]              //Sagt! Hier haben wir ein API-Controller, der Http Anfragen mit Daten beantwortet!
    [Route("api/[controller]")]     //Definiert die Route. Jede Methode ist von außen erreichbar (wenn public)

    public class DishesController : ControllerBase          //Methoden aufruf https://localhost:44322/api/dishes 
    {
        private readonly IDishRepository _repository;

        public DishesController(IDishRepository repository)
        {
            _repository = repository;
        }

        [HttpGet] //Zugewiesenes Http-Verb "HttpGet wird automatisch aufgerufen"
        public IEnumerable<Dish> Get()
        {

            #region Harte Codierung Daten

            //return new Dish[]
            //    {
            //        new Dish
            //        {
            //            Id=1,
            //            Name ="Ensalada Fantasia",
            //            Description="Satalt mit alles was in der Küche übrig war",
            //            Price=9.99,
            //            CategoryId=1
            //        }
            //    };

            #endregion

            return _repository.GetDishes();
        }

        //Gigt einen einzelnen Datensatz zurück
        //Damit das ASP.Net Framwork weiß, welcher Wert an den Parameter id als Argument übergeben werden muss. 
        [HttpGet("{id}")]                       //Als weterer Wert hinter api/controller übergebne wird. (api/dishes/1)
        public IActionResult Get(int id)        //IActionResult anstelle von "public Dish Get(int id)" wegen StatusCode 404, wenn ID nicht vorhanden.
        {
            var dish = _repository.GetDishById(id);
            if (dish == null)
            {
                return NotFound();       //Status: 404 Not Found
            }
            return Ok(dish);             //Status: 200 OK
        }


        //So ein Objekt wird Typischer weise im Body der Nachricht übergebn.
        //Dieshalb muss man dem Parameter mitteilen das er aus dem Bodey befüllt wird,
        //und nich aus dem Query
        [HttpPost] //Wenn man neue Datensätze anlegen möchte, verwendet man da Http-Verb "Post"
        public IActionResult Post([FromBody] Dish dish)  //ASP MVC Modelbinder. 
        {
            #region Einfacher Aufruf
            // var result = _repository.CreateDish(dish);
            // return Ok(result);

            //Schöner wre es aber dem Clien nicht nur sagen das alles erfolgreich war,
            //sondern im mitgebe das etwas erzeugt worden ist

            #endregion

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  //Status: 400 Bad Request 
            }

            var result = _repository.CreateDish(dish);
            return CreatedAtAction("Get", new { id = result.Id }, result);
        }


    }
}
