using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElVegetarianoFurio.Models
{
    public class VegiContext : DbContext

    {
        //Zugriggsschnittstelle zur Datenbank
        public VegiContext(DbContextOptions<VegiContext> options): base(options)
        {

        }  

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
