SELECT *
  INTO EmployeeAverageSalary
  FROM Employees
 WHERE Salary > 30000 

DELETE
  FROM EmployeeAverageSalary
 WHERE ManagerID = 42

UPDATE EmployeeAverageSalary
   SET Salary += 5000 
 WHERE DepartmentID = 1

  SELECT DepartmentID,
         AVG(Salary)
      AS AverageSalary  
    FROM EmployeeAverageSalary
GROUP BY DepartmentID