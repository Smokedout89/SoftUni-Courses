CREATE PROC usp_SearchByAirportName @airportName VARCHAR(70)
AS
BEGIN
    SELECT a.AirportName,
           p.FullName,
      CASE 
           WHEN fd.TicketPrice <= 400 THEN 'Low'
           WHEN fd.TicketPrice > 400 AND fd.TicketPrice <= 1500 THEN 'Medium'
           ELSE 'High'  
       END AS LevelOfTickerPrice,
           ac.Manufacturer,
           ac.Condition,
           atype.TypeName
      FROM Airports AS a
      JOIN FlightDestinations AS fd
        ON fd.AirportId = a.Id
      JOIN Passengers AS p
        ON p.Id = fd.PassengerId
      JOIN Aircraft AS ac
        ON ac.Id = fd.AircraftId 
      JOIN AircraftTypes AS atype
        ON atype.Id = ac.TypeId  
     WHERE AirportName = @airportName
  ORDER BY ac.Manufacturer, p.FullName   
END