  SELECT l.Province,
         l.Municipality,
         l.Name,
         COUNT(l.Id) AS CountOfSites
    FROM Locations AS l
    JOIN Sites AS s ON s.LocationId = l.Id
   WHERE l.Province = 'Sofia'
GROUP BY l.Province, l.Municipality, l.Name
ORDER BY CountOfSites DESC, l.Name