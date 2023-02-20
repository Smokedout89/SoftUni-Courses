CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Birthdate DATE NOT NULL
)

INSERT INTO People
	VALUES
('Victor', '2000-12-07'),
('Steven', '1992-09-10'),
('Stephen', '1910-09-19'),
('John', '2010-01-06')

SELECT [Name],
	   DATEDIFF(YEAR, Birthdate, SYSDATETIME()) AS [Age in Years],
	   DATEDIFF(MONTH, Birthdate, SYSDATETIME()) AS [Age in Months],
	   DATEDIFF(DAY, Birthdate, SYSDATETIME()) AS [Age in Days],
	   DATEDIFF(MINUTE, Birthdate, SYSDATETIME()) AS [Age in Minutes]
  FROM People