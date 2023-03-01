         SELECT fp.Id,
                fp.Name,
                CONCAT(fp.[Size], 'KB')
             AS Size  
           FROM Files AS fch
FULL OUTER JOIN Files AS fp
             ON fch.ParentId = fp.Id
          WHERE fch.Id IS NULL
       ORDER BY fp.Id, fp.Name, fp.Size DESC