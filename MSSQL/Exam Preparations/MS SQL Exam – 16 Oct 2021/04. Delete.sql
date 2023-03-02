SELECT Id
  FROM Addresses
 WHERE Country LIKE 'c%'

DELETE FROM Clients
      WHERE AddressId IN (
						   SELECT Id
							 FROM Addresses
							WHERE Country LIKE 'c%'
						 )

DELETE FROM Addresses
      WHERE Country LIKE 'c%'