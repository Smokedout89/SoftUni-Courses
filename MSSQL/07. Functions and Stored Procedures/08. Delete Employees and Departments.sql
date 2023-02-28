CREATE PROC usp_DeleteEmployeesFromDepartment @departmentId INT
AS
BEGIN
    --First of all we should delete all records in EmployeeProjects where 
    --EmployeeID is one of the IDs that are being deleted
    DELETE FROM EmployeesProjects
          WHERE EmployeeID IN (
                               SELECT EmployeeID
                                 FROM Employees 
                                WHERE DepartmentID = @departmentId
                              )
                              
    --One of the futurely deleted Employees can be a Manager of a someone
    --We need to set ManagerID = NULL for those whose Manager will be deleted
    UPDATE Employees
       SET ManagerID = NULL
     WHERE ManagerID IN (
                         SELECT EmployeeID
                           FROM Employees 
                          WHERE DepartmentID = @departmentId
                        )

    --We should alter the table Departments and make the column ManagerID nullable
    --Because Manager of the Department can be one of thoose which will be deleted
    ALTER TABLE Departments
    ALTER COLUMN ManagerID INT

    UPDATE Departments
       SET ManagerID = NULL
     WHERE ManagerID IN (
                         SELECT EmployeeID
                           FROM Employees 
                          WHERE DepartmentID = @departmentId
                        )

    --After we removed all relations to the Employees that will be deleted
    --We should delete the Employees themself
    DELETE FROM Employees
          WHERE DepartmentID = @departmentId

    --And after we have removed all Employees from the Department
    --We can easily delete the Department
    DELETE FROM Departments
          WHERE DepartmentID = @departmentId

    --At the end we should select EmployeesCount from the given Department
    SELECT COUNT(EmployeeID)
      FROM Employees
     WHERE DepartmentID = @departmentId    
END