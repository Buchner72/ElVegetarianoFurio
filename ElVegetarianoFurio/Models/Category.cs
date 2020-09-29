using System.Collections;
using System.Collections.Generic;

namespace ElVegetarianoFurio.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; } = new HashSet<Dish>();  //virtual für EF
    }
}