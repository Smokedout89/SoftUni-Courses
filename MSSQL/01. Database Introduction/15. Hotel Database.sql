CREATE DATABASE [Hotel]

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Title] NVARCHAR(25) NOT NULL,
	[Notes] NVARCHAR(100)
)

CREATE TABLE [Customers](
	[AccountNumber] NVARCHAR(20) NOT NULL PRIMARY KEY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50),
	[PhoneNumber] NVARCHAR(15) NOT NULL,
	[EmergencyName] NVARCHAR(50),
	[EmergencyNumber] NVARCHAR(15),
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [RoomStatus](
	[RoomStatus] NVARCHAR(100) NOT NULL PRIMARY KEY,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [RoomTypes](
	[RoomType] NVARCHAR(100) NOT NULL PRIMARY KEY,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [BedTypes](
	[BedType] NVARCHAR(100) NOT NULL PRIMARY KEY,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Rooms](
	[RoomNumber] INT NOT NULL PRIMARY KEY,
	[RoomType] NVARCHAR(100) NOT NULL,
	[BedType] NVARCHAR(100) NOT NULL,
	[Rate] DECIMAL NOT NULL,
	[RoomStatus] NVARCHAR(100) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Payments](
	[Id] INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL,
	PaymentDate DATE NOT NULL,
	AccountNumber NVARCHAR(20) NOT NULL,
	FirstDateOccupied DATE,
	LastDateOccupied DATE,
	TotalDays INT,
	AmountCharged DECIMAL,
	TaxRate DECIMAL,
	TaxAmount DECIMAL,
	PaymentTotal DECIMAL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE [Occupancies](
	[Id] INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL,
	DateOccupied DATE,
	AccountNumber  NVARCHAR(20) NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied DECIMAL,
	PhoneCharge DECIMAL,
	Notes NVARCHAR(MAX)
)

INSERT INTO [Employees]([FirstName], [LastName], [Title])
	VALUES
('Gosho', 'Toshev', 'Chistach'),
('Pesho', 'Goshev', 'Poddrujka'),
('Losho', 'Mie', 'Merindjei')

INSERT INTO [Customers]([AccountNumber], [FirstName], [PhoneNumber] )
	VALUES
('12431', 'Gosho', '+359142352123'),
('13324', 'Pesho', '+359134235454'),
('45421', 'Losho', '+359923412345')

INSERT INTO [RoomStatus]([RoomStatus])
	VALUES
('Status'),
('Matus'),
('Tatus')

INSERT INTO [RoomTypes]([RoomType])
	VALUES
('Staq'),
('Nomer'),
('Dve')

INSERT INTO [BedTypes]([BedType])
	VALUES
('Leglo'),
('Divan'),
('Duishek')

INSERT INTO [Rooms]([RoomNumber], [RoomType], [BedType], [Rate], [RoomStatus])
	VALUES
(306, 'Staq', 'Leglo', 100, 'Matus'),
(305, 'Nomer', 'Divan', 200, 'Tatus'),
(420, 'Dve', 'Duishek', 150, 'Status')

INSERT INTO [Payments]([EmployeeId], [PaymentDate], [AccountNumber])
	VALUES
(1, '2020-10-25', '12431'),
(2, '2022-02-05', '13324'),
(3, '2021-06-15', '45421')

INSERT INTO [Occupancies]([EmployeeId], [AccountNumber], [RoomNumber])
	VALUES
(1, '12431', 306),
(2, '13324', 305),
(3, '45421', 420)