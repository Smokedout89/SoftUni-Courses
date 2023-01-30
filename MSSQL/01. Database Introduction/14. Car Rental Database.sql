CREATE DATABASE [CarRental]

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[DailyRate] DECIMAL CHECK (DailyRate > 0),
	[WeeklyRate] DECIMAL CHECK (WeeklyRate > 0),
	[MonthlyRate] DECIMAL CHECK (MonthlyRate > 0),
	[WeekendRate] DECIMAL CHECK (WeekendRate > 0)
)

CREATE TABLE [Cars](
	[Id] INT PRIMARY KEY IDENTITY,
	[PlateNumber] NVARCHAR(20) UNIQUE,
	[Manufacturer] NVARCHAR(20),
	[Model] NVARCHAR(20),
	[CarYear] DATE,
	[CategoryId] INT NOT NULL CHECK (CategoryId > 0),
	[Doors] INT CHECK (Doors >= 2 AND Doors <= 4),
	[Picture] VARBINARY(MAX),
	[Condition] NVARCHAR(20),
	[Available] BIT
)

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(20) NOT NULL,
	[LastName] NVARCHAR(20) NOT NULL,
	[Title] NVARCHAR(20) NOT NULL,
	[Notes] NVARCHAR(150)
)

CREATE TABLE [Customers](
	[Id] INT PRIMARY KEY IDENTITY,
	[DrivingLicenseNumber] INT NOT NULL,
	[FullName] NVARCHAR(100) NOT NULL,
	[Address] NVARCHAR(100) NOT NULL,
	[City] NVARCHAR(50) NOT NULL,
	[ZIPCode] INT NOT NULL,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [RentalOrders](
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT NOT NULL CHECK (EmployeeId > 0),
	[CustomerId] INT NOT NULL CHECK (CustomerId > 0),
	[CarId] INT NOT NULL CHECK (CarId > 0) UNIQUE,
	[TankLevel] INT CHECK (TankLevel >= 0 AND TankLevel <= 10),
	[KilometrageStart] INT NOT NULL,
	[KilometrageEnd] INT NOT NULL,	
	[TotalKilometrage] INT NOT NULL,
	[StartDate] DATE,
	[EndDate] DATE,
	[TotalDays] INT,
	[RateApplied] NVARCHAR(50),
	[TaxRate] NVARCHAR(50),
	[OrderStatus] NVARCHAR(50),
	[Notes] NVARCHAR(150)
)

INSERT INTO [Categories]([CategoryName], [DailyRate])
	VALUES
('Car', 10),
('Bus', 20),
('Van', 30)

INSERT INTO [Cars]([PlateNumber], [Manufacturer], [Model], [CategoryId], [Condition])
	VALUES
('1234', 'Mercedes', 'S63', 1, 'New'),
('4321', 'BMW', 'M5', 2, 'Used'),
('2345', 'Audi', 'S8', 3, 'Used')

INSERT INTO [Employees]([FirstName], [LastName], [Title])
	VALUES
('Gosho', 'Goshev', 'Chirak'),
('Tosho', 'Toshev', 'Chirak'),
('Pesho', 'Peshev', 'Manager')

INSERT INTO [Customers]([DrivingLicenseNumber], [FullName], [Address], [City], [ZIPCode])
	VALUES
(3123, 'Gosho Toshev', 'str. Slaviq 10', 'Sofia', 5000),
(1234, 'Pesho Mazniq', 'str. Blabla 3', 'Plovdiv', 1245),
(4321, 'Jorko Bedniq', 'str. Puuuuuu 123', 'Varna', 4354)

INSERT INTO [RentalOrders]([EmployeeId], [CustomerId], [CarId], [KilometrageStart], [KilometrageEnd], [TotalKilometrage])
	VALUES
(1, 1, 1, 0, 220, 200),
(2, 2, 2, 0, 250, 250),
(3, 3, 3, 0, 320, 320)