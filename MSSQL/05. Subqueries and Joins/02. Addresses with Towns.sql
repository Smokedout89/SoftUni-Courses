SELECT TOP 50 e.FirstName,
              e.LastName,
              t.Name,
              a.AddressText 
         FROM Towns AS t 
         JOIN Addresses AS a ON t.TownID = a.TownID 
         JOIN Employees AS e ON a.AddressID = e.AddressID
     ORDER BY e.FirstName, e.LastName