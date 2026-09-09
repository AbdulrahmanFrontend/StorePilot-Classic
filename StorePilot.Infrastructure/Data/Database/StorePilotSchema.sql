PRAGMA foreign_keys = ON;


-- ============================================================
-- Reference Data
-- ============================================================

CREATE TABLE IF NOT EXISTS "Units" (
    "UnitId" INTEGER,
    "Unit" TEXT NOT NULL UNIQUE,
    PRIMARY KEY ("UnitId" AUTOINCREMENT)
) STRICT;


CREATE TABLE IF NOT EXISTS "Groups" (
    "GroupId" INTEGER,
    "Group" TEXT NOT NULL UNIQUE,
    PRIMARY KEY ("GroupId" AUTOINCREMENT)
) STRICT;


CREATE TABLE IF NOT EXISTS "PaymentMethods" (
    "MethodId" INTEGER,
    "Method" TEXT NOT NULL UNIQUE,
    PRIMARY KEY ("MethodId" AUTOINCREMENT)
) STRICT;


-- ============================================================
-- People
-- Shared identity data for customers and suppliers.
-- A person may be both a customer and a supplier.
-- ============================================================

CREATE TABLE IF NOT EXISTS "People" (
    "PersonId" INTEGER,
    "Name" TEXT NOT NULL UNIQUE,
    "Phone" TEXT UNIQUE,
    "Address" TEXT,
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Notes" TEXT,
    PRIMARY KEY ("PersonId" AUTOINCREMENT)
) STRICT;


-- ============================================================
-- Products
-- Products are master data.
-- Active = 0 prevents new transactions while preserving history.
-- ============================================================

CREATE TABLE IF NOT EXISTS "Products" (
    "ProductId" INTEGER,
    "Code" TEXT,
    "ProductName" TEXT NOT NULL,
    "Quantity" REAL NOT NULL DEFAULT 0 CHECK ("Quantity" >= 0),
    "MinQuantity" REAL NOT NULL DEFAULT 0 CHECK ("MinQuantity" >= 0),
    "SalePrice" REAL NOT NULL DEFAULT 0 CHECK ("SalePrice" >= 0),
    "PurchasePrice" REAL NOT NULL DEFAULT 0 CHECK ("PurchasePrice" >= 0),
    "UnitId" INTEGER NOT NULL,
    "GroupId" INTEGER NOT NULL,
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Notes" TEXT,
    "Active" INTEGER NOT NULL DEFAULT 1 CHECK ("Active" IN (0, 1)),
    PRIMARY KEY ("ProductId" AUTOINCREMENT),
    FOREIGN KEY ("UnitId") REFERENCES "Units" ("UnitId"),
    FOREIGN KEY ("GroupId") REFERENCES "Groups" ("GroupId")
) STRICT;


-- ============================================================
-- Customers
-- Person contains identity/contact information.
-- Customer contains customer-specific business information.
-- ============================================================

CREATE TABLE IF NOT EXISTS "Customers" (
    "CustomerId" INTEGER,
    "PersonId" INTEGER NOT NULL UNIQUE,
    "TotalSales" REAL NOT NULL DEFAULT 0 CHECK ("TotalSales" >= 0),
    "TotalReturns" REAL NOT NULL DEFAULT 0 CHECK ("TotalReturns" >= 0),
    "TotalPaid" REAL NOT NULL DEFAULT 0 CHECK ("TotalPaid" >= 0),
    "Balance" REAL NOT NULL DEFAULT 0 CHECK ("Balance" >= 0),
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Notes" TEXT,
    "Active" INTEGER NOT NULL DEFAULT 1 CHECK ("Active" IN (0, 1)),
    PRIMARY KEY ("CustomerId" AUTOINCREMENT),
    FOREIGN KEY ("PersonId") REFERENCES "People" ("PersonId")
) STRICT;


-- ============================================================
-- Suppliers
-- Person contains identity/contact information.
-- Supplier contains supplier-specific business information.
-- ============================================================

CREATE TABLE IF NOT EXISTS "Suppliers" (
    "SupplierId" INTEGER,
    "PersonId" INTEGER NOT NULL UNIQUE,
    "TotalPurchases" REAL NOT NULL DEFAULT 0 CHECK ("TotalPurchases" >= 0),
    "TotalReturns" REAL NOT NULL DEFAULT 0 CHECK ("TotalReturns" >= 0),
    "TotalPaid" REAL NOT NULL DEFAULT 0 CHECK ("TotalPaid" >= 0),
    "Balance" REAL NOT NULL DEFAULT 0 CHECK ("Balance" >= 0),
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Notes" TEXT,
    "Active" INTEGER NOT NULL DEFAULT 1 CHECK ("Active" IN (0, 1)),
    PRIMARY KEY ("SupplierId" AUTOINCREMENT),
    FOREIGN KEY ("PersonId") REFERENCES "People" ("PersonId")
) STRICT;


-- ============================================================
-- Cash Transactions
-- Represents actual cash movements.
-- ============================================================

CREATE TABLE IF NOT EXISTS "CashTransactions" (
    "TransactionId" INTEGER,
    "TransactionDate" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "TransactionType" INTEGER NOT NULL,
    "Amount" REAL NOT NULL CHECK ("Amount" > 0),
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Notes" TEXT,
    "Cancelled" INTEGER NOT NULL DEFAULT 0 CHECK ("Cancelled" IN (0, 1)),
    PRIMARY KEY ("TransactionId" AUTOINCREMENT)
) STRICT;


-- ============================================================
-- Stock Transactions
-- Represents actual stock movements.
-- ============================================================

CREATE TABLE IF NOT EXISTS "StockTransactions" (
    "TransactionId" INTEGER,
    "ProductId" INTEGER NOT NULL,
    "TransactionDate" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "TransactionType" INTEGER NOT NULL,
    "Quantity" REAL NOT NULL CHECK ("Quantity" > 0),
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Notes" TEXT,
    "Cancelled" INTEGER NOT NULL DEFAULT 0 CHECK ("Cancelled" IN (0, 1)),
    PRIMARY KEY ("TransactionId" AUTOINCREMENT),
    FOREIGN KEY ("ProductId") REFERENCES "Products" ("ProductId")
) STRICT;


-- ============================================================
-- Sales
-- ============================================================

CREATE TABLE IF NOT EXISTS "SaleInvoices" (
    "SaleInvoiceId" INTEGER,
    "InvoiceNumber" TEXT UNIQUE,
    "InvoiceDate" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "CustomerId" INTEGER,
    "InvoiceStatus" INTEGER NOT NULL,
    "TotalAmount" REAL NOT NULL CHECK ("TotalAmount" > 0),
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Notes" TEXT,
    "Cancelled" INTEGER NOT NULL DEFAULT 0 CHECK ("Cancelled" IN (0, 1)),
    "CashTransactionId" INTEGER UNIQUE,
    PRIMARY KEY ("SaleInvoiceId" AUTOINCREMENT),
    FOREIGN KEY ("CustomerId") REFERENCES "Customers" ("CustomerId"),
    FOREIGN KEY ("CashTransactionId") REFERENCES "CashTransactions" ("TransactionId")
) STRICT;


CREATE TABLE IF NOT EXISTS "SaleInvoiceItems" (
    "ItemId" INTEGER,
    "SaleInvoiceId" INTEGER NOT NULL,
    "ProductId" INTEGER NOT NULL,
    "Quantity" REAL NOT NULL CHECK ("Quantity" > 0),
    "UnitPrice" REAL NOT NULL CHECK ("UnitPrice" > 0),
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "StockTransactionId" INTEGER NOT NULL UNIQUE,
    PRIMARY KEY ("ItemId" AUTOINCREMENT),
    UNIQUE ("SaleInvoiceId", "ProductId"),
    FOREIGN KEY ("SaleInvoiceId") REFERENCES "SaleInvoices" ("SaleInvoiceId"),
    FOREIGN KEY ("ProductId") REFERENCES "Products" ("ProductId"),
    FOREIGN KEY ("StockTransactionId") REFERENCES "StockTransactions" ("TransactionId")
) STRICT;


-- ============================================================
-- Quotations
-- ============================================================

CREATE TABLE IF NOT EXISTS "Quotations" (
    "QuotationId" INTEGER,
    "QuotationNumber" TEXT UNIQUE,
    "QuotationDate" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "QuotationStatus" INTEGER NOT NULL,
    "CustomerId" INTEGER,
    "TotalAmount" REAL NOT NULL CHECK ("TotalAmount" > 0),
    "ConvertedInvoiceId" INTEGER UNIQUE,
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Notes" TEXT,
    "Cancelled" INTEGER NOT NULL DEFAULT 0 CHECK ("Cancelled" IN (0, 1)),
    PRIMARY KEY ("QuotationId" AUTOINCREMENT),
    FOREIGN KEY ("CustomerId") REFERENCES "Customers" ("CustomerId"),
    FOREIGN KEY ("ConvertedInvoiceId") REFERENCES "SaleInvoices" ("SaleInvoiceId")
) STRICT;


CREATE TABLE IF NOT EXISTS "QuotationItems" (
    "ItemId" INTEGER,
    "QuotationId" INTEGER NOT NULL,
    "ProductId" INTEGER NOT NULL,
    "Quantity" REAL NOT NULL CHECK ("Quantity" > 0),
    "UnitPrice" REAL NOT NULL CHECK ("UnitPrice" > 0),
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY ("ItemId" AUTOINCREMENT),
    UNIQUE ("QuotationId", "ProductId"),
    FOREIGN KEY ("QuotationId") REFERENCES "Quotations" ("QuotationId"),
    FOREIGN KEY ("ProductId") REFERENCES "Products" ("ProductId")
) STRICT;


-- ============================================================
-- Purchases
-- ============================================================

CREATE TABLE IF NOT EXISTS "PurchaseInvoices" (
    "PurchaseInvoiceId" INTEGER,
    "InvoiceNumber" TEXT UNIQUE,
    "InvoiceDate" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "SupplierId" INTEGER,
    "InvoiceStatus" INTEGER NOT NULL,
    "TotalAmount" REAL NOT NULL CHECK ("TotalAmount" > 0),
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Notes" TEXT,
    "Cancelled" INTEGER NOT NULL DEFAULT 0 CHECK ("Cancelled" IN (0, 1)),
    "CashTransactionId" INTEGER UNIQUE,
    PRIMARY KEY ("PurchaseInvoiceId" AUTOINCREMENT),
    FOREIGN KEY ("SupplierId") REFERENCES "Suppliers" ("SupplierId"),
    FOREIGN KEY ("CashTransactionId") REFERENCES "CashTransactions" ("TransactionId")
) STRICT;


CREATE TABLE IF NOT EXISTS "PurchaseInvoiceItems" (
    "ItemId" INTEGER,
    "PurchaseInvoiceId" INTEGER NOT NULL,
    "ProductId" INTEGER NOT NULL,
    "Quantity" REAL NOT NULL CHECK ("Quantity" > 0),
    "UnitPrice" REAL NOT NULL CHECK ("UnitPrice" > 0),
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "StockTransactionId" INTEGER NOT NULL UNIQUE,
    PRIMARY KEY ("ItemId" AUTOINCREMENT),
    UNIQUE ("PurchaseInvoiceId", "ProductId"),
    FOREIGN KEY ("PurchaseInvoiceId") REFERENCES "PurchaseInvoices" ("PurchaseInvoiceId"),
    FOREIGN KEY ("ProductId") REFERENCES "Products" ("ProductId"),
    FOREIGN KEY ("StockTransactionId") REFERENCES "StockTransactions" ("TransactionId")
) STRICT;


-- ============================================================
-- Sale Returns
-- ============================================================

CREATE TABLE IF NOT EXISTS "SaleReturns" (
    "SaleReturnId" INTEGER,
    "ReturnNumber" TEXT UNIQUE,
    "ReturnDate" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "CustomerId" INTEGER NOT NULL,
    "TotalAmount" REAL NOT NULL CHECK ("TotalAmount" > 0),
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Notes" TEXT,
    "Cancelled" INTEGER NOT NULL DEFAULT 0 CHECK ("Cancelled" IN (0, 1)),
    "CashTransactionId" INTEGER UNIQUE,
    PRIMARY KEY ("SaleReturnId" AUTOINCREMENT),
    FOREIGN KEY ("CustomerId") REFERENCES "Customers" ("CustomerId"),
    FOREIGN KEY ("CashTransactionId") REFERENCES "CashTransactions" ("TransactionId")
) STRICT;


CREATE TABLE IF NOT EXISTS "SaleReturnItems" (
    "ItemId" INTEGER,
    "SaleReturnId" INTEGER NOT NULL,
    "SourceInvoiceItemId" INTEGER NOT NULL,
    "Quantity" REAL NOT NULL CHECK ("Quantity" > 0),
    "UnitPrice" REAL NOT NULL CHECK ("UnitPrice" > 0),
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "StockTransactionId" INTEGER NOT NULL UNIQUE,
    PRIMARY KEY ("ItemId" AUTOINCREMENT),
    UNIQUE ("SaleReturnId", "SourceInvoiceItemId"),
    FOREIGN KEY ("SaleReturnId") REFERENCES "SaleReturns" ("SaleReturnId"),
    FOREIGN KEY ("SourceInvoiceItemId") REFERENCES "SaleInvoiceItems" ("ItemId"),
    FOREIGN KEY ("StockTransactionId") REFERENCES "StockTransactions" ("TransactionId")
) STRICT;


-- ============================================================
-- Purchase Returns
-- ============================================================

CREATE TABLE IF NOT EXISTS "PurchaseReturns" (
    "PurchaseReturnId" INTEGER,
    "ReturnNumber" TEXT UNIQUE,
    "ReturnDate" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "SupplierId" INTEGER NOT NULL,
    "TotalAmount" REAL NOT NULL CHECK ("TotalAmount" > 0),
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Notes" TEXT,
    "Cancelled" INTEGER NOT NULL DEFAULT 0 CHECK ("Cancelled" IN (0, 1)),
    "CashTransactionId" INTEGER UNIQUE,
    PRIMARY KEY ("PurchaseReturnId" AUTOINCREMENT),
    FOREIGN KEY ("SupplierId") REFERENCES "Suppliers" ("SupplierId"),
    FOREIGN KEY ("CashTransactionId") REFERENCES "CashTransactions" ("TransactionId")
) STRICT;


CREATE TABLE IF NOT EXISTS "PurchaseReturnItems" (
    "ItemId" INTEGER,
    "PurchaseReturnId" INTEGER NOT NULL,
    "SourceInvoiceItemId" INTEGER NOT NULL,
    "Quantity" REAL NOT NULL CHECK ("Quantity" > 0),
    "UnitPrice" REAL NOT NULL CHECK ("UnitPrice" > 0),
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "StockTransactionId" INTEGER NOT NULL UNIQUE,
    PRIMARY KEY ("ItemId" AUTOINCREMENT),
    UNIQUE ("PurchaseReturnId", "SourceInvoiceItemId"),
    FOREIGN KEY ("PurchaseReturnId") REFERENCES "PurchaseReturns" ("PurchaseReturnId"),
    FOREIGN KEY ("SourceInvoiceItemId") REFERENCES "PurchaseInvoiceItems" ("ItemId"),
    FOREIGN KEY ("StockTransactionId") REFERENCES "StockTransactions" ("TransactionId")
) STRICT;


-- ============================================================
-- Payments
-- ============================================================

CREATE TABLE IF NOT EXISTS "CustomerPayments" (
    "PaymentId" INTEGER,
    "ReceiptNumber" TEXT UNIQUE,
    "PaymentDate" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "PaymentMethodId" INTEGER NOT NULL,
    "Amount" REAL NOT NULL CHECK ("Amount" > 0),
    "CustomerId" INTEGER NOT NULL,
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Notes" TEXT,
    "Cancelled" INTEGER NOT NULL DEFAULT 0 CHECK ("Cancelled" IN (0, 1)),
    "CashTransactionId" INTEGER NOT NULL UNIQUE,
    PRIMARY KEY ("PaymentId" AUTOINCREMENT),
    FOREIGN KEY ("PaymentMethodId") REFERENCES "PaymentMethods" ("MethodId"),
    FOREIGN KEY ("CustomerId") REFERENCES "Customers" ("CustomerId"),
    FOREIGN KEY ("CashTransactionId") REFERENCES "CashTransactions" ("TransactionId")
) STRICT;


CREATE TABLE IF NOT EXISTS "SupplierPayments" (
    "PaymentId" INTEGER,
    "ReceiptNumber" TEXT UNIQUE,
    "PaymentDate" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "PaymentMethodId" INTEGER NOT NULL,
    "Amount" REAL NOT NULL CHECK ("Amount" > 0),
    "SupplierId" INTEGER NOT NULL,
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Notes" TEXT,
    "Cancelled" INTEGER NOT NULL DEFAULT 0 CHECK ("Cancelled" IN (0, 1)),
    "CashTransactionId" INTEGER NOT NULL UNIQUE,
    PRIMARY KEY ("PaymentId" AUTOINCREMENT),
    FOREIGN KEY ("PaymentMethodId") REFERENCES "PaymentMethods" ("MethodId"),
    FOREIGN KEY ("SupplierId") REFERENCES "Suppliers" ("SupplierId"),
    FOREIGN KEY ("CashTransactionId") REFERENCES "CashTransactions" ("TransactionId")
) STRICT;


-- ============================================================
-- Opening Customer Debts
-- These represent balances that existed before StorePilot.
-- They are not sales invoices and do not create cash movements.
-- ============================================================

CREATE TABLE IF NOT EXISTS "OldCustomerDebts" (
    "DebtId" INTEGER,
    "CustomerId" INTEGER NOT NULL,
    "RecordDate" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Amount" REAL NOT NULL CHECK ("Amount" > 0),
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Notes" TEXT,
    "Cancelled" INTEGER NOT NULL DEFAULT 0 CHECK ("Cancelled" IN (0, 1)),
    PRIMARY KEY ("DebtId" AUTOINCREMENT),
    FOREIGN KEY ("CustomerId") REFERENCES "Customers" ("CustomerId")
) STRICT;