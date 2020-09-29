using ElVegetarianoFurio.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElVegetarianoFurio.Repositories
{
    public interface IDishRepository
    {
        IEnumerable<Dish> GetDishes();
        Dish GetDishById(int id);
        Dish CreateDish(Dish dish);
        Dish UpdateDish(Dish dish);
        Dish DeleteDish(int id);
    }
}
