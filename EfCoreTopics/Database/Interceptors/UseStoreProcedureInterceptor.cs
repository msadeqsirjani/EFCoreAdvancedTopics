using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EfCoreTopics.Database.Interceptors;

public class UseStoreProcedureInterceptor : DbCommandInterceptor
{
    public override async ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result,
        CancellationToken cancellationToken = new())
    {
        if (!command.CommandText.StartsWith("-- UseSp", StringComparison.CurrentCultureIgnoreCase))
            return new InterceptionResult<DbDataReader>();

        var sqlCommand = new StringBuilder();

        await using var reader = await command.ExecuteReaderAsync(CommandBehavior.KeyInfo, cancellationToken);
        var schemaTable = await reader.GetSchemaTableAsync(cancellationToken);

        if (schemaTable == null)
            return new InterceptionResult<DbDataReader>();

        var tableName = schemaTable.Rows[0]["BaseTableName"] as string;

        if (string.IsNullOrEmpty(tableName))
            return new InterceptionResult<DbDataReader>();

        sqlCommand.AppendLine(
            $"IF NOT EXISTS(SELECT * FROM [sys].[objects] WHERE [type] = 'P' AND OBJECT_ID = OBJECT_ID('dbo.{tableName}SP'));");
        
        sqlCommand.AppendLine($"EXEC ('CREATE PROCEDURE [dbo].[{tableName}SP] AS {command.CommandText}');");

        sqlCommand.AppendLine($"EXEC [dbo].[{tableName}SP];");

        command.CommandText = sqlCommand.ToString();

        return new InterceptionResult<DbDataReader>();
    }
}