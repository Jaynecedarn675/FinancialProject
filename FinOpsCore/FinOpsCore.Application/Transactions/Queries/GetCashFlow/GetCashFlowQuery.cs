using FinOpsCore.Domain.Common;
using MediatR;

namespace FinOpsCore.Application.Transactions.Queries.GetCashFlow;

public class GetCashFlowQuery : IRequest<Result<IEnumerable<CashFlowDto>>>
{
    public int Year { get; set; }
}