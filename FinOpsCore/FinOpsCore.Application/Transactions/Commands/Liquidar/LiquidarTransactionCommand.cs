using FinOpsCore.Domain.Common;
using MediatR;

namespace FinOpsCore.Application.Transactions.Commands.Liquidar;

// O Command carrega apenas os dados necessários para a ação
public class LiquidarTransactionCommand : IRequest<Result>
{
    public Guid TransactionId { get; set; }
    public DateTime LiquidationDate { get; set; }
}