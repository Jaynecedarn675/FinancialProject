using Dapper;
using FinOpsCore.Application.Interfaces;
using FinOpsCore.Domain.Common;
using MediatR;

namespace FinOpsCore.Application.Transactions.Queries.GetCashFlow;

public class GetCashFlowQueryHandler : IRequestHandler<GetCashFlowQuery, Result<IEnumerable<CashFlowDto>>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    // Injetamos apenas a conexão com o banco, nada de Entity Framework aqui!
    public GetCashFlowQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IEnumerable<CashFlowDto>>> Handle(GetCashFlowQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.GetOpenConnection();

        // Query crua e otimizada para o banco (Sintaxe Oracle/SQL Padrão)
        const string sql = @"
            SELECT 
                TO_CHAR(DueDate, 'MM/YYYY') AS MonthYear,
                SUM(CASE WHEN Status = 2 THEN Amount ELSE 0 END) AS TotalRecebido,
                SUM(CASE WHEN Status = 1 THEN Amount ELSE 0 END) AS TotalPendente
            FROM Transactions
            WHERE EXTRACT(YEAR FROM DueDate) = @Year
            GROUP BY TO_CHAR(DueDate, 'MM/YYYY')
            ORDER BY MonthYear";

        var result = await connection.QueryAsync<CashFlowDto>(sql, new { request.Year });

        return Result<IEnumerable<CashFlowDto>>.Success(result);
    }
}