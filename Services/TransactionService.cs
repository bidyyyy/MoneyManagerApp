using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MoneyManager.Models;
namespace MoneyManager.Services
{
    //To store the transacton data in JSON file
    internal class TransactionService : ITransactionService
    {
        private readonly string filePath = Path.Combine(AppContext.BaseDirectory, "Transaction.json");// Path to the JSON file storing transaction data.
        public async Task<List<Transaction>> LoadTransactionAsync() // Loads the list of transactions from the JSON file.
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    return new List<Transaction>();
                }

                var json = await File.ReadAllTextAsync(filePath);

                if (string.IsNullOrWhiteSpace(json))
                {
                    return new List<Transaction>();
                }
                // Deserialize the JSON string into a list of transactions.
                return JsonSerializer.Deserialize<List<Transaction>>(json) ?? new List<Transaction>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        // Adds a new transaction to the list of transactions and saves it to the JSON file.
        public async Task SaveTransactionAsync(Transaction transactionItem)
        {
            try
            {
                var transactions = await LoadTransactionAsync();// Load existing transactions.
                transactions.Add(transactionItem); // Add the new transaction to the list.
                await SaveTransactionAsync(transactions);// Save the updated list of transactions.
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        // Updates an existing transaction in the list and saves the updated list to the JSON file.
        public async Task UpdateTransactionAsync(Transaction transactionItem)
        {
            try
            {
                var transactions = await LoadTransactionAsync();
                var existingTransaction = transactions.FirstOrDefault(t => t.TaskId == transactionItem.TaskId);

                if (existingTransaction != null)
                {
                    existingTransaction.Title = transactionItem.Title;
                    existingTransaction.Amount = transactionItem.Amount;
                    existingTransaction.Tag = transactionItem.Tag;
                    existingTransaction.CustomTag = transactionItem.CustomTag;
                    existingTransaction.Date = transactionItem.Date;
                    existingTransaction.Description = transactionItem.Description;
                    existingTransaction.Type = transactionItem.Type;
                    existingTransaction.DueDate = transactionItem.DueDate;
                    existingTransaction.Source = transactionItem.Source;
                    existingTransaction.IsPaid = transactionItem.IsPaid;
                    await SaveTransactionAsync(transactions);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        // Saves the new list of transactions to the JSON file.
        private async Task SaveTransactionAsync(List<Transaction> transactions)
        {
            try
            {
                var json = JsonSerializer.Serialize(transactions, new JsonSerializerOptions { WriteIndented = true });

                await File.WriteAllTextAsync(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        // Deletes a transaction by its TaskId and saves the updated list to the JSON file.
        public async Task DeleteTransactionAsync(Guid transactionId)
        {
            try
            {
                var transactions = await LoadTransactionAsync();
                var transactionToDelete = transactions.FirstOrDefault(t => t.TaskId == transactionId);

                if (transactionToDelete != null)
                {
                    transactions.Remove(transactionToDelete);
                    await SaveTransactionAsync(transactions);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
       