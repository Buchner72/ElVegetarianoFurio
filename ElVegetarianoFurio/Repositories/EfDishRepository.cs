using ElVegetarianoFurio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElVegetarianoFurio.Repositories
{
    public class EfDishRepository : IDishRepository
    {
        private readonly VegiContext _vegiContext;

        public EfDishRepository(VegiContext vegiContext)
        {
            _vegiContext = vegiContext;
        }

        public Dish CreateDish(Dish dish)
        {
            _vegiContext.Dishes.Add(dish);
            _vegiContext.SaveChanges();
            return dish;
        }

        public void DeleteDish(int id)
        {
            var dish = _vegiContext.Dishes.Find(id);
            _vegiContext.Dishes.Remove(dish);
            _vegiContext.SaveChanges();
        }

        public Dish GetDishById(int id)
        {
            var dish = _vegiContext.Dishes.Find(id);
            return dish;
        }

        public IEnumerable<Dish> GetDishes()
        {
            var dishes = _vegiContext.Dishes.AsNoTracking().ToList();
            return dishes;
        }

        public Dish UpdateDish(Dish dish)
        {
            var dishToUpdate = _vegiContext.Dishes.Find(dish.Id);
            dishToUpdate.Name = dish.Name;
            dishToUpdate.Description = dish.Description;
            dishToUpdate.Price = dish.Price;
            dishToUpdate.CategoryId = dish.CategoryId;
            _vegiContext.SaveChanges();
            return dish;
        }
    }
}
