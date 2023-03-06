  SELECT v.Name,
         v.PhoneNumber,
         SUBSTRING(v.Address, CHARINDEX(',', v.Address) + 2, LEN(v.Address))
         --TRIM(REPLACE(REPLACE(v.Address, 'Sofia', ''), ',', ''))
      AS [Address]
    FROM Volunteers AS v
    JOIN VolunteersDepartments AS vd
      ON vd.Id = v.DepartmentId
   WHERE vd.DepartmentName = 'Education program assistant' AND v.Address LIKE '%Sofia%'
ORDER BY v.Name