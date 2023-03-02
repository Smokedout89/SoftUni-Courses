SELECT c.LastName,
       AVG(s.[Length])
	AS CiagrLength,
	   CEILING(AVG(s.RingRange))
    AS CiagrRingRange
  FROM Clients AS c
  JOIN ClientsCigars AS cc
    ON cc.ClientId = c.Id
  JOIN Cigars AS cig
    ON cig.Id = cc.CigarId
  JOIN Sizes as s	
    ON s.Id = cig.SizeId
GROUP BY c.LastName
ORDER BY CiagrLength DESC