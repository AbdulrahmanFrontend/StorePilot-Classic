CREATE TABLE "Units" (
	"UnitID"	INTEGER NOT NULL,
	"UnitName"	TEXT NOT NULL UNIQUE,
	PRIMARY KEY("UnitID" AUTOINCREMENT)
) STRICT;

CREATE TABLE "Groups" (
	"GroupID"	INTEGER NOT NULL,
	"GroupName"	TEXT NOT NULL UNIQUE,
	PRIMARY KEY("GroupID" AUTOINCREMENT)
) STRICT;

CREATE TABLE "PaymentMethods" (
	"MethodID"	INTEGER NOT NULL,
	"MethodName"	TEXT NOT NULL UNIQUE,
	PRIMARY KEY("MethodID" AUTOINCREMENT)
) STRICT;

CREATE TABLE "People" (
	"PersonID"	INTEGER NOT NULL,
	"PersonName"	TEXT NOT NULL UNIQUE,
	"Phone"	TEXT NOT NULL UNIQUE,
	"Address"	TEXT,
	"CreatedAt"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY("PersonID" AUTOINCREMENT)
) STRICT;

CREATE TABLE "CashTransactions" (
	"TransactionID"	INTEGER NOT NULL,
	"TransactionDate"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"TransactionType"	TEXT NOT NULL DEFAULT 'مصروفات' CHECK("TransactionType" IN ('ايرادات', 'مصروفات')),
	"Amount"	REAL NOT NULL CHECK("Amount" > 0),
	"Description"	TEXT NOT NULL,
	"CreatedAt"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"Cancelled"	INT NOT NULL DEFAULT 0 CHECK("Cancelled" IN (1, 0)),
	"Notes"	TEXT,
	PRIMARY KEY("TransactionID" AUTOINCREMENT)
) STRICT;

CREATE TABLE "Products" (
	"ProductID"	INTEGER NOT NULL,
	"ProductName"	TEXT NOT NULL UNIQUE,
	"BarCode"	TEXT UNIQUE,
	"UnitID"	INTEGER NOT NULL,
	"Quantity"	REAL NOT NULL DEFAULT 0 CHECK("Quantity" >= 0),
	"MinQuantity"	REAL NOT NULL DEFAULT 0 CHECK("MinQuantity" >= 0),
	"SalePrice"	REAL CHECK("SalePrice" > 0),
	"PurchasePrice"	REAL NOT NULL CHECK("PurchasePrice" > 0),
	"GroupID"	INTEGER NOT NULL,
	"CreatedAt"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"Active"	INT NOT NULL DEFAULT 1 CHECK("Active" IN (1, 0)),
	"Notes"	TEXT,
	PRIMARY KEY("ProductID" AUTOINCREMENT),
	FOREIGN KEY("GroupID") REFERENCES "Groups"("GroupID"),
	FOREIGN KEY("UnitID") REFERENCES "Units"("UnitID")
) STRICT;

CREATE TABLE "Invoices" (
	"InvoiceID"	INTEGER NOT NULL,
	"InvoiceDate"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"InvoiceStatus"	TEXT NOT NULL CHECK("InvoiceStatus" IN ('مدفوع', 'آجل')),
	"PaidAmount"	REAL NOT NULL DEFAULT 0 CHECK("PaidAmount" >= 0),
	"RemainingAmount"	REAL NOT NULL DEFAULT 0 CHECK("RemainingAmount" >= 0),
	"TotalAmount"	REAL NOT NULL CHECK("TotalAmount" > 0),
	"CreatedAt"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"Cancelled"	INT NOT NULL DEFAULT 0 CHECK("Cancelled" IN (1, 0)),
	"TransactionID"	INTEGER,
	"Notes"	TEXT,
	PRIMARY KEY("InvoiceID" AUTOINCREMENT),
	FOREIGN KEY("TransactionID") REFERENCES "CashTransactions"("TransactionID")
) STRICT;

CREATE TABLE "InvoicesItems" (
	"ItemID"	INTEGER NOT NULL,
	"InvoiceID"	INTEGER NOT NULL,
	"ProductID"	INTEGER NOT NULL,
	"Quantity"	REAL NOT NULL CHECK("Quantity" > 0),
	"UnitPrice"	REAL NOT NULL CHECK("UnitPrice" > 0),
	PRIMARY KEY("ItemID" AUTOINCREMENT),
	FOREIGN KEY("InvoiceID") REFERENCES "Invoices"("InvoiceID"),
	FOREIGN KEY("ProductID") REFERENCES "Products"("ProductID")
) STRICT;

CREATE TABLE "Payments" (
	"PaymentID"	INTEGER NOT NULL,
	"InvoiceID"	INTEGER NOT NULL,
	"PaymentDate"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"PaidAmount"	REAL NOT NULL CHECK("PaidAmount" > 0),
	"MethodID"	INTEGER NOT NULL,
	"TransactionID"	INTEGER,
	"Notes"	TEXT,
	"Cancelled"	INTEGER NOT NULL DEFAULT 0 CHECK("Cancelled" IN (1, 0)),
	PRIMARY KEY("PaymentID" AUTOINCREMENT),
	FOREIGN KEY("InvoiceID") REFERENCES "Invoices"("InvoiceID"),
	FOREIGN KEY("MethodID") REFERENCES "PaymentMethods"("MethodID"),
	FOREIGN KEY("TransactionID") REFERENCES "CashTransactions"("TransactionID")
) STRICT;

CREATE TABLE "Suppliers" (
	"SupplierID"	INTEGER NOT NULL,
	"PersonID"	INTEGER NOT NULL UNIQUE,
	"Active"	INT NOT NULL DEFAULT 1 CHECK("Active" IN (1, 0)),
	"Notes"	TEXT,
	PRIMARY KEY("SupplierID" AUTOINCREMENT),
	FOREIGN KEY("PersonID") REFERENCES "People"("PersonID")
) STRICT;

CREATE TABLE "Customers" (
	"CustomerID"	INTEGER NOT NULL,
	"PersonID"	INTEGER NOT NULL UNIQUE,
	"Active"	INT NOT NULL DEFAULT 1 CHECK("Active" IN (1, 0)),
	"Notes"	TEXT,
	PRIMARY KEY("CustomerID" AUTOINCREMENT),
	FOREIGN KEY("PersonID") REFERENCES "People"("PersonID")
) STRICT;

CREATE TABLE "PurchasesInvoices" (
	"PurchaseInvoiceID"	INTEGER NOT NULL,
	"InvoiceID"	INTEGER NOT NULL UNIQUE,
	"SupplierID"	INTEGER NOT NULL,
	PRIMARY KEY("PurchaseInvoiceID" AUTOINCREMENT),
	FOREIGN KEY("InvoiceID") REFERENCES "Invoices"("InvoiceID"),
	FOREIGN KEY("SupplierID") REFERENCES "Suppliers"("SupplierID")
) STRICT;

CREATE TABLE "SalesInvoices" (
	"SaleInvoiceID"	INTEGER NOT NULL,
	"InvoiceID"	INTEGER NOT NULL UNIQUE,
	"CustomerID"	INTEGER NOT NULL,
	PRIMARY KEY("SaleInvoiceID" AUTOINCREMENT),
	FOREIGN KEY("CustomerID") REFERENCES "Customers"("CustomerID"),
	FOREIGN KEY("InvoiceID") REFERENCES "Invoices"("InvoiceID")
) STRICT;

CREATE TABLE "SalesReturns" (
	"ReturnID"	INTEGER NOT NULL,
	"SalesInvoiceID"	INTEGER NOT NULL,
	"ReturnDate"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"TotalReturnAmount"	REAL NOT NULL CHECK("TotalReturnAmount" > 0),
	"Cancelled"	INT NOT NULL DEFAULT 0 CHECK("Cancelled" IN (1, 0)),
	"TransactionID"	INTEGER,
	"Notes"	TEXT,
	PRIMARY KEY("ReturnID" AUTOINCREMENT),
	FOREIGN KEY("SalesInvoiceID") REFERENCES "SalesInvoices"("SaleInvoiceID"),
	FOREIGN KEY("TransactionID") REFERENCES "CashTransactions"("TransactionID")
) STRICT;

CREATE TABLE "SalesReturnItems" (
	"ReturnItemID"	INTEGER NOT NULL,
	"ReturnID"	INTEGER NOT NULL,
	"ProductID"	INTEGER NOT NULL,
	"Quantity"	REAL NOT NULL CHECK("Quantity" > 0),
	"UnitPrice"	REAL NOT NULL CHECK("UnitPrice" > 0),
	PRIMARY KEY("ReturnItemID" AUTOINCREMENT),
	FOREIGN KEY("ProductID") REFERENCES "Products"("ProductID"),
	FOREIGN KEY("ReturnID") REFERENCES "SalesReturns"("ReturnID")
) STRICT;