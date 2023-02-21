SELECT TOP 5 e.EmployeeID,
             e.JobTitle,
             a.AddressID,
             a.AddressText
        FROM Addresses AS a
        JOIN Employees AS e ON a.AddressID = e.AddressID
    ORDER BY a.AddressID