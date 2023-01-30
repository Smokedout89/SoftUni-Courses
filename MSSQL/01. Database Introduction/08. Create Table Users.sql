CREATE TABLE [Users](
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	CHECK (DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT
)

INSERT INTO [Users]([Username], [Password], [LastLoginTime], [IsDeleted])
	VALUES
('user', 'password', '2020-08-30 15:30:23', 0),
('shiit', 'superpass', '2015-05-30 22:15:00', 0),
('here', 'strongpw', '2013-02-28 18:35:23', 1),
('we', 'yeabro123', '2022-9-12 17:35:23', 0),
('go', 'suppp321', '2023-01-4 00:30:23', 0)