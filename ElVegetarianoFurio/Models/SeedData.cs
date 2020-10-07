using ElVegetarianoFurio.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElVegetarianoFurio.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider )
        {
            using (var vegiContext = new VegiContext(
                serviceProvider.GetRequiredService<DbContextOptions<VegiContext>>()))
            {
                if(vegiContext.Dishes.Any())
                {
                    return;
                }

                var categoriesRepository = 
                    new FileCategoryRepository(serviceProvider.GetRequiredService<IWebHostEnvironment>());

                var categories = categoriesRepository.GetCategories().ToList();

                //Da in der Datenbank die ID vergeben wird.
                categories.ForEach(c =>
                {
                    c.Id = 0;
                    foreach (var dish in c.Dishes)
                    {
                        dish.Id = 0;
                        dish.CategoryId = 0;
                    }
                });

                vegiContext.Categories.AddRange(categories);
                vegiContext.SaveChanges();

            }
                
        }
    }
}
