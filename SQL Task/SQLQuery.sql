IF EXISTS(SELECT * FROM sys.databases WHERE name = 'MindboxProducts')
BEGIN
	USE master
	ALTER DATABASE MindboxProducts SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE MindboxProducts
END

CREATE DATABASE MindboxProducts
GO
	USE MindboxProducts
GO

CREATE TABLE Products
(
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	ProductName NVARCHAR(50) NOT NULL
)

CREATE TABLE  Categories 
(
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	CategoryName nvarchar(50) UNIQUE NOT NULL
)

CREATE TABLE  Products_Categories
(
	ProductId UNIQUEIDENTIFIER REFERENCES Products(Id) ON DELETE CASCADE,
	CategoryId UNIQUEIDENTIFIER REFERENCES Categories(Id)  ON DELETE CASCADE NULL
)

INSERT INTO Products (Id, ProductName) 
VALUES 
	(NEWID(),'Product1'),
	(NEWID(),'Product2'),
	(NEWID(),'Product3'),
	(NEWID(),'Product4'),
	(NEWID(),'Product5')

INSERT INTO Categories (Id, CategoryName) 
VALUES 
	(NEWID(),'Category1'),
	(NEWID(),'Category2'),
	(NEWID(),'Category3')

INSERT INTO Products_Categories (ProductId, CategoryId) 
VALUES 
	(
		(SELECT Id FROM Products WHERE ProductName = 'Product1'),
		(SELECT Id FROM Categories WHERE CategoryName = 'Category1')
	),
	(
		(SELECT Id FROM Products WHERE ProductName = 'Product1'),
		(SELECT Id FROM Categories WHERE CategoryName = 'Category2')
	),
	(
		(SELECT Id FROM Products WHERE ProductName = 'Product2'),
		(SELECT Id FROM Categories WHERE CategoryName = 'Category1')
	),
	(
		(SELECT Id FROM Products WHERE ProductName = 'Product3'),
		(SELECT Id FROM Categories WHERE CategoryName = 'Category1')
	),
	(
		(SELECT Id FROM Products WHERE ProductName = 'Product3'),
		(SELECT Id FROM Categories WHERE CategoryName = 'Category2')
	),
	(
		(SELECT Id FROM Products WHERE ProductName = 'Product3'),
		(SELECT Id FROM Categories WHERE CategoryName = 'Category3')
	)

--Не очень понял, что именно нужно вывести, поэтому либо так:
SELECT ProductName, CategoryName FROM Products 
	LEFT JOIN Products_Categories ON Products_Categories.ProductId = Products.Id
	LEFT JOIN Categories ON Categories.Id=Products_Categories.CategoryId
ORDER BY ProductName

--Либо так:
SELECT ProductName, CategoryName FROM Products, Categories ORDER BY ProductName