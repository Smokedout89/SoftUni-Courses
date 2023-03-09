  SELECT p.FullName,
         COUNT(fd.Id)
      AS CountOfAircraft,
         SUM(fd.TicketPrice)
      AS TotalPayed      
    FROM Passengers AS p
    JOIN FlightDestinations AS fd
      ON fd.PassengerId = p.Id
   WHERE SUBSTRING(p.FullName, 2, 1) = 'a'
GROUP BY p.Id, p.FullName
  HAVING COUNT(fd.Id) > 1
ORDER BY p.FullName