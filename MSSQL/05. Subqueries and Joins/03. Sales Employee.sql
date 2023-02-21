  SELECT e.EmployeeID,
         e.FirstName,
         e.LastName,
         d.Name  
    FROM Departments AS d
    JOIN Employees AS e ON d.DepartmentID = e.DepartmentID
   WHERE d.Name = 'Sales'
ORDER BY EmployeeID