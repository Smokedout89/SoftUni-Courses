CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH([Picture]) <= 2000000),
	[Height] DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	[Gender] CHAR(1),
	CHECK ([Gender] = 'm' OR [Gender] = 'f'),
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX)
)

INSERT INTO [People]([Name], [Height], [Weight], [Gender], [Birthdate])
	VALUES
('Tosho', 1.70, 69.3, 'm', '1995-08-29'),
('Pesho', 1.80, 79.3, 'm', '1992-03-12'),
('Gosho', NULL, NULL, 'm', '1991-05-30'),
('Sneji', 1.60, NULL, 'f', '1993-01-13'),
('Lidka', 1.65, 59.3, 'f', '1998-09-02')