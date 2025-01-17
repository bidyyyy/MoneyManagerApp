using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyManager.Models;

namespace MoneyManager.Services
{
    internal interface ICategoryService
    {
         
        Task SaveCategoryAsync(Category category);
        Task SaveCategoriesAsync(List<Category> categories);
        Task<List<Category>> LoadCategoriesAsync();

        

}
}
