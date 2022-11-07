using FinancialControl.Core.Entities;

namespace FinancialControl.Core.Data;

public interface IRepository<in T> : IDisposable where T : Entity
{
    IUnitOfWork UnitOfWork { get; }
    
    Task SaveAsync(T entity);
}