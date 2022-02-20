-- Задание 1 - простая проекция данных

SELECT [ProductID], [Name], [ProductNumber], [Color] FROM SalesLT.Product

SELECT [CustomerID], [FirstName], [MiddleName], [LastName], [EmailAddress], [Phone] FROM SalesLT.Customer

-- Задание 2 - фильтрация данных (выводить идентификатор, название и номер продукта + атрибут который упоминается)

SELECT [ProductID], [Name], [ProductNumber], [Color] 
FROM SalesLT.Product
WHERE [Color] = 'Black'

SELECT [ProductID], [Name], [ProductNumber], [Color] 
FROM SalesLT.Product
WHERE [Color] = 'Black' AND [Color] = 'Silver' OR [Color] = 'Multi'

SELECT [ProductID], [Name], [ProductNumber], [Color] 
FROM SalesLT.Product
WHERE [Color] = 'Black' OR [Color] = 'Yellow'

SELECT [ProductID], [Name], [ProductNumber], [Weight] 
FROM SalesLT.Product
WHERE [Weight] IS NULL

SELECT [ProductID], [Name], [ProductNumber], [Weight] 
FROM SalesLT.Product
WHERE [Weight] > 1000

SELECT [ProductID], [Name], [ProductNumber], [Weight] 
FROM SalesLT.Product
WHERE [Weight] < 6000

SELECT [ProductID], [Name], [ProductNumber], [Weight] 
FROM SalesLT.Product
WHERE [Weight] BETWEEN 2000 AND 5000

SELECT [ProductID], [Name], [ProductNumber] 
FROM SalesLT.Product
WHERE [ProductNumber] LIKE 'BK%' OR [ProductNumber] LIKE 'BB%'

SELECT [ProductID], [Name], [ProductNumber], [SellEndDate]
FROM SalesLT.Product
WHERE [SellEndDate] IS NULL

-- Задание 3 - сортировка

SELECT * FROM SalesLT.Product ORDER BY [Color]

SELECT * FROM SalesLT.Product 
ORDER BY [Color] ASC, [Weight] DESC

SELECT * FROM SalesLT.Product 
ORDER BY [ProductNumber] ASC, [Weight] DESC

-- Задание 4 - пагинация (paging, разбивка по страницам)

SELECT TOP 10 * FROM SalesLT.Product

SELECT * FROM SalesLT.Product
ORDER BY [Weight]
	OFFSET 0 ROWS
	FETCH NEXT 10 ROWS ONLY;

SELECT * FROM SalesLT.Product
ORDER BY [ProductID] DESC
	OFFSET 0 ROWS
	FETCH NEXT 10 ROWS ONLY;

SELECT * FROM SalesLT.Product
ORDER BY [Weight]
	OFFSET 10 ROWS
	FETCH NEXT 10 ROWS ONLY;

-- Задание 5 - соединения (joins)

SELECT 
	Product.[ProductID], 
	[Name], 
	[ProductNumber], 
	[Color],
	[Weight],
	[LineTotal],
	FORMAT([UnitPriceDiscount], 'P0') as [Discount]
FROM SalesLT.Product
	INNER JOIN SalesLT.SalesOrderDetail ON Product.ProductID = SalesOrderDetail.ProductID

SELECT 
	CustomerAddress.[CustomerID], 
	[FirstName], 
	[MiddleName], 
	[LastName], 
	[EmailAddress], 
	[Phone], 
	[City], 
	[CountryRegion], 
	[PostalCode], 
	[AddressLine1]
FROM SalesLT.CustomerAddress
	INNER JOIN SalesLT.Customer ON CustomerAddress.CustomerID = Customer.CustomerID
	INNER JOIN SalesLT.[Address] ON CustomerAddress.AddressID = [Address].AddressID

SELECT 
	[ProductID], 
	Product.[Name], 
	[ProductNumber], 
	ParentCategory.[Name] as [ParentCategory],
	Category.[Name] as [Category]
FROM SalesLT.Product
	INNER JOIN SalesLT.ProductCategory Category ON Product.ProductCategoryID = Category.ProductCategoryID
	INNER JOIN SalesLT.ProductCategory ParentCategory ON Category.ParentProductCategoryID = ParentCategory.ProductCategoryID

-- Задание 6 - группировка

SELECT COUNT(*) FROM SalesLT.Product

SELECT COUNT(*) FROM SalesLT.Product WHERE [SellEndDate] IS NOT NULL

SELECT COUNT(*) FROM SalesLT.Product WHERE [Weight] IS NULL

SELECT AVG([Weight]) FROM SalesLT.Product WHERE [Weight] IS NOT NULL

SELECT AVG([Weight]) FROM SalesLT.Product

SELECT MIN([Weight]) FROM SalesLT.Product

SELECT MAX([Weight]) FROM SalesLT.Product

SELECT 
	Product.[ProductCategoryID], 
	ProductCategory.[Name],
	COUNT(*) as [Count],
	SUM([Weight]) as [Total Weight],
	MAX([Weight]) as [Max Weight],
	MIN([Weight]) as [Min Weight],
	AVG([Weight]) as [Avg Weight]
FROM SalesLT.Product
	INNER JOIN SalesLT.ProductCategory ON Product.ProductCategoryID = ProductCategory.ProductCategoryID
GROUP BY Product.[ProductCategoryID], ProductCategory.[Name]

SELECT 
	Product.[ProductCategoryID], 
	ProductCategory.[Name],
	COUNT(*) as [Count],
	SUM([Weight]) as [Total Weight]
FROM SalesLT.Product
	INNER JOIN SalesLT.ProductCategory ON Product.ProductCategoryID = ProductCategory.ProductCategoryID
GROUP BY Product.[ProductCategoryID], ProductCategory.[Name]

SELECT 
	Product.[ProductCategoryID], 
	ProductCategory.[Name],
	COUNT(*) as [Count],
	SUM([Weight]) as [Total Weight]
FROM SalesLT.Product
	INNER JOIN SalesLT.ProductCategory ON Product.ProductCategoryID = ProductCategory.ProductCategoryID
GROUP BY Product.[ProductCategoryID], ProductCategory.[Name]
HAVING 
	SUM([Weight]) IS NOT NULL
	AND MAX([Weight]) IS NOT NULL
	AND MIN([Weight]) IS NOT NULL
	AND AVG([Weight]) IS NOT NULL

SELECT 
	Product.[ProductCategoryID], 
	ProductCategory.[Name],
	COUNT(*) as [Count],
	SUM([Weight]) as [Total Weight]
FROM SalesLT.Product
	INNER JOIN SalesLT.ProductCategory ON Product.ProductCategoryID = ProductCategory.ProductCategoryID
GROUP BY Product.[ProductCategoryID], ProductCategory.[Name]
HAVING 
	SUM([Weight]) IS NOT NULL
	AND MAX([Weight]) > 10000
	AND MIN([Weight]) IS NOT NULL
	AND AVG([Weight]) IS NOT NULL
	
-- Задание 7 - комплексное (тут уже надо самим подумать что, и как применить)

SELECT 
	Product.[ProductCategoryID], 
	ProductCategory.[Name],
	SUM([LineTotal]) as [Sales Sum]
FROM SalesLT.Product
	INNER JOIN SalesLT.ProductCategory ON Product.ProductCategoryID = ProductCategory.ProductCategoryID
	INNER JOIN SalesLT.SalesOrderDetail ON Product.ProductID = SalesOrderDetail.ProductID
GROUP BY Product.[ProductCategoryID], ProductCategory.[Name]
HAVING EXISTS (SELECT [ProductID] FROM SalesLT.SalesOrderDetail)

SELECT 
	SalesLT.Customer.*,
	FORMAT([UnitPriceDiscount], 'P0') as [Max discount]
FROM SalesLT.Customer
	LEFT JOIN SalesLT.SalesOrderHeader ON Customer.CustomerID = SalesOrderHeader.CustomerID
	LEFT JOIN SalesLT.SalesOrderDetail ON SalesOrderHeader.SalesOrderID = SalesOrderDetail.SalesOrderID
WHERE [UnitPriceDiscount] >= 0.4

SELECT 
	Customer.[CustomerID], 
	[FirstName], 
	[MiddleName], 
	[LastName],
	SUM([LineTotal]) as [Purchases sum]
FROM SalesLT.Customer
	INNER JOIN SalesLT.SalesOrderHeader ON Customer.CustomerID = SalesOrderHeader.CustomerID
	INNER JOIN SalesLT.SalesOrderDetail ON SalesOrderHeader.SalesOrderID = SalesOrderDetail.SalesOrderID
GROUP BY Customer.[CustomerID], [FirstName], [MiddleName], [LastName]
HAVING SUM([LineTotal]) > 15000