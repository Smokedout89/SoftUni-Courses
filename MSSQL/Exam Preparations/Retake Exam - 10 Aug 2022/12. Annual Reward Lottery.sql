CREATE PROC usp_AnnualRewardLottery @TouristName VARCHAR(50)
AS
BEGIN
    DECLARE @siteCount INT = (
                              SELECT COUNT(st.SiteId)
                                FROM Tourists AS t
                                JOIN SitesTourists AS st ON st.TouristId = t.Id
                               WHERE t.Name = @TouristName 
                             )

    UPDATE Tourists
       SET Reward =
      CASE 
           WHEN @siteCount >= 100 THEN 'Gold badge'
           WHEN @siteCount >= 50 THEN 'Silver badge'
           WHEN @siteCount >= 25 THEN 'Bronze badge'
       END
     WHERE [Name] = @TouristName

     SELECT [Name],
            Reward
       FROM Tourists
      WHERE [Name] = @TouristName 
END