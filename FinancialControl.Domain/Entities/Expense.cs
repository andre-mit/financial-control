using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialControl.Domain.Entities
{
    public class Expense : ExpenseBase
    {
        public DateTime DueDate { get; private set; }

        public Expense(string name, string? description, decimal value, DateTime date, DateTime dueDate) : base(name, description, value, date)
        {
            DueDate = dueDate;
        }
    }
}
