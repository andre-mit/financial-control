using FinancialControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialControl.Core.Data;

namespace FinancialControl.Domain.Repositories;

public interface ICreditCardRepository : IRepository<CreditCard>
{
    Task<CreditCard> GetAsync(Guid id, Guid userId);
    Task<IEnumerable<CreditCard>> GetAsync(Guid userId);
    Task DeleteAsync(Guid id, Guid userId);

    Task AddExpenseAsync(Guid cardId, Guid userId, CreditCardExpense expense);
    Task RemoveExpenseAsync(Guid cardId, Guid userId, Guid expenseId);
}