using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Models
{
    // Represents a model category
    internal class Category
    {
        public Guid CategoryId { get; set; } = Guid.NewGuid(); // Unique identifier for each category
        public string Name { get; set; } = string.Empty;// Name of the category
    }
}
