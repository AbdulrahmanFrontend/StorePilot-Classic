-- Tables

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
	"Name"	TEXT NOT NULL UNIQUE,
	"Phone"	TEXT NOT NULL UNIQUE,
	"Address"	TEXT,
	"CreatedAt"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY("PersonID" AUTOINCREMENT)
) STRICT;

CREATE TABLE "CashTransactions" (
	"TransactionID"	INTEGER NOT NULL,
	"TransactionDate"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"TransactionType"	TEXT NOT NULL DEFAULT 'مصروفات' CHECK("TransactionType" IN ('ايرادات', 'مصروفات')),
	"PaidAmount"	REAL NOT NULL CHECK("Amount" > 0),
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
	"TotalAmount"	REAL NOT NULL CHECK("TotalAmount" > 0),
	"CreatedAt"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"TransactionID"	INTEGER,
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
	"SupplierID"	INTEGER,
	"Cancelled"	INT NOT NULL DEFAULT 0 CHECK("Cancelled" IN (1, 0)),
	"Notes"	TEXT,
	PRIMARY KEY("PurchaseInvoiceID" AUTOINCREMENT),
	FOREIGN KEY("InvoiceID") REFERENCES "Invoices"("InvoiceID"),
	FOREIGN KEY("SupplierID") REFERENCES "Suppliers"("SupplierID")
) STRICT;

CREATE TABLE "SalesInvoices" (
	"SaleInvoiceID"	INTEGER NOT NULL,
	"InvoiceID"	INTEGER NOT NULL UNIQUE,
	"CustomerID"	INTEGER,
	"Cancelled"	INT NOT NULL DEFAULT 0 CHECK("Cancelled" IN (1, 0)),
	"Notes"	TEXT,
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


-- Views

CREATE VIEW view_SuppliersDetails AS
SELECT Suppliers.SupplierID, People.PersonID, People.Name,
People.Phone, People.Address, People.CreatedAt, 
Suppliers.Notes, Suppliers.Active
FROM Suppliers
JOIN People 
ON Suppliers.PersonID = People.PersonID
ORDER BY Suppliers.Active DESC, Suppliers.SupplierID DESC;

CREATE VIEW view_CustomersDetails AS
SELECT Customers.CustomerID, People.PersonID, People.Name,
People.Phone, People.Address, People.CreatedAt, 
Customers.Notes, Customers.Active
FROM Customers
JOIN People ON Customers.PersonID = People.PersonID
ORDER BY Customers.Active DESC, Customers.CustomerID DESC;

CREATE VIEW view_ProductsDetails AS
SELECT Products.ProductID, Products.ProductName, 
Products.BarCode, Products.GroupID, Groups.GroupName,
Products.UnitID, Units.UnitName, Products.MinQuantity,
Products.Quantity, Products.SalePrice, Products.PurchasePrice,
Products.CreatedAt, Products.Active, Products.Notes
FROM Products
JOIN Groups
ON Products.GroupID = Groups.GroupID
JOIN Units
ON Products.UnitID = Units.UnitID
ORDER BY Products.Active DESC, Products.ProductID DESC;

CREATE VIEW view_InvoicesItemsDetails AS
SELECT InvoicesItems.ItemID, InvoicesItems.InvoiceID, InvoicesItems.ProductID, view_ProductsDetails.ProductName,
view_ProductsDetails.BarCode, view_ProductsDetails.GroupName, view_ProductsDetails.UnitName, InvoicesItems.Quantity,
InvoicesItems.UnitPrice
FROM InvoicesItems
JOIN view_ProductsDetails
ON InvoicesItems.ProductID = view_ProductsDetails.ProductID;

CREATE VIEW view_PurchasesInvoicesDetails AS
SELECT PurchasesInvoices.PurchaseInvoiceID, PurchasesInvoices.InvoiceID, Invoices.InvoiceDate, Invoices.InvoiceStatus, 
PurchasesInvoices.SupplierID, view_SuppliersDetails.Name AS SupplierName, Invoices.PaidAmount, Invoices.TotalAmount, Invoices.CreatedAt,
PurchasesInvoices.Cancelled, PurchasesInvoices.Notes, Invoices.TransactionID
FROM PurchasesInvoices
JOIN Invoices
ON PurchasesInvoices.InvoiceID = Invoices.InvoiceID
LEFT JOIN view_SuppliersDetails
ON PurchasesInvoices.SupplierID = view_SuppliersDetails.SupplierID
ORDER BY PurchasesInvoices.Cancelled ASC, PurchasesInvoices.PurchaseInvoiceID DESC;

CREATE VIEW view_SalesInvoicesDetails AS
SELECT SalesInvoices.SaleInvoiceID, SalesInvoices.InvoiceID, Invoices.InvoiceDate, Invoices.InvoiceStatus, 
SalesInvoices.CustomerID, view_CustomersDetails.Name AS CustomerName, Invoices.PaidAmount, Invoices.TotalAmount, Invoices.CreatedAt,
SalesInvoices.Cancelled, SalesInvoices.Notes, Invoices.TransactionID
FROM SalesInvoices
JOIN Invoices
ON SalesInvoices.InvoiceID = Invoices.InvoiceID
LEFT JOIN view_CustomersDetails
ON SalesInvoices.CustomerID = view_CustomersDetails.CustomerID
ORDER BY SalesInvoices.Cancelled ASC, SalesInvoices.PurchaseInvoiceID DESC;

CREATE VIEW view_PaymentsDetails AS
SELECT Payments.PaymentID, Payments.InvoiceID, Payments.PaymentDate, Payments.PaidAmount, Payments.MethodID, PaymentMethods.MethodName,
Payments.Cancelled, Payments.Notes, Payments.TransactionID
FROM Payments
JOIN PaymentMethods
ON Payments.MethodID = PaymentMethods.MethodID
ORDER BY Payments.Cancelled ASC, Payments.PaymentID DESC;

CREATE VIEW view_SalesReturnItemsDetails AS
SELECT SalesReturnItems.ReturnItemID, SalesReturnItems.ReturnID, SalesReturnItems.ProductID, view_ProductsDetails.ProductName,
view_ProductsDetails.BarCode, view_ProductsDetails.GroupName, view_ProductsDetails.UnitName, SalesReturnItems.Quantity,
SalesReturnItems.UnitPrice
FROM SalesReturnItems
JOIN view_ProductsDetails
ON SalesReturnItems.ProductID = view_ProductsDetails.ProductID;