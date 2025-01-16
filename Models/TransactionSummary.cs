using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Models
{
    public class TransactionSummary
    {
        public decimal TotalInflow { get; set; }
        public decimal TotalOutflow { get; set; }
        public decimal TotalDebt { get; set; }
        public decimal PaidDebt { get; set; }
        public decimal RemainingDebt { get; set; }
        public decimal TotalBalance { get; set; }
    }
}
