CREATE DATABASE BraceletShop;
USE BraceletShop;

SELECT * FROM Users;
SELECT * FROM Customers;
SELECT * FROM Products;
SELECT * FROM Storage;
SELECT * FROM Orders;
SELECT * FROM OrderDetails;


CREATE TABLE Users (
    UserID VARCHAR(10) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Role NVARCHAR(20) NOT NULL
);

CREATE TABLE Customers (
    CustomerID VARCHAR(10) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100),
    Phone NVARCHAR(15),
    Address NVARCHAR(200)
);

CREATE TABLE Products (
    ProductID VARCHAR(10) PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    ImageURL NVARCHAR(255),
    CategoryName NVARCHAR(100)
);

CREATE TABLE Storage (
    ProductID VARCHAR(10) PRIMARY KEY,
    Quantity INT NOT NULL,

    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

CREATE TABLE Orders (
    OrderID VARCHAR(10) PRIMARY KEY,
    CustomerID VARCHAR(10),
    UserID VARCHAR(10),
    OrderDate DATETIME,
    TotalAmount DECIMAL(10, 2),

    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE OrderDetails (
    OrderDetailID VARCHAR(10) PRIMARY KEY,
    OrderID VARCHAR(10),
    ProductID VARCHAR(10),
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10, 2) NOT NULL,
    Total AS (Quantity * UnitPrice) PERSISTED,

    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

INSERT INTO Users (UserID, Username, Password, FirstName, LastName, Role) VALUES
('U001', 'admin', 'admin123', 'Admin', 'Admin', 'Admin'),
('U002', 'staff1', 'staff123', 'Loan', 'Tran', 'Staff'),
('U003', 'staff2', 'staff123', 'Ngan', 'Nguyen', 'Staff');

INSERT INTO Customers (CustomerID,[Name],[Email],[Phone],[Address]) VALUES
('KH001', N'Ngân', 'ngannguyen2005@gmail.com', '09038456987', N'123 Tạ Uyên'),
('KH002', N'Loan', 'loan306@gmail.com', '0921856124', N'456 Hùng Vương'),
('KH003', N'Bảo', 'baovo117@gmail.com', '0907485321', N'789 Hồng Bàng'),
('KH004', N'Huyền', 'huyennt@gmail.com', '0909123456', N'12 Nguyễn Thị Minh Khai'),
('KH005', N'Nam', 'namtran@gmail.com', '0912233445', N'45 Phan Văn Trị'),
('KH006', N'Thảo', 'thaole@gmail.com', '0933445566', N'78 Hai Bà Trưng'),
('KH007', N'Quân', 'quannguyen@gmail.com', '0944556677', N'23 Lê Lai'),
('KH008', N'Mai', 'mainguyen@gmail.com', '0955667788', N'90 Nguyễn Trãi');

INSERT INTO Products (ProductID, ProductName, Price, ImageURL, CategoryName) VALUES
('SP001', N'Vòng chuỗi đá phong thủy', 150000, 'images/p001.jpg', N'vòng chuỗi'),
('SP002', N'Vòng chỉ đỏ may mắn', 50000, 'images/p002.jpg', N'vòng chỉ'),
('SP003', N'Vòng chuỗi trầm hương', 250000, 'images/p003.jpg', N'vòng chuỗi'),
('SP004', N'Vòng chỉ handmade', 80000, 'images/p004.jpg', N'vòng chỉ'),
('SP005', N'Vòng chuỗi gỗ sưa', 300000, 'images/p005.jpg', N'vòng chuỗi'),
('SP006', N'Vòng chuỗi ngọc bích', 180000, 'images/sp006.jpg', N'vòng chuỗi'),
('SP007', N'Vòng chỉ vàng may mắn', 60000, 'images/sp007.jpg', N'vòng chỉ'),
('SP008', N'Vòng chuỗi mắt hổ', 220000, 'images/sp008.jpg', N'vòng chuỗi'),
('SP009', N'Vòng chỉ handmade đôi', 95000, 'images/sp009.jpg', N'vòng chỉ'),
('SP010', N'Vòng chuỗi gỗ mun', 275000, 'images/sp010.jpg', N'vòng chuỗi');

INSERT INTO Storage (ProductID, Quantity) VALUES
('SP001', 10),
('SP002', 25),
('SP003', 5),
('SP004', 30),
('SP005', 7),
('SP006', 12),
('SP007', 20),
('SP008', 15),
('SP009', 10),
('SP010', 8);

INSERT INTO Orders (OrderID, CustomerID, UserID, OrderDate, TotalAmount) VALUES
('HD001', 'KH001', 'U002', '2024-08-01', 300000),
('HD002', 'KH002', 'U003', '2024-08-02', 500000),
('HD003', 'KH003', 'U001', '2024-08-03', 230000),
('HD004', 'KH004', 'U001', '2024-08-04', 360000),
('HD005', 'KH005', 'U002', '2024-08-05', 600000),
('HD006', 'KH006', 'U003', '2025-08-05', 180000),
('HD007', 'KH007', 'U001', '2025-08-06', 275000),
('HD008', 'KH008', 'U002', '2025-08-06', 155000),
('HD009', 'KH004', 'U003', '2025-08-07', 440000),
('HD010', 'KH006', 'U002', '2025-08-07', 315000);

UPDATE Orders SET OrderDate = '2024-01-15' WHERE OrderID = 'HD001';
UPDATE Orders SET OrderDate = '2024-02-20' WHERE OrderID = 'HD002';
UPDATE Orders SET OrderDate = '2024-03-10' WHERE OrderID = 'HD003';
UPDATE Orders SET OrderDate = '2024-04-12' WHERE OrderID = 'HD004';
UPDATE Orders SET OrderDate = '2024-05-25' WHERE OrderID = 'HD005';
UPDATE Orders SET OrderDate = '2024-06-30' WHERE OrderID = 'HD006';
UPDATE Orders SET OrderDate = '2025-07-08' WHERE OrderID = 'HD007';
UPDATE Orders SET OrderDate = '2025-08-17' WHERE OrderID = 'HD008';
UPDATE Orders SET OrderDate = '2025-09-22' WHERE OrderID = 'HD009';
UPDATE Orders SET OrderDate = '2025-10-03' WHERE OrderID = 'HD010';

INSERT INTO OrderDetails (OrderDetailID, OrderID, ProductID, Quantity, UnitPrice) VALUES
('OD001', 'HD001', 'SP001', 2, 150000),
('OD002', 'HD002', 'SP005', 1, 300000),
('OD003', 'HD002', 'SP002', 4, 50000),
('OD004', 'HD003', 'SP004', 2, 80000), 
('OD005', 'HD004', 'SP006', 2, 180000),
('OD006', 'HD005', 'SP005', 2, 300000),
('OD007', 'HD006', 'SP007', 3, 60000),
('OD008', 'HD007', 'SP010', 1, 275000),
('OD009', 'HD008', 'SP002', 3, 50000),
('OD010', 'HD008', 'SP009', 1, 95000),
('OD011', 'HD009', 'SP003', 1, 250000),
('OD012', 'HD009', 'SP008', 1, 190000),
('OD013', 'HD010', 'SP004', 1, 80000),
('OD014', 'HD010', 'SP001', 1, 150000),
('OD015', 'HD010', 'SP007', 1, 85000); 
