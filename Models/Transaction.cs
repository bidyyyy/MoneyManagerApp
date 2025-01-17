using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Models
{
    // Represents transaction
    public class Transaction
    {
        public Guid TaskId { get; set; }// Unique identifier for each transaction.
        public string Title { get; set; } = string.Empty;// Holds the name of the transaction
        public decimal Amount { get; set; }// Holds the Amount of money of the transaction.
        public DateTime Date { get; set; } = DateTime.Today;// Date when the transaction occurred with setting today's date as default date.
        public string? Tag { get; set; } = string.Empty; //  tag associated with the transaction for categorization
        public string? CustomTag { get; set; } = string.Empty; 
        public string? Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;// Type of transaction
        public DateTime? DueDate { get; set; }// Due date when users selects debts
        public String Source { get; set; } = string.Empty; // Source of the transaction
        public bool IsPaid { get; set; } = false; // Indicates whether the transaction has been paid or not, default is set to false

    }
}
