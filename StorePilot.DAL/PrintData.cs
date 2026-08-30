using DevToolkit.Core.Results;
using DevToolkit.Data.Core;
using StorePilot.Core.Printing;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.DAL
{
    /// <summary>
    /// Read-only queries that assemble the four Printable* models straight from
    /// the views already defined in the schema (view_SalesInvoicesDetails,
    /// view_InvoicesItemsDetails, view_PaymentsDetails, view_PurchasesInvoicesDetails,
    /// view_SalesReturnItemsDetails) — no new views needed.
    ///
    /// NOTE: ConnectionFactory.CreateOpenConnection() below is a placeholder.
    /// Replace it with whatever connection-opening helper the rest of your DAL
    /// already uses, so this repository follows the exact same pattern.
    /// </summary>
    public static class PrintData
    {
        private static SQLiteConnection CreateOpenConnection()
        {
            // TODO: replace with your existing DAL connection helper, e.g.:
            // return ConnectionHelper.GetOpenConnection();
            var conn = new SQLiteConnection(DataConfiguration.ConnectionString);
            conn.Open();
            return conn;
        }
 
        public static Result<PrintableSalesInvoice> GetSalesInvoiceForPrint(
            int saleInvoiceId)
        {
            try
            {
                using (var conn = CreateOpenConnection())
                {
                    var invoice = new PrintableSalesInvoice { ReferenceID = saleInvoiceId };
 
                    // ---- Header ----
                    using (var cmd = new SQLiteCommand(
                        @"SELECT InvoiceID, InvoiceDate, InvoiceStatus, CustomerName, PaidAmount, TotalAmount, Notes
                          FROM view_SalesInvoicesDetails WHERE SaleInvoiceID = @id;", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", saleInvoiceId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                                return Result<PrintableSalesInvoice>.Failure("لم يتم العثور على فاتورة البيع المطلوبة.");
 
                            invoice.InvoiceID = reader.GetInt32(reader.GetOrdinal("InvoiceID"));
                            invoice.InvoiceDate = reader.GetDateTime(reader.GetOrdinal("InvoiceDate"));
                            invoice.StatusText = reader.GetString(reader.GetOrdinal("InvoiceStatus"));
                            invoice.PartyName = reader.IsDBNull(reader.GetOrdinal("CustomerName")) ? null : reader.GetString(reader.GetOrdinal("CustomerName"));
                            invoice.PaidAmount = Convert.ToDecimal(reader["PaidAmount"]);
                            invoice.TotalAmount = Convert.ToDecimal(reader["TotalAmount"]);
                            invoice.Notes = reader.IsDBNull(reader.GetOrdinal("Notes")) ? null : reader.GetString(reader.GetOrdinal("Notes"));
                        }
                    }
 
                    invoice.Items = LoadItems(conn, invoice.InvoiceID);
                    invoice.Payments = LoadPayments(conn, invoice.InvoiceID);
 
                    return Result<PrintableSalesInvoice>.Success(invoice);
                }
            }
            catch (Exception ex)
            {
                return Result<PrintableSalesInvoice>.Failure(
                    "حدث خطأ أثناء تجهيز بيانات فاتورة البيع للطباعة: " + ex.Message);
            }
        }
 
        public static Result<PrintablePurchaseInvoice> GetPurchaseInvoiceForPrint(
            int purchaseInvoiceId)
        {
            try
            {
                using (var conn = CreateOpenConnection())
                {
                    var invoice = new PrintablePurchaseInvoice { ReferenceID = purchaseInvoiceId };
 
                    using (var cmd = new SQLiteCommand(
                        @"SELECT InvoiceID, InvoiceDate, InvoiceStatus, SupplierName, PaidAmount, TotalAmount, Notes
                          FROM view_PurchasesInvoicesDetails WHERE PurchaseInvoiceID = @id;", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", purchaseInvoiceId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                                return Result<PrintablePurchaseInvoice>.Failure("لم يتم العثور على فاتورة الشراء المطلوبة.");
 
                            invoice.InvoiceID = reader.GetInt32(reader.GetOrdinal("InvoiceID"));
                            invoice.InvoiceDate = reader.GetDateTime(reader.GetOrdinal("InvoiceDate"));
                            invoice.StatusText = reader.GetString(reader.GetOrdinal("InvoiceStatus"));
                            invoice.PartyName = reader.IsDBNull(reader.GetOrdinal("SupplierName")) ? null : reader.GetString(reader.GetOrdinal("SupplierName"));
                            invoice.PaidAmount = Convert.ToDecimal(reader["PaidAmount"]);
                            invoice.TotalAmount = Convert.ToDecimal(reader["TotalAmount"]);
                            invoice.Notes = reader.IsDBNull(reader.GetOrdinal("Notes")) ? null : reader.GetString(reader.GetOrdinal("Notes"));
                        }
                    }
 
                    invoice.Items = LoadItems(conn, invoice.InvoiceID);
                    invoice.Payments = LoadPayments(conn, invoice.InvoiceID);
 
                    return Result<PrintablePurchaseInvoice>.Success(invoice);
                }
            }
            catch (Exception ex)
            {
                return Result<PrintablePurchaseInvoice>.Failure(
                    "حدث خطأ أثناء تجهيز بيانات فاتورة الشراء للطباعة: " + ex.Message);
            }
        }
 
        public static Result<PrintableSalesReturn> GetSalesReturnForPrint(int returnId)
        {
            try
            {
                using (var conn = CreateOpenConnection())
                {
                    var salesReturn = new PrintableSalesReturn { ReturnID = returnId };
 
                    using (var cmd = new SQLiteCommand(
                        @"SELECT sr.SalesInvoiceID, sr.ReturnDate, sr.TotalReturnAmount, sr.Notes
                          FROM SalesReturns sr WHERE sr.ReturnID = @id;", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", returnId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                                return Result<PrintableSalesReturn>.Failure("لم يتم العثور على إذن المرتجع المطلوب.");
 
                            salesReturn.RelatedSaleInvoiceReferenceID = reader.GetInt32(reader.GetOrdinal("SalesInvoiceID"));
                            salesReturn.ReturnDate = reader.GetDateTime(reader.GetOrdinal("ReturnDate"));
                            salesReturn.TotalReturnAmount = Convert.ToDecimal(reader["TotalReturnAmount"]);
                            salesReturn.Notes = reader.IsDBNull(reader.GetOrdinal("Notes")) ? null : reader.GetString(reader.GetOrdinal("Notes"));
                        }
                    }
 
                    using (var cmd = new SQLiteCommand(
                        @"SELECT ProductName, GroupName, UnitName, Quantity, UnitPrice
                          FROM view_SalesReturnItemsDetails WHERE ReturnID = @id;", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", returnId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                salesReturn.Items.Add(new PrintableLineItem
                                {
                                    ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                                    GroupName = reader.GetString(reader.GetOrdinal("GroupName")),
                                    UnitName = reader.GetString(reader.GetOrdinal("UnitName")),
                                    Quantity = Convert.ToDecimal(reader["Quantity"]),
                                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                                });
                            }
                        }
                    }
 
                    return Result<PrintableSalesReturn>.Success(salesReturn);
                }
            }
            catch (Exception ex)
            {
                return Result<PrintableSalesReturn>.Failure(
                    "حدث خطأ أثناء تجهيز بيانات إذن المرتجع للطباعة: " + ex.Message);
            }
        }
 
        public static Result<PrintablePaymentReceipt> GetPaymentReceiptForPrint(
            int paymentId)
        {
            try
            {
                using (var conn = CreateOpenConnection())
                {
                    var receipt = new PrintablePaymentReceipt { PaymentID = paymentId };
                    int invoiceId;
 
                    using (var cmd = new SQLiteCommand(
                        @"SELECT InvoiceID, PaymentDate, PaidAmount, MethodName, Notes
                          FROM view_PaymentsDetails WHERE PaymentID = @id;", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", paymentId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                                return Result<PrintablePaymentReceipt>.Failure("لم يتم العثور على إيصال السداد المطلوب.");
 
                            invoiceId = reader.GetInt32(reader.GetOrdinal("InvoiceID"));
                            receipt.RelatedInvoiceID = invoiceId;
                            receipt.PaymentDate = reader.GetDateTime(reader.GetOrdinal("PaymentDate"));
                            receipt.PaidAmount = Convert.ToDecimal(reader["PaidAmount"]);
                            receipt.MethodName = reader.GetString(reader.GetOrdinal("MethodName"));
                            receipt.Notes = reader.IsDBNull(reader.GetOrdinal("Notes")) ? null : reader.GetString(reader.GetOrdinal("Notes"));
                        }
                    }
 
                    // Figure out whether this payment belongs to a sales or a purchase invoice,
                    // and pull the type-specific reference number + party name + totals.
                    using (var cmd = new SQLiteCommand(
                        @"SELECT si.SaleInvoiceID AS RefID, cust.Name AS PartyName, 'فاتورة بيع' AS Kind,
                                 i.TotalAmount, i.PaidAmount
                          FROM Invoices i
                          JOIN SalesInvoices si ON si.InvoiceID = i.InvoiceID
                          LEFT JOIN view_CustomersDetails cust ON cust.CustomerID = si.CustomerID
                          WHERE i.InvoiceID = @invoiceId
                          UNION ALL
                          SELECT pi.PurchaseInvoiceID AS RefID, sup.Name AS PartyName, 'فاتورة شراء' AS Kind,
                                 i.TotalAmount, i.PaidAmount
                          FROM Invoices i
                          JOIN PurchasesInvoices pi ON pi.InvoiceID = i.InvoiceID
                          LEFT JOIN view_SuppliersDetails sup ON sup.SupplierID = pi.SupplierID
                          WHERE i.InvoiceID = @invoiceId;", conn))
                    {
                        cmd.Parameters.AddWithValue("@invoiceId", invoiceId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                                return Result<PrintablePaymentReceipt>.Failure("تعذر تحديد الفاتورة المرتبطة بهذا السداد.");
 
                            receipt.RelatedInvoiceReferenceID = reader.GetInt32(reader.GetOrdinal("RefID"));
                            receipt.PartyName = reader.IsDBNull(reader.GetOrdinal("PartyName")) ? null : reader.GetString(reader.GetOrdinal("PartyName"));
                            receipt.InvoiceKindLabel = reader.GetString(reader.GetOrdinal("Kind"));
                            receipt.InvoiceTotalAmount = Convert.ToDecimal(reader["TotalAmount"]);
                            receipt.InvoiceRemainingAmount = receipt.InvoiceTotalAmount - Convert.ToDecimal(reader["PaidAmount"]);
                        }
                    }
 
                    return Result<PrintablePaymentReceipt>.Success(receipt);
                }
            }
            catch (Exception ex)
            {
                return Result<PrintablePaymentReceipt>.Failure(
                    "حدث خطأ أثناء تجهيز إيصال السداد للطباعة: " + ex.Message);
            }
        }
 
        // ---------------------------------------------------------------
        // Shared helpers
        // ---------------------------------------------------------------
 
        private static List<PrintableLineItem> LoadItems(
            SQLiteConnection conn, 
            int invoiceId)
        {
            var items = new List<PrintableLineItem>();
            using (var cmd = new SQLiteCommand(
                @"SELECT ProductName, GroupName, UnitName, Quantity, UnitPrice
                  FROM view_InvoicesItemsDetails WHERE InvoiceID = @invoiceId;", conn))
            {
                cmd.Parameters.AddWithValue("@invoiceId", invoiceId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new PrintableLineItem
                        {
                            ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                            GroupName = reader.GetString(reader.GetOrdinal("GroupName")),
                            UnitName = reader.GetString(reader.GetOrdinal("UnitName")),
                            Quantity = Convert.ToDecimal(reader["Quantity"]),
                            UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                        });
                    }
                }
            }
            return items;
        }
 
        private static List<PrintablePayment> LoadPayments(
            SQLiteConnection conn, 
            int invoiceId)
        {
            var payments = new List<PrintablePayment>();
            using (var cmd = new SQLiteCommand(
                @"SELECT PaymentID, PaymentDate, PaidAmount, MethodName, Notes
                  FROM view_PaymentsDetails WHERE InvoiceID = @invoiceId AND Cancelled = 0
                  ORDER BY PaymentDate;", conn))
            {
                cmd.Parameters.AddWithValue("@invoiceId", invoiceId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        payments.Add(new PrintablePayment
                        {
                            PaymentID = reader.GetInt32(reader.GetOrdinal("PaymentID")),
                            PaymentDate = reader.GetDateTime(reader.GetOrdinal("PaymentDate")),
                            PaidAmount = Convert.ToDecimal(reader["PaidAmount"]),
                            MethodName = reader.GetString(reader.GetOrdinal("MethodName")),
                            Notes = reader.IsDBNull(reader.GetOrdinal("Notes")) ? null : reader.GetString(reader.GetOrdinal("Notes"))
                        });
                    }
                }
            }
            return payments;
        }
    }
}
