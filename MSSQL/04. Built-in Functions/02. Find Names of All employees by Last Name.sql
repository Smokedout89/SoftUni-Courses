SELECT FirstName, LastName
  FROM Employees
 WHERE LastName LIKE '%ei%'
 --WHERE CHARINDEX('ei', LastName) <> 0