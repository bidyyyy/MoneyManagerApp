using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MoneyManager.Models;

namespace MoneyManager.Services
{
    internal class TransactionService : ITransactionService
    {
        private readonly string filePath = Path.Combine(AppContext.BaseDirectory, "Transaction.json");

        public async Task<List<Transaction>> LoadTransactionAsync()
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

                return JsonSerializer.Deserialize<List<Transaction>>(json) ?? new List<Transaction>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task SaveTransactionAsync(Transaction transactionItem)
        {
            try
            {
                var transactions = await LoadTransactionAsync();
                transactions.Add(transactionItem);
                await SaveTransactionAsync(transactions);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
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

        public async Task DeleteTransactionAsync(Guid taskId)
        {
            try
            {
                var transactions = await LoadTransactionAsync();
                transactions.RemoveAll(t => t.TaskId == taskId);
                await SaveTransactionAsync(transactions);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /* public async Task MarkAsDoneAsync(Guid taskId)
         {
             try
             {
                 var transactions = await LoadTransactionAsync();
                 var task = transactions.FirstOrDefault(t => t.TaskId == taskId);

                 if (task != null)
                 {
                     task.IsCompleted = true;

                     var updatedTransactions = transactions.Select(t => t.TaskId == taskId ? task : t).ToList();
                     await SaveTransactionAsync(updatedTransactions);
                 }


             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
                 throw;
             }
         }*/


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

    }

}
       



