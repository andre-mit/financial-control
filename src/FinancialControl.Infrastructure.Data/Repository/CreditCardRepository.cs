using FinancialControl.Core.Data;
using FinancialControl.Domain.Entities;
using FinancialControl.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinancialControl.Infrastructure.Data.Repository;

public class CreditCardRepository : ICreditCardRepository
{
    private readonly ApplicationDbContext _context;

    public CreditCardRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public Task SaveAsync(CreditCard entity)
    {
        throw new NotImplementedException();
    }

    public async Task<CreditCard?> GetAsync(Guid id, Guid userId)
    {
        return await _context.CreditCards.FirstOrDefaultAsync(c => c.User != null && c.Id == id && c.User.Id == userId);
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
        _context.Dispose();
        UnitOfWork.Dispose();
    }
}