using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElVegetarianoFurio.Models
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; } = new HashSet<Dish>();  //virtual für EF
    }
}