SELECT TOP 5 o.Name,
             COUNT(a.Id)
          AS CountOfAnimals
        FROM Owners AS o
        JOIN Animals AS a
          ON o.Id = a.OwnerId
    GROUP BY o.Name
    ORDER BY CountOfAnimals DESC, o.Name