using FinancialControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialControl.Domain.Repositories;

public interface ICreditCardRepository
{
    Task<CreditCard> GetAsync(Guid id, Guid userId);
    Task<IEnumerable<CreditCard>> GetAsync(Guid userId);
    Task Save(CreditCard card);
    Task Delete(Guid id, Guid userId);

    Task AddExpense(Guid cardId, Guid userId, CreditCardExpense expense);
    Task RemoveExpense(Guid cardId, Guid userId, Guid expenseId);
}