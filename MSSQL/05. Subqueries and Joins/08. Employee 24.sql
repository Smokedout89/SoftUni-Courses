   SELECT e.EmployeeID,
          e.FirstName,    
     CASE
          WHEN YEAR(p.StartDate) < 2005 THEN p.Name
          WHEN YEAR(p.StartDate) > 2005 THEN NULL
          WHEN YEAR(p.StartDate) = 2005 THEN NULL
   END AS ProjectName
     FROM Projects AS p
LEFT JOIN EmployeesProjects AS ep ON p.ProjectID = ep.ProjectID
LEFT JOIN Employees AS e ON ep.EmployeeID = e.EmployeeID
    WHERE e.EmployeeID = '24'