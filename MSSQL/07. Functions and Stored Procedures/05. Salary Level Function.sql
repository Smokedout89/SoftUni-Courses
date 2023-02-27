CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
    DECLARE @salaryLevel VARCHAR(10)

    IF @salary < 30000
        SET @salaryLevel = 'Low'
    ELSE IF @salary BETWEEN 30000 AND 50000
        SET @salaryLevel = 'Average'
    ELSE IF @salary > 50000
        SET @salaryLevel = 'High'    

    RETURN @salaryLevel
END