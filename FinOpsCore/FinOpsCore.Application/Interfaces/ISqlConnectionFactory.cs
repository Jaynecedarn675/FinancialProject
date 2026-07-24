using System.Data;

namespace FinOpsCore.Application.Interfaces;

public interface ISqlConnectionFactory
{
    IDbConnection GetOpenConnection();
}