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

        public static Result<DataTable> GetSalesChart()
        {
            return Result<DataTable>.Failure("");
        }

        public static Result<DataTable> GetLowStockProducts()
        {
            return Result<DataTable>.Failure("");
        }

        public static Result<DataTable> GetRecentSales()
        {
            return Result<DataTable>.Failure("");
        }
    }
}
