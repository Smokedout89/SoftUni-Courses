  SELECT s.Name,
         l.Name,
         s.Establishment,
         c.Name
    FROM Sites AS s
    JOIN Categories AS c ON c.Id = s.CategoryId
    JOIN Locations AS l ON l.Id = s.LocationId
ORDER BY c.Name DESC, l.Name, s.Name