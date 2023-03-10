CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30)) 
RETURNS INT
AS
BEGIN
	DECLARE @creatorId INT = (
							  SELECT Id
							    FROM Creators
							   WHERE FirstName = @name
							 )
	DECLARE @totalNumber INT = (
								SELECT COUNT(*)								
								  FROM CreatorsBoardgames 
								 WHERE CreatorId = @creatorId
							   )
	RETURN @totalNumber
END