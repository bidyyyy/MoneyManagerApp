using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MoneyManager.Models;

namespace MoneyManager.Services
{
    internal class CategoryService:ICategoryService
    {
        private readonly string filePath = Path.Combine(AppContext.BaseDirectory, "Categories.json");

        public async Task<List<Category>> LoadCategoriesAsync()
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

        public async Task SaveCategoryAsync(Category category)
        {
            var categories = await LoadCategoriesAsync();
            categories.Add(category);

            var json = JsonSerializer.Serialize(categories, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(filePath, json);
        }

        public async Task SaveCategoriesAsync(List<Category> categories)
        {
            var json = JsonSerializer.Serialize(categories, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(filePath, json);
        }
    }

}

