SELECT ContinentCode,
       CurrencyCode,
       CurrencyUsage 
    FROM (
            SELECT *,
                   DENSE_RANK() OVER(PARTITION BY ContinentCode ORDER BY CurrencyUsage DESC)
                AS CurrencyRank
              FROM (       
                       SELECT co.ContinentCode,
                              c.CurrencyCode,
                              COUNT(c.CurrencyCode) AS CurrencyUsage 
                         FROM Continents AS co
                         JOIN Countries AS c ON co.ContinentCode = c.ContinentCode
                     GROUP BY co.ContinentCode, c.CurrencyCode
                   ) AS CurrencyUsageQuery
             WHERE CurrencyUsage > 1
         ) AS CurrencyRankingQuery 
   WHERE CurrencyRank = 1
ORDER BY ContinentCode        