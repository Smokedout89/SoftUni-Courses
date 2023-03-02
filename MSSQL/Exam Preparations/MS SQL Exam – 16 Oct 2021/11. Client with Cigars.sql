CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN 
	DECLARE @userId INT = (
				           SELECT Id 
				             FROM Clients
				            WHERE FirstName = @name
					      )
	DECLARE @cigarsCount INT = (
								SELECT COUNT(CigarId)
								  FROM ClientsCigars
								 WHERE ClientId = @userId
							   )
	RETURN @cigarsCount
END