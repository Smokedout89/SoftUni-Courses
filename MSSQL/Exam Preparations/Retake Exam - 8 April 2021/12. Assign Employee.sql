CREATE PROC usp_AssignEmployeeToReport @EmployeeId INT, @ReportId INT
AS
BEGIN
    DECLARE @empDepartmentId INT = (
                                    SELECT DepartmentId
                                      FROM Employees 
                                     WHERE Id = @EmployeeId
                                   )
    DECLARE @repDepartmentId INT = (
                                    SELECT c.DepartmentId 
                                      FROM Reports AS r
                                      JOIN Categories AS c ON c.Id = r.CategoryId
                                     WHERE r.Id = @ReportId
                                   )

    IF @empDepartmentId <> @repDepartmentId
        THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1
    ELSE 
        UPDATE Reports
           SET EmployeeId = @EmployeeId
         WHERE Id = @ReportId     
END