using DevToolkit.Core.Results;
using DevToolkit.Data.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.DAL
{
    public static class DashboardDAL
    {
        //used
        public static Result<DataTable> GetSummary()
        {
            string Query = @"SELECT
                    (
                        SELECT COUNT(*) FROM Products WHERE Active = 1
                    ) AS ProductsCount,

                    (
                        SELECT COUNT(*) FROM Customers WHERE Active = 1
                    ) AS CustomersCount,

                    (
                        SELECT COUNT(*) FROM Suppliers WHERE Active = 1
                    ) AS SuppliersCount,

                    (
                        SELECT COUNT(*) FROM view_SalesInvoicesDetails
                        WHERE Cancelled = 0 
                            AND DATE(InvoiceDate) = DATE('now','localtime')
                    ) AS TodayInvoices,

                    (
                        SELECT IFNULL(SUM(TotalAmount),0)
                        FROM view_SalesInvoicesDetails
                        WHERE Cancelled = 0
                            AND DATE(InvoiceDate) = DATE('now','localtime')
                    ) AS TodaySales,

                    (
                        SELECT IFNULL(SUM(TotalAmount),0)
                        FROM view_PurchasesInvoicesDetails
                        WHERE Cancelled = 0
                            AND DATE(InvoiceDate) = DATE('now','localtime')
                    ) AS TodayPurchases,

                    (
                        SELECT IFNULL(SUM(TotalAmount - PaidAmount),0) 
                        FROM view_SalesInvoicesDetails
                        WHERE Cancelled = 0 AND InvoiceStatus = 'آجل'
                    ) AS TotalDebts;";

            return DbManager.Current?.GetDataTable(CommandType.Text, Query);
        }

        //used
        public static Result<DataTable> GetChartData()
        {
            string Query = @"SELECT
                STRFTIME('%Y-%m', InvoiceDate) AS Period,
                SUM(TotalAmount) AS TotalSales
                FROM view_SalesInvoicesDetails
                WHERE
                    Cancelled = 0
                    AND InvoiceDate >= DATETIME('now','-12 months')
                GROUP BY STRFTIME('%Y-%m', InvoiceDate)
                ORDER BY Period;";

            return DbManager.Current?.GetDataTable(CommandType.Text, Query);
        }

        //used
        public static Result<DataTable> GetLowStockProducts()
        {
            string Query = @"SELECT ProductName, Quantity, MinQuantity FROM Products
                WHERE Active = 1 AND Quantity <= MinQuantity
                ORDER BY MinQuantity - Quantity DESC
                LIMIT 10;";

            return DbManager.Current.GetDataTable(CommandType.Text, Query);
        }

        public static Result<DataTable> GetRecentSales()
        {
            string Query= @"SELECT InvoiceID, SaleInvoiceID, InvoiceDate, CustomerName,
                TotalAmount FROM view_SalesInvoicesDetails
                WHERE Cancelled = 0
                ORDER BY SaleInvoiceID DESC
                LIMIT 10;";

            return DbManager.Current?.GetDataTable(CommandType.Text, Query);
        }
    }
}
