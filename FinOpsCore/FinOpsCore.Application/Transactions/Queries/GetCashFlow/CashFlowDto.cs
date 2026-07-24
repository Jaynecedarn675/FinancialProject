namespace FinOpsCore.Application.Transactions.Queries.GetCashFlow;

public class CashFlowDto
{
    public string MonthYear { get; set; } = string.Empty;
    public decimal TotalRecebido { get; set; }
    public decimal TotalPendente { get; set; }
}