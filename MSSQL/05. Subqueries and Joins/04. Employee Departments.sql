SELECT TOP 5 e.EmployeeID,
             e.FirstName,
             e.Salary,
             d.Name   
        FROM Departments AS d
        JOIN Employees AS e ON d.DepartmentID = e.DepartmentID
       WHERE e.Salary > 15000
    ORDER BY d.DepartmentID  