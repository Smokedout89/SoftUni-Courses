CREATE PROC usp_GetTownsStartingWith @startWith VARCHAR(10)
AS
BEGIN
    SELECT [Name] AS Town
      FROM Towns
     WHERE [Name] LIKE @startWith + '%'
END