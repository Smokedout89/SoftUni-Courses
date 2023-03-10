DELETE FROM CreatorsBoardgames
      WHERE BoardgameId IN (
							SELECT Id
						      FROM Boardgames
						     WHERE PublisherId IN (
												   SELECT Id
												     FROM Publishers
												    WHERE AddressId IN (
																	    SELECT Id
																	      FROM Addresses
																	     WHERE Country = 'USA'
							)					   )				    )
DELETE FROM Boardgames
      WHERE PublisherId IN ( SELECT Id
						       FROM Publishers
						      WHERE AddressId IN (
										           SELECT Id
										             FROM Addresses
										            WHERE Country = 'USA'
							)				     )

DELETE FROM Publishers
      WHERE AddressId IN (
					      SELECT Id
							FROM Addresses
						   WHERE Country = 'USA'
						 )

DELETE FROM Addresses
	  WHERE Country = 'USA'