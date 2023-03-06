  SELECT a.Name,
         DATEPART(YEAR, a.BirthDate)
      AS BirthYear,
         atype.AnimalType
    FROM Animals AS a
    JOIN AnimalTypes AS atype
      ON atype.Id = a.AnimalTypeId
   WHERE a.OwnerId IS NULL 
     AND DATEDIFF(YEAR, a.BirthDate, '01/01/2022') < 5 
     AND atype.AnimalType <> 'Birds'
ORDER BY a.Name