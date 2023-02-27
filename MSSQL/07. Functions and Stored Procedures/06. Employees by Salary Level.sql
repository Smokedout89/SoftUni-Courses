CREATE PROC usp_EmployeesBySalaryLevel @salaryLevel VARCHAR(10)
AS
BEGIN
    SELECT FirstName,
           LastName 
      FROM Employees
     WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel
END