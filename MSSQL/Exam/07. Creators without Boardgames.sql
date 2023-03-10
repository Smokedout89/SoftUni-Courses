   SELECT c.Id,
	      CONCAT(c.FirstName, ' ', c.LastName)
	   AS CreatorName,
	      c.Email
     FROM Creators AS c 
LEFT JOIN CreatorsBoardgames AS cb 
       ON cb.CreatorId = c.Id
LEFT JOIN Boardgames AS b
       ON b.Id = cb.BoardgameId
	WHERE b.Id IS NULL