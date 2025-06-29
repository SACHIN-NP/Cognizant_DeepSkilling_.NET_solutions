use handson;
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);

INSERT INTO Products VALUES
(1, 'Laptop', 'Electronics', 1200.00),
(2, 'Smartphone', 'Electronics', 800.00),
(3, 'Tablet', 'Electronics', 600.00),
(4, 'Headphones', 'Accessories', 150.00),
(5, 'Keyboard', 'Accessories', 100.00),
(6, 'Monitor', 'Electronics', 1200.00);  

SELECT * From Products;
--1. ROW_NUMBER(): Assigns unique ranks per category, ignoring ties.
SELECT 
    ProductID, ProductName, Category, Price,
    ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNumRank
FROM Products;


--2.  Use RANK() and DENSE_RANK() to compare how ties are handled
SELECT 
    ProductName, Category, Price,
    RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS Rank,
    DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRank
FROM Products;

--3. Use PARTITION BY Category and ORDER BY Price DESC

SELECT
    ProductID,
    ProductName,
    Category,
    Price,
    RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS PriceRank,
    DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS PriceDenseRank
FROM Products;
