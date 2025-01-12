using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Models
{
    public class Transaction
    {
        public Guid TaskId { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Amount { get; set; }

        public DateTime Date { get; set; } = DateTime.Today;

        public string? Tag { get; set; } = string.Empty;

        public string? CustomTag { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime? DueDate { get; set; }
        public String Source { get; set; } = string.Empty;
        public bool IsPaid { get; set; } = false; 
    }
}
