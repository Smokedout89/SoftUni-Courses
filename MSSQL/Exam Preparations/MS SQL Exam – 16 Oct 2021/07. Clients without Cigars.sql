         SELECT c.Id,
				CONCAT(c.FirstName,' ', c.LastName)
			 AS ClientName,
			    c.Email
           FROM Clients AS c
FULL OUTER JOIN ClientsCigars AS cc
             ON cc.ClientId = c.Id
		  WHERE cc.CigarId IS NULL
       ORDER BY ClientName
