namespace FinancialControl.Core.Data;

public interface IUnitOfWork : IDisposable
{
    bool Commit();
    Task<bool> CommitAsync();
    void Rollback();
}