  SELECT a.Id,
         a.Manufacturer,
         a.FlightHours,
         COUNT(fd.Id)
      AS FlightDestinationCount,
         ROUND(AVG(fd.TicketPrice), 2)
      AS AvgPrice
    FROM Aircraft AS a
    JOIN FlightDestinations AS fd
      ON fd.AircraftId = a.Id
GROUP BY a.Id, a.Manufacturer, a.FlightHours
  HAVING COUNT(fd.Id) >= 2
ORDER BY FlightDestinationCount DESC, a.Id