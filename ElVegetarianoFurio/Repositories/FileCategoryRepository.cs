using ElVegetarianoFurio.Models;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;

namespace ElVegetarianoFurio.Repositories
{
    public class FileCategoryRepository : ICategoryRepository
    {

        private readonly string _path;
        private readonly string _dishPath;

        public FileCategoryRepository(IWebHostEnvironment env)
        {
            _path = Path.Combine(env.ContentRootPath, "data", "categories.json");
            _dishPath = Path.Combine(env.ContentRootPath, "data", "dishes.json");
        }

        public Category CreateCategory(Category category)
        {
            var categpries = GetCategories()?.ToList() ?? new List<Category>();

            if (categpries.Count == 0)
            {
                category.Id = 1;              
            }
            else
            {
                category.Id = categpries.Max(x => x.Id) + 1;
            }
            categpries.Add(category);
            var option = new JsonSerializerOptions
            {
                WriteIndented = true  
            };
            var json = JsonSerializer.Serialize(categpries, option);
            File.WriteAllText(_path, json);
            return category;
        }

        public void DeleteCategory(int id)
        {
            var categories = GetCategories().Where(x => x.Id != id);
            var option = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(categories, option);
            File.WriteAllText(_path, json);
        }

        public IEnumerable<Category> GetCategories()
        {
            var json = File.ReadAllText(_path);
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,             
                PropertyNameCaseInsensitive = true     
            };

            var categories = JsonSerializer.Deserialize<Category[]>(json, options);

            json = File.ReadAllText(_dishPath);
            var dishes = JsonSerializer.Deserialize<Dish[]>(json, options);

            foreach (var category in categories)
            {
                category.Dishes = dishes.Where(x => x.CategoryId == category.Id).ToList();
            }

            return categories;

        }

        public Category GetCategoryById(int id)
        {
            return GetCategories()?.SingleOrDefault(x => x.Id == id);
        }

        public Category UpdateCategory(Category category)
        {
            var categories = GetCategories().ToList();
            var categoryToUpdate = categories.SingleOrDefault(x => x.Id == category.Id);
            categoryToUpdate.Name = category.Name;
            categoryToUpdate.Description = category.Description;

            var option = new JsonSerializerOptions
            {
                WriteIndented = true  
            };
            var json = JsonSerializer.Serialize(categories, option);
            File.WriteAllText(_path, json);
            return categoryToUpdate;
        }
    }
}
