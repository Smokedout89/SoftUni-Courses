CREATE PROC usp_SearchForFiles @fileExtension VARCHAR(100)
AS
BEGIN
    SELECT f.Id,
           f.[Name],
           CONCAT(f.Size, 'KB')
        AS Size           
      FROM Files AS f
     WHERE [Name] LIKE CONCAT('%.', @fileExtension)  
    ORDER BY f.Id, f.[Name], f.Size DESC
END