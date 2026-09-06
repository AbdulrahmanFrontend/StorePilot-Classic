-- ============================================================
-- StorePilot Database Schema
-- SQLite
--
-- This script creates the initial database structure.
-- Business rules and transactional behavior belong to the
-- application/backend layer, not to this schema script.
-- ============================================================

PRAGMA foreign_keys = ON;


-- ============================================================
-- 1. Lookup / Master Tables
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
-- 2. Main Master Data
-- ============================================================

CREATE TABLE IF NOT EXISTS "Products" (
    "ProductId" INTEGER,
    "Code" TEXT,
    "ProductName" TEXT NOT NULL,
    "Quantity" REAL NOT NULL DEFAULT 0
        CHECK ("Quantity" >= 0),
    "MinQuantity" REAL NOT NULL DEFAULT 0
        CHECK ("MinQuantity" >= 0),
    "SalePrice" REAL NOT NULL DEFAULT 0
        CHECK ("SalePrice" >= 0),
    "PurchasePrice" REAL NOT NULL DEFAULT 0
        CHECK ("PurchasePrice" >= 0),
    "UnitId" INTEGER NOT NULL,
    "GroupId" INTEGER NOT NULL,
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Notes" TEXT,
    "Active" INTEGER NOT NULL DEFAULT 1
        CHECK ("Active" IN (0, 1)),

    PRIMARY KEY ("ProductId" AUTOINCREMENT),

    FOREIGN KEY ("GroupId")
        REFERENCES "Groups" ("GroupId"),

    FOREIGN KEY ("UnitId")
        REFERENCES "Units" ("UnitId")
) STRICT;


CREATE TABLE IF NOT EXISTS "Customers" (
    "CustomerId" INTEGER,
    "Name" TEXT NOT NULL UNIQUE,
    "Phone" TEXT UNIQUE,
    "Address" TEXT,
    "TotalSales" REAL NOT NULL DEFAULT 0
        CHECK ("TotalSales" >= 0),
    "TotalReturns" REAL NOT NULL DEFAULT 0
        CHECK ("TotalReturns" >= 0),
    "TotalPaid" REAL NOT NULL DEFAULT 0
        CHECK ("TotalPaid" >= 0),
    "Balance" REAL NOT NULL DEFAULT 0
        CHECK ("Balance" >= 0),
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Notes" TEXT,
    "Active" INTEGER NOT NULL DEFAULT 1
        CHECK ("Active" IN (0, 1)),

    PRIMARY KEY ("CustomerId" AUTOINCREMENT)
) STRICT;


CREATE TABLE IF NOT EXISTS "Suppliers" (
    "SupplierId" INTEGER,
    "Name" TEXT NOT NULL UNIQUE,
    "Phone" TEXT UNIQUE,
    "Address" TEXT,
    "TotalPurchases" REAL NOT NULL DEFAULT 0
        CHECK ("TotalPurchases" >= 0),
    "TotalPaid" REAL NOT NULL DEFAULT 0
        CHECK ("TotalPaid" >= 0),
    "Balance" REAL NOT NULL DEFAULT 0
        CHECK ("Balance" >= 0),
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Notes" TEXT,
    "Active" INTEGER NOT NULL DEFAULT 1
        CHECK ("Active" IN (0, 1)),

    PRIMARY KEY ("SupplierId" AUTOINCREMENT)
) STRICT;


-- ============================================================
-- 3. Transaction History
-- ============================================================

CREATE TABLE IF NOT EXISTS "CashTransactions" (
    "TransactionId" INTEGER,
    "TransactionDate" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "TransactionType" INTEGER NOT NULL,
    "Amount" REAL NOT NULL
        CHECK ("Amount" > 0),
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Notes" TEXT,
    "Cancelled" INTEGER NOT NULL DEFAULT 0
        CHECK ("Cancelled" IN (0, 1)),

    PRIMARY KEY ("TransactionId" AUTOINCREMENT)
) STRICT;


CREATE TABLE IF NOT EXISTS "StockTransactions" (
    "TransactionId" INTEGER,
    "ProductId" INTEGER NOT NULL,
    "TransactionDate" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "TransactionType" INTEGER NOT NULL,
    "Quantity" REAL NOT NULL
        CHECK ("Quantity" > 0),
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Notes" TEXT,
    "Cancelled" INTEGER NOT NULL DEFAULT 0
        CHECK ("Cancelled" IN (0, 1)),

    PRIMARY KEY ("TransactionId" AUTOINCREMENT),

    FOREIGN KEY ("ProductId")
        REFERENCES "Products" ("ProductId")
) STRICT;


-- ============================================================
-- 4. Sales
-- ============================================================

CREATE TABLE IF NOT EXISTS "SaleInvoices" (
    "SaleInvoiceId" INTEGER,
    "InvoiceNumber" TEXT UNIQUE,
    "InvoiceDate" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "CustomerId" INTEGER,
    "InvoiceStatus" INTEGER NOT NULL,
    "TotalAmount" REAL NOT NULL
        CHECK ("TotalAmount" > 0),
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Notes" TEXT,
    "Cancelled" INTEGER NOT NULL DEFAULT 0
        CHECK ("Cancelled" IN (0, 1)),
    "CashTransactionId" INTEGER UNIQUE,

    PRIMARY KEY ("SaleInvoiceId" AUTOINCREMENT),

    FOREIGN KEY ("CashTransactionId")
        REFERENCES "CashTransactions" ("TransactionId"),

    FOREIGN KEY ("CustomerId")
        REFERENCES "Customers" ("CustomerId")
) STRICT;


CREATE TABLE IF NOT EXISTS "SaleInvoiceItems" (
    "ItemId" INTEGER,
    "SaleInvoiceId" INTEGER NOT NULL,
    "ProductId" INTEGER NOT NULL,
    "Quantity" REAL NOT NULL
        CHECK ("Quantity" > 0),
    "UnitPrice" REAL NOT NULL
        CHECK ("UnitPrice" > 0),
    "StockTransactionId" INTEGER NOT NULL UNIQUE,

    PRIMARY KEY ("ItemId" AUTOINCREMENT),

    UNIQUE ("SaleInvoiceId", "ProductId"),

    FOREIGN KEY ("ProductId")
        REFERENCES "Products" ("ProductId"),

    FOREIGN KEY ("SaleInvoiceId")
        REFERENCES "SaleInvoices" ("SaleInvoiceId"),

    FOREIGN KEY ("StockTransactionId")
        REFERENCES "StockTransactions" ("TransactionId")
) STRICT;


-- ============================================================
-- 5. Quotations
-- ============================================================

CREATE TABLE IF NOT EXISTS "Quotations" (
    "QuotationId" INTEGER,
    "QuotationNumber" TEXT UNIQUE,
    "QuotationDate" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "QuotationStatus" INTEGER NOT NULL,
    "CustomerId" INTEGER,
    "TotalAmount" REAL NOT NULL
        CHECK ("TotalAmount" > 0),
    "ConvertedInvoiceId" INTEGER UNIQUE,
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Notes" TEXT,
    "Cancelled" INTEGER NOT NULL DEFAULT 0
        CHECK ("Cancelled" IN (0, 1)),

    PRIMARY KEY ("QuotationId" AUTOINCREMENT),

    FOREIGN KEY ("ConvertedInvoiceId")
        REFERENCES "SaleInvoices" ("SaleInvoiceId"),

    FOREIGN KEY ("CustomerId")
        REFERENCES "Customers" ("CustomerId")
) STRICT;


CREATE TABLE IF NOT EXISTS "QuotationItems" (
    "ItemId" INTEGER,
    "QuotationId" INTEGER NOT NULL,
    "ProductId" INTEGER NOT NULL,
    "Quantity" REAL NOT NULL
        CHECK ("Quantity" > 0),
    "UnitPrice" REAL NOT NULL
        CHECK ("UnitPrice" > 0),

    PRIMARY KEY ("ItemId" AUTOINCREMENT),

    UNIQUE ("QuotationId", "ProductId"),

    FOREIGN KEY ("ProductId")
        REFERENCES "Products" ("ProductId"),

    FOREIGN KEY ("QuotationId")
        REFERENCES "Quotations" ("QuotationId")
) STRICT;


-- ============================================================
-- 6. Purchases
-- ============================================================

CREATE TABLE IF NOT EXISTS "PurchaseInvoices" (
    "PurchaseInvoiceId" INTEGER,
    "InvoiceNumber" TEXT UNIQUE,
    "InvoiceDate" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "SupplierId" INTEGER,
    "InvoiceStatus" INTEGER NOT NULL,
    "TotalAmount" REAL NOT NULL
        CHECK ("TotalAmount" > 0),
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Notes" TEXT,
    "Cancelled" INTEGER NOT NULL DEFAULT 0
        CHECK ("Cancelled" IN (0, 1)),
    "CashTransactionId" INTEGER UNIQUE,

    PRIMARY KEY ("PurchaseInvoiceId" AUTOINCREMENT),

    FOREIGN KEY ("CashTransactionId")
        REFERENCES "CashTransactions" ("TransactionId"),

    FOREIGN KEY ("SupplierId")
        REFERENCES "Suppliers" ("SupplierId")
) STRICT;


CREATE TABLE IF NOT EXISTS "PurchaseInvoiceItems" (
    "ItemId" INTEGER,
    "PurchaseInvoiceId" INTEGER NOT NULL,
    "ProductId" INTEGER NOT NULL,
    "Quantity" REAL NOT NULL
        CHECK ("Quantity" > 0),
    "UnitPrice" REAL NOT NULL
        CHECK ("UnitPrice" > 0),
    "StockTransactionId" INTEGER NOT NULL UNIQUE,

    PRIMARY KEY ("ItemId" AUTOINCREMENT),

    UNIQUE ("PurchaseInvoiceId", "ProductId"),

    FOREIGN KEY ("ProductId")
        REFERENCES "Products" ("ProductId"),

    FOREIGN KEY ("PurchaseInvoiceId")
        REFERENCES "PurchaseInvoices" ("PurchaseInvoiceId"),

    FOREIGN KEY ("StockTransactionId")
        REFERENCES "StockTransactions" ("TransactionId")
) STRICT;


-- ============================================================
-- 7. Sales Returns
-- ============================================================

CREATE TABLE IF NOT EXISTS "SaleReturns" (
    "SaleReturnId" INTEGER,
    "ReturnNumber" TEXT UNIQUE,
    "ReturnDate" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "CustomerId" INTEGER NOT NULL,
    "TotalAmount" REAL NOT NULL
        CHECK ("TotalAmount" > 0),
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Notes" TEXT,
    "Cancelled" INTEGER NOT NULL DEFAULT 0
        CHECK ("Cancelled" IN (0, 1)),
    "CashTransactionId" INTEGER UNIQUE,

    PRIMARY KEY ("SaleReturnId" AUTOINCREMENT),

    FOREIGN KEY ("CashTransactionId")
        REFERENCES "CashTransactions" ("TransactionId"),

    FOREIGN KEY ("CustomerId")
        REFERENCES "Customers" ("CustomerId")
) STRICT;


CREATE TABLE IF NOT EXISTS "SaleReturnItems" (
    "ItemId" INTEGER,
    "SaleReturnId" INTEGER NOT NULL,
    "SourceInvoiceItemId" INTEGER NOT NULL,
    "Quantity" REAL NOT NULL
        CHECK ("Quantity" > 0),
    "UnitPrice" REAL NOT NULL
        CHECK ("UnitPrice" > 0),
    "StockTransactionId" INTEGER NOT NULL UNIQUE,

    PRIMARY KEY ("ItemId" AUTOINCREMENT),

    UNIQUE ("SaleReturnId", "SourceInvoiceItemId"),

    FOREIGN KEY ("SaleReturnId")
        REFERENCES "SaleReturns" ("SaleReturnId"),

    FOREIGN KEY ("SourceInvoiceItemId")
        REFERENCES "SaleInvoiceItems" ("ItemId"),

    FOREIGN KEY ("StockTransactionId")
        REFERENCES "StockTransactions" ("TransactionId")
) STRICT;


-- ============================================================
-- 8. Customer / Supplier Payments
-- ============================================================

CREATE TABLE IF NOT EXISTS "CustomerPayments" (
    "PaymentId" INTEGER,
    "ReceiptNumber" TEXT UNIQUE,
    "PaymentDate" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "PaymentMethodId" INTEGER NOT NULL,
    "Amount" REAL NOT NULL
        CHECK ("Amount" > 0),
    "CustomerId" INTEGER NOT NULL,
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Notes" TEXT,
    "Cancelled" INTEGER NOT NULL DEFAULT 0
        CHECK ("Cancelled" IN (0, 1)),
    "CashTransactionId" INTEGER NOT NULL UNIQUE,

    PRIMARY KEY ("PaymentId" AUTOINCREMENT),

    FOREIGN KEY ("CashTransactionId")
        REFERENCES "CashTransactions" ("TransactionId"),

    FOREIGN KEY ("CustomerId")
        REFERENCES "Customers" ("CustomerId"),

    FOREIGN KEY ("PaymentMethodId")
        REFERENCES "PaymentMethods" ("MethodId")
) STRICT;


CREATE TABLE IF NOT EXISTS "SupplierPayments" (
    "PaymentId" INTEGER,
    "ReceiptNumber" TEXT UNIQUE,
    "PaymentDate" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "PaymentMethodId" INTEGER NOT NULL,
    "Amount" REAL NOT NULL
        CHECK ("Amount" > 0),
    "SupplierId" INTEGER NOT NULL,
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Notes" TEXT,
    "Cancelled" INTEGER NOT NULL DEFAULT 0
        CHECK ("Cancelled" IN (0, 1)),
    "CashTransactionId" INTEGER NOT NULL UNIQUE,

    PRIMARY KEY ("PaymentId" AUTOINCREMENT),

    FOREIGN KEY ("PaymentMethodId")
        REFERENCES "PaymentMethods" ("MethodId"),

    FOREIGN KEY ("SupplierId")
        REFERENCES "Suppliers" ("SupplierId")
) STRICT;


-- ============================================================
-- 9. Opening Customer Debts
-- ============================================================

CREATE TABLE IF NOT EXISTS "OldDebts" (
    "DebtId" INTEGER,
    "CustomerId" INTEGER NOT NULL,
    "RecordDate" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Amount" REAL NOT NULL
        CHECK ("Amount" > 0),
    "CreatedAt" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Notes" TEXT,
    "Cancelled" INTEGER NOT NULL DEFAULT 0
        CHECK ("Cancelled" IN (0, 1)),

    PRIMARY KEY ("DebtId" AUTOINCREMENT),

    FOREIGN KEY ("CustomerId")
        REFERENCES "Customers" ("CustomerId")
) STRICT;