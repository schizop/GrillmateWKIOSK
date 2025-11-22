-- GRILLMATE POS MANAGEMENT SYSTEM - DATABASE SCHEMA
-- SQL Server Database Schema for POS Kiosk System

SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;

CREATE DATABASE POS;
GO

USE POS;
GO

CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Users NVARCHAR(20) NOT NULL UNIQUE,
    Password NVARCHAR(20) NOT NULL,
    Roles NVARCHAR(20) NOT NULL
);

CREATE TABLE Tables (
    TableID INT IDENTITY(1,1) PRIMARY KEY,
    TableNumber NVARCHAR(50) NOT NULL,
    Status NVARCHAR(20) DEFAULT 'Vacant'
);



CREATE TABLE MenuCategories (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(50) NOT NULL,
    Description NVARCHAR(255) NULL
);

CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryID INT FOREIGN KEY REFERENCES MenuCategories(CategoryID),
    ProductName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255) NULL,
    Price DECIMAL(10,2) NOT NULL,
    IsAvailable BIT DEFAULT 1
);

CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    TableID INT NULL FOREIGN KEY REFERENCES Tables(TableID),
    UserID INT NULL FOREIGN KEY REFERENCES Users(UserID),
    OrderNumber NVARCHAR(20) NOT NULL UNIQUE,
    OrderType NVARCHAR(20) DEFAULT 'Dine-In',
    OrderStatus NVARCHAR(20) DEFAULT 'Pending',
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE OrderItems (
    OrderItemID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID) ON DELETE CASCADE,
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
    Quantity INT NOT NULL CHECK (Quantity > 0),
    Price DECIMAL(10,2) NOT NULL,
    Subtotal AS (Quantity * Price) PERSISTED
);

CREATE TABLE Payments (
    PaymentID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
    PaymentMethod NVARCHAR(20) NOT NULL,
    AmountPaid DECIMAL(10,2) NOT NULL,
    PaymentDate DATETIME DEFAULT GETDATE(),
    ReferenceNo NVARCHAR(50) NULL
);

CREATE TABLE Reservations (
    ReservationID INT IDENTITY(1,1) PRIMARY KEY,
    TableID INT FOREIGN KEY REFERENCES Tables(TableID), -- Retained Foreign Key
    CustomerName NVARCHAR(100),
    PhoneNumber NVARCHAR(20),
    DateReserved DATE,
    TimeSlot NVARCHAR(20),
    Guests INT,
    SpecialRequest NVARCHAR(200)
);

CREATE TABLE Deliveries (
    DeliveryID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
    CustomerName NVARCHAR(100) NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    ContactNumber NVARCHAR(20) NOT NULL,
    DeliveryStatus NVARCHAR(20) DEFAULT 'Pending',
    AssignedTo NVARCHAR(50) NULL,
    DeliveryDate DATETIME NULL
);
INSERT INTO Tables (TableNumber, Status) VALUES
('Table 1', 'Vacant'),
('Table 2', 'Vacant'),
('Table 3', 'Vacant'),
('Table 4', 'Vacant'),
('Table 5', 'Vacant'),
('Table 6', 'Vacant'),
('Table 7', 'Vacant'),
('Table 8', 'Vacant');

INSERT INTO Users (Name, Users, Password, Roles)
VALUES 
('Staff Member', 'staff', 'staff123', 'staff');

INSERT INTO MenuCategories (CategoryName, Description)
VALUES 
('Silogmeals', 'Rice meals served with fried egg and garlic rice'),
('Floats', 'Refreshing soft drink or coffee topped with ice cream'),
('Special Sundae', 'Premium sundaes with toppings and sauces'),
('Icecream Cones', 'Classic soft-serve cones'),
('Fruit Floats', 'Fruity ice blended drinks with creamy twist');

-- CategoryID = 1 (Silogmeals)
INSERT INTO Products (CategoryID, ProductName, Description, Price) VALUES
(1, 'Tapsilog', 'Beef tapa with garlic rice and fried egg', 95.00),
(1, 'Chicksilog', 'Fried chicken with garlic rice and egg', 100.00),
(1, 'Bacsilog', 'Crispy bacon with garlic rice and egg', 65.00),
(1, 'Hamsilog', 'Sweet ham with garlic rice and egg', 65.00),
(1, 'Tosilog', 'Pork tocino with garlic rice and egg', 65.00);

-- CategoryID = 2 (Floats)
INSERT INTO Products (CategoryID, ProductName, Description, Price) VALUES
(2, 'Chocofloat', 'Chocolate drink topped with vanilla ice cream', 50.00),
(2, 'Coffee Float', 'Iced coffee topped with ice cream', 50.00),
(2, 'Coke Float', 'Coca-Cola drink topped with ice cream', 50.00);

-- CategoryID = 3 (Special Sundae)
INSERT INTO Products (CategoryID, ProductName, Description, Price) VALUES
(3, 'Mango Craze', 'Sundae with mango syrup and toppings', 50.00),
(3, 'Strawberry', 'Sundae with strawberry sauce and bits', 50.00),
(3, 'Blueberry', 'Sundae with blueberry syrup and bits', 50.00),
(3, 'Chocolava Sundae', 'Rich chocolate sundae with lava fudge', 50.00),
(3, 'Cookie Caramel Sundae', 'Caramel sundae with cookie crumble', 50.00),
(3, 'Cookies and Cream Sundae', 'Creamy sundae with crushed cookies', 50.00);

-- CategoryID = 4 (Icecream Cones)
INSERT INTO Products (CategoryID, ProductName, Description, Price) VALUES
(4, 'Giant Cone', 'Large soft-serve ice cream cone', 25.00),
(4, 'Giant Cone with Sprinkles', 'Soft-serve cone with colorful sprinkles', 30.00);

-- CategoryID = 5 (Fruit Floats)
INSERT INTO Products (CategoryID, ProductName, Description, Price) VALUES
(5, 'Blueberry', 'Blueberry fruit blend float topped with ice cream', 60.00),
(5, 'Strawberry', 'Strawberry float with creamy ice cream top', 60.00),
(5, 'Green Apple', 'Green apple fruit float with vanilla ice cream', 60.00),
(5, 'Four Seasons', 'Mixed tropical fruit float with ice cream', 60.00),
(5, 'Lychee', 'Lychee float with creamy finish', 60.00);


