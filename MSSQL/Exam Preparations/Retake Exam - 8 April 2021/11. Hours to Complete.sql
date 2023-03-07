CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
    DECLARE @hours INT = (
                          CASE 
                              WHEN @StartDate IS NULL THEN 0
                              WHEN @EndDate IS NULL THEN 0
                              ELSE DATEDIFF(HOUR, @StartDate, @EndDate)
                          END
                         );
    RETURN @hours
END