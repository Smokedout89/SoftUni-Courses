-- Find Department Ids
SELECT * 
FROM Departments
WHERE [Name] IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')

-- Update Salary
UPDATE Employees
SET Salary += Salary * 0.12
WHERE DepartmentID IN (1, 2, 4, 11)

SELECT Salary
FROM Employees