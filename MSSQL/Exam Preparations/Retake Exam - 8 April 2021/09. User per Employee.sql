   SELECT CONCAT(e.FirstName, ' ', e.LastName) 
       AS FullName,
          COUNT(u.Id)
       AS UserCount   
     FROM Employees AS e
LEFT JOIN Reports AS r ON r.EmployeeId = e.Id
LEFT JOIN Users AS u ON u.Id = r.UserId
 GROUP BY e.FirstName, e.LastName
 ORDER BY UserCount DESC, FullName