using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MoneyManager.Models;

namespace MoneyManager.Services
{ 
    //To store the data of category using JSON file 
    internal class CategoryService:ICategoryService
    {
        private readonly string filePath = Path.Combine(AppContext.BaseDirectory, "Categories.json");// Path to the JSON file storing category data.

        public async Task<List<Category>> LoadCategoriesAsync()// Loads the list of categories from the JSON file.
        {
            if (!File.Exists(filePath))
            {
                return new List<Category>();
            }

            var json = await File.ReadAllTextAsync(filePath);
            return string.IsNullOrWhiteSpace(json)
                ? new List<Category>()
                : JsonSerializer.Deserialize<List<Category>>(json) ?? new List<Category>();
        }
        // Saves each category to the JSON file.
        public async Task SaveCategoryAsync(Category category)
        {
            var categories = await LoadCategoriesAsync();
            categories.Add(category);// Add the new category to the list.

            var json = JsonSerializer.Serialize(categories, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(filePath, json);
        }
        // Overwrites the current file with the new list of categories.
        public async Task SaveCategoriesAsync(List<Category> categories)
        {
            var json = JsonSerializer.Serialize(categories, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(filePath, json);
        }
    }

}

