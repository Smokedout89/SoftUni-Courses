  SELECT CONCAT(o.Name, '-', a.Name)
      AS OwnersAnimals,
         o.PhoneNumber,
         ac.CageId
    FROM Owners AS o
    JOIN Animals AS a
      ON a.OwnerId = o.Id
    JOIN AnimalTypes AS atype
      ON atype.Id = a.AnimalTypeId
    JOIN AnimalsCages AS ac
      ON ac.AnimalId = a.Id
   WHERE atype.AnimalType = 'Mammals'   
ORDER BY o.Name, a.Name DESC