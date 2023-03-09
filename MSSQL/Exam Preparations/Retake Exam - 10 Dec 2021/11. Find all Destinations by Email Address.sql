CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50)) 
RETURNS INT
AS
BEGIN
    DECLARE @userId INT = (    
                           SELECT Id
                             FROM Passengers
                            WHERE Email = @email
                          )
    DECLARE @destinationCount INT = (
                                     SELECT COUNT(Id)
                                       FROM FlightDestinations
                                      WHERE PassengerId = @userId
                                    )
    RETURN @destinationCount
END