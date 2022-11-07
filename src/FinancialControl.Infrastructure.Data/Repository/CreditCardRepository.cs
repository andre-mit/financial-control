using FinancialControl.Core.Data;
using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Repositories;

namespace FinancialControl.Infrastructure.Data.Repository;

public class CreditCardRepository: ICreditCardRepository
{
    private readonly ApplicationDbContext _context;

    public CreditCardRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public IUnitOfWork UnitOfWork { get; }
    
    public Task SaveAsync(CreditCard entity)
    {
        throw new NotImplementedException();
    }

    public Task<CreditCard> GetAsync(Guid id, Guid userId)
    {
        return _context.CreditCards.FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);
    }

    public Task<IEnumerable<CreditCard>> GetAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id, Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task AddExpenseAsync(Guid cardId, Guid userId, CreditCardExpense expense)
    {
        throw new NotImplementedException();
    }

    public Task RemoveExpenseAsync(Guid cardId, Guid userId, Guid expenseId)
    {
        throw new NotImplementedException();
    }
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}