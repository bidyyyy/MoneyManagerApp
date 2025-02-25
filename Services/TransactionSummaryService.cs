﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyManager.Models;

namespace MoneyManager.Services
{
    // To calculate the summary of transactions.
    public class TransactionSummaryService
        {
        // This method calculates the  summaries based on the list of transactions.
        public TransactionSummary CalculateSummary(List<Transaction> transactions)
            { 
                var totalOutflow = transactions.Where(t => t.Type == "Outflow").Sum(t => t.Amount);
                var totalDebt = transactions.Where(t => t.Type == "Debt").Sum(t => t.Amount);
                var paidDebt = transactions.Where(t => t.Type == "Debt" && t.IsPaid).Sum(t => t.Amount);
                var remainingDebt = totalDebt - paidDebt;
                var totalInflow = transactions.Where(t => t.Type == "Inflow").Sum(t => t.Amount);
                var totalBalance = totalInflow - totalOutflow + remainingDebt;
                var availableBalance = totalInflow - totalOutflow;
            // Return a TransactionSummary containing the calculated values
            return new TransactionSummary
                {
                    TotalOutflow = totalOutflow,
                    TotalDebt = totalDebt,
                    PaidDebt = paidDebt,
                    RemainingDebt = remainingDebt,
                    TotalInflow = totalInflow,
                    TotalBalance = totalBalance,
                    AvailableBalance = availableBalance
                };
            }
        }
    }
