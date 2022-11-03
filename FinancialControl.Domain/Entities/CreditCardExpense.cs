using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialControl.Domain.Entities
{
    public class CreditCardExpense : ExpenseBase
    {
        public uint Installments { get; private set; }

        public CreditCardExpense(string name, string? description, uint installments, decimal value, DateTime date) : base(name, description, value, date)
        {
            Installments = installments;
        }
    }
}
