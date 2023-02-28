CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(50))
RETURNS TABLE
AS RETURN (
            SELECT SUM(Cash)
                AS SumCash            
              FROM (
                    SELECT ug.Cash,
                           ROW_NUMBER() OVER(ORDER BY ug.Cash DESC)
                        AS RowNumber   
                      FROM UsersGames AS ug
                      JOIN Games AS g ON g.Id = ug.GameId
                     WHERE g.Name = @gameName 
                   ) AS RowNumberSubquery
             WHERE RowNumber % 2 <> 0   
          )