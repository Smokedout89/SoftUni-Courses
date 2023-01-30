CREATE DATABASE [Movies]

CREATE TABLE [Directors](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50),
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Genres](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50),
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50),
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Movies](
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(50) NOT NULL,
	[DirectorId] INT NOT NULL,
	[CopyrightYear] INT,
	[Length] TIME NOT NULL,
	[GenreId] INT NOT NULL,
	[CategoryId] INT NOT NULL,
	[Rating] INT CHECK ([Rating] > 0 AND [Rating] < 10),
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Directors]([Name], [Notes])
	VALUES
('Alfred Hitchcock', 'some notes'),
('Martin Scorsese', 'no notes'),
('Buster Keaton', ''),
('Howard Hawks', 'nooooope'),
('John Ford', '')

INSERT INTO [Genres]([Name], [Notes])
	VALUES
('Action', 'notes'),
('Comedy', 'no notes'),
('Thriller', 'empty'),
('Fiction', 'what'),
('Drama', '')

INSERT INTO [Categories]([Name])
	VALUES
('Action'),
('Comedy'),
('Thriller'),
('Fiction'),
('Drama')

INSERT INTO [Movies]([Title], [DirectorId], [CopyrightYear] ,[Length], [GenreId], [CategoryId], [Rating])
	VALUES
('Movie n1', 1, 2020, '01:30:00', 1, 1, 5),
('Movie n2', 2, 2020, '01:30:00', 2, 2, 5),
('Movie n3', 3, 2020, '01:30:00', 3, 3, 5),
('Movie n4', 4, 2020, '01:30:00', 4, 4, 5),
('Movie n5', 5, 2020, '01:30:00', 5, 5, 5)