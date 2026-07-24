using FinOpsCore.Domain.Entities;

namespace FinOpsCore.Domain.Interfaces;

public interface ITransactionRepository
{
    IUnitOfWork UnitOfWork { get; }
    Task AddAsync(Transaction transaction);
    Task<Transaction?> GetByIdAsync(Guid id);
    void Update(Transaction transaction);
}