  SELECT LEFT(FirstName, 1)
      AS FirstLetter
    FROM WizzardDeposits
   WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)
ORDER BY LEFT(FirstName, 1)

--   SELECT *
--     FROM (
--           SELECT 
--               SUBSTRING(FirstName, 1, 1) 
--               AS FirstLetter
--           FROM WizzardDeposits
--           WHERE DepositGroup = 'Troll Chest'
--          ) AS FirstLetterQuery
-- GROUP BY FirstLetter
-- ORDER BY FirstLetter