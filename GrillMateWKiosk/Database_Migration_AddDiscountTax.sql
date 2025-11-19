

USE POS;
GO


ALTER TABLE Orders
ADD Subtotal DECIMAL(10,2) NULL,
    Discount DECIMAL(10,2) DEFAULT 0,
    Tax DECIMAL(10,2) DEFAULT 0,
    TotalAmount DECIMAL(10,2) NULL,
    HasPwdDiscount BIT DEFAULT 0;
GO


UPDATE Orders
SET Subtotal = (
    SELECT ISNULL(SUM(oi.Subtotal), 0)
    FROM OrderItems oi
    WHERE oi.OrderID = Orders.OrderID
),
TotalAmount = (
    SELECT ISNULL(SUM(oi.Subtotal), 0) * 1.12
    FROM OrderItems oi
    WHERE oi.OrderID = Orders.OrderID
),
Tax = (
    SELECT ISNULL(SUM(oi.Subtotal), 0) * 0.12
    FROM OrderItems oi
    WHERE oi.OrderID = Orders.OrderID
),
Discount = 0,
HasPwdDiscount = 0
WHERE Subtotal IS NULL;
GO


GO










