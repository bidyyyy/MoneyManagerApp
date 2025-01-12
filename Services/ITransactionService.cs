using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyManager.Models;

namespace MoneyManager.Services
{
    internal interface ITransactionService
    {

        Task SaveTransactionAsync(Transaction transactionItem);
        Task UpdateTransactionAsync(Transaction transactionItem);
        Task DeleteTransactionAsync(Guid transId);
        //Task MarkAsDoneAsync(Guid transId);
        Task<List<Transaction>> LoadTransactionAsync();
    }
}
