CREATE PROC usp_SearchByCategory @category VARCHAR(50)
AS
BEGIN
	SELECT b.Name,
		   b.YearPublished,
		   b.Rating,
		   c.Name,
		   p.Name,
		   CONCAT(pr.PlayersMin, ' ', 'people')
		AS MinPlayers,
		   CONCAT(pr.PlayersMax, ' ', 'people')
		AS MaxPlayers	
	  FROM Categories AS c
	  JOIN Boardgames AS b ON b.CategoryId = c.Id
	  JOIN PlayersRanges AS pr ON pr.Id = b.PlayersRangeId
	  JOIN Publishers AS p ON p.Id = b.PublisherId
     WHERE c.Name = @category
  ORDER BY p.Name, b.YearPublished DESC
END