SELECT p.ProductName, c.CategoryName 
FROM Products p 
LEFT JOIN Categories c ON p.CategoryID = c.CategoryID;
