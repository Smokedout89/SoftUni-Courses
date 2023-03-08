CREATE FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(100))
RETURNS INT
AS
BEGIN
    DECLARE @touristSiteId INT = (
                                  SELECT Id
                                    FROM Sites
                                   WHERE [Name] = @Site
                                 )

    DECLARE @touristCount INT = (
                                 SELECT COUNT(*)
                                   FROM SitesTourists
                                  WHERE SiteId = @touristSiteId    
                                )
    RETURN @touristCount
END