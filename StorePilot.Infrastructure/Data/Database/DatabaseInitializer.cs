using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Reflection;

namespace StorePilot.Infrastructure.Data.Database;

public static class DatabaseInitializer
{
    private const string SchemaResourceName =
        "StorePilot.Infrastructure.Data.Database.StorePilotSchema.sql";

    public static async Task InitializeAsync(
        StorePilotDbContext dbContext,
        CancellationToken cancellationToken = default)
    {
        // We intentionally use the same EF Core connection for:
        // 1. Enabling SQLite foreign keys
        // 2. Executing the schema
        // This guarantees that PRAGMA foreign_keys applies to the
        // connection used by the database initialization.
        var connection = dbContext.Database.GetDbConnection();

        await connection.OpenAsync(cancellationToken);

        try
        {
            // SQLite foreign-key enforcement is connection-specific.
            // Therefore it must be enabled for every opened connection.
            await using (var pragmaCommand = connection.CreateCommand())
            {
                pragmaCommand.CommandText = "PRAGMA foreign_keys = ON;";
                await pragmaCommand.ExecuteNonQueryAsync(
                    cancellationToken);
            }

            // If the database already contains the schema, there is
            // nothing to initialize.
            if (await IsDatabaseInitializedAsync(
                connection,
                cancellationToken))
                return;

            await using var transaction =
                await connection.BeginTransactionAsync(
                    cancellationToken);

            try
            {
                var schema = await LoadSchemaAsync();

                await using var command = connection.CreateCommand();

                command.Transaction = transaction;
                command.CommandText = schema;

                await command.ExecuteNonQueryAsync(cancellationToken);

                await transaction.CommitAsync(cancellationToken);
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }
        finally
        {
            await connection.CloseAsync();
        }
    }

    private static async Task<bool> IsDatabaseInitializedAsync(
    DbConnection connection,
    CancellationToken cancellationToken)
    {
        const string sql = """
        SELECT COUNT(*)
        FROM sqlite_master
        WHERE type = 'table'
          AND name IN (
              'Units',
              'Groups',
              'PaymentMethods',
              'People',
              'Products',
              'Customers',
              'Suppliers',
              'CashTransactions',
              'StockTransactions',
              'SaleInvoices',
              'SaleInvoiceItems',
              'Quotations',
              'QuotationItems',
              'PurchaseInvoices',
              'PurchaseInvoiceItems',
              'SaleReturns',
              'SaleReturnItems',
              'PurchaseReturns',
              'PurchaseReturnItems',
              'CustomerPayments',
              'SupplierPayments',
              'OldCustomerDebts'
          );
        """;

        await using var command = connection.CreateCommand();

        command.CommandText = sql;

        var result = await command.ExecuteScalarAsync(cancellationToken);

        return Convert.ToInt32(result) == 22;
    }


    private static async Task<string> LoadSchemaAsync()
    {
        var assembly = Assembly.GetExecutingAssembly();

        await using var stream =
            assembly.GetManifestResourceStream(SchemaResourceName)
            ?? throw new InvalidOperationException(
                $"Database schema resource '{SchemaResourceName}' " +
                $"was not found.");

        using var reader = new StreamReader(stream);

        return await reader.ReadToEndAsync();
    }
}
