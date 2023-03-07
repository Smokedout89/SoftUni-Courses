   SELECT u.Username,
          c.Name AS CategoryName 
     FROM Reports AS r
     JOIN Categories AS c ON c.Id = r.CategoryId
     JOIN Users AS u ON u.Id = r.UserId
    WHERE DATEPART(DAY, r.OpenDate) = DATEPART(DAY, u.Birthdate)
 ORDER BY u.Username, CategoryName