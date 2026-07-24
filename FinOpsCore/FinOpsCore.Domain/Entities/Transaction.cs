using FinOpsCore.Domain.Common;
using FinOpsCore.Domain.Enums;

namespace FinOpsCore.Domain.Entities;

public class Transaction
{
    public Guid Id { get; private set; }
    public string? Description { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime DueDate { get; private set; }
    public DateTime? LiquidationDate { get; private set; }
    public TransactionStatus? Status { get; private set; }
    
    // Propriedade para controlar a concorrência no Entity Framework (Optimistic Concurrency)
    public byte[]? RowVersion { get; private set; } 

    // Construtor vazio necessário apenas para o EF Core
    protected Transaction() { }

    private Transaction(string description, decimal amount, DateTime dueDate)
    {
        Id = Guid.NewGuid();
        Description = description;
        Amount = amount;
        DueDate = dueDate;
        Status = TransactionStatus.Pendente;
    }

    public static Result<Transaction> Create(string description, decimal amount, DateTime dueDate)
    {
        if (string.IsNullOrWhiteSpace(description))
            return Result<Transaction>.Failure("A descrição é obrigatória.");

        if (amount <= 0)
            return Result<Transaction>.Failure("O valor deve ser maior que zero.");

        var transaction = new Transaction(description, amount, dueDate);
        return Result<Transaction>.Success(transaction);
    }

    public Result Liquidar(DateTime dataLiquidadacao)
    {
        if (Status == TransactionStatus.Liquidada)
            return Result.Failure("Esta transação já foi liquidada.");

        if (Status == TransactionStatus.Cancelada)
            return Result.Failure("Não é possível liquidar uma transação cancelada.");

        if (dataLiquidadacao > DateTime.UtcNow)
            return Result.Failure("Não é possível liquidar uma transação com data futura.");

        Status = TransactionStatus.Liquidada;
        LiquidationDate = dataLiquidadacao;

        return Result.Success();
    }
}