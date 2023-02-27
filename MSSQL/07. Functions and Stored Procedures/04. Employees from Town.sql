CREATE PROC usp_GetEmployeesFromTown @townName VARCHAR(20)
AS
BEGIN
       SELECT e.FirstName,
              e.LastName 
         FROM Employees AS e
    LEFT JOIN Addresses AS a ON a.AddressID = e.AddressID
    LEFT JOIN Towns AS t ON t.TownID = a.TownID
        WHERE t.Name = @townName    
END