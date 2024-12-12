use Project_2;
-- 1. Identify High-Performing Employees

SELECT * FROM Project WHERE Status = 'Ongoing';

SELECT e.FirstName, e.LastName, p.ProjectName
FROM Employee e
JOIN EmployeeProject ep ON e.EmployeeID = ep.EmployeeID
JOIN Project p ON ep.ProjectID = p.ProjectID
WHERE p.Status = 'Ongoing'
AND e.EmployeeID IN (
    SELECT ep.EmployeeID
    FROM EmployeeProject ep
    JOIN Project p ON ep.ProjectID = p.ProjectID
    WHERE p.Status = 'Ongoing'
    GROUP BY ep.EmployeeID
    HAVING COUNT(DISTINCT ep.ProjectID) > 3
);

-- 2. Monitor Employee Attendance 
SELECT e.FirstName, e.LastName, COUNT(a.Date) AS TotalAbsences, 
       GROUP_CONCAT(a.Date ORDER BY a.Date ASC) AS AbsenceDates
FROM Employee e
JOIN Attendance a ON e.EmployeeID = a.EmployeeID
WHERE a.Status = 'Absent'
  AND a.Date BETWEEN DATE_FORMAT(NOW() - INTERVAL 1 MONTH, '%Y-%m-01') 
                  AND LAST_DAY(NOW() - INTERVAL 1 MONTH)
GROUP BY e.EmployeeID
HAVING COUNT(a.Date) > 3;


-- 3. Department Salary Analysis
SELECT d.DepartmentName, SUM(p.NetPay) AS TotalSalary, AVG(p.NetPay) AS AvgSalary
FROM Department d
JOIN Employee e ON d.DepartmentID = e.DepartmentID
JOIN Payroll p ON e.EmployeeID = p.EmployeeID
GROUP BY d.DepartmentID;

-- 4. Employee Without Projects 
SELECT e.FirstName, e.LastName, d.DepartmentName, r.RoleName
FROM Employee e
JOIN Department d ON e.DepartmentID = d.DepartmentID
JOIN Role r ON e.RoleID = r.RoleID
LEFT JOIN EmployeeProject ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.ProjectID IS NULL;


-- 5. Project Assignment Role 
SELECT e.FirstName, e.LastName, ep.RoleInProject
FROM Employee e
JOIN EmployeeProject ep ON e.EmployeeID = ep.EmployeeID
JOIN Project p ON ep.ProjectID = p.ProjectID
WHERE p.ProjectName = 'Tech Upgrade' AND p.Status = 'Ongoing';


-- 6. Payroll Verification 
SELECT e.FirstName, e.LastName, 
       p.BaseSalary, 
       p.NetPay, 
       ROUND((p.NetPay / p.BaseSalary) * 100, 2) AS Percentage
FROM Employee e
JOIN Payroll p ON e.EmployeeID = p.EmployeeID
WHERE ROUND((p.NetPay / p.BaseSalary) * 100, 2) < 60;


-- 7. Department Hire Dates 
SELECT d.DepartmentName, e.FirstName, e.LastName, e.HireDate
FROM Employee e
JOIN Department d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate = (SELECT MIN(HireDate) FROM Employee WHERE DepartmentID = d.DepartmentID);

-- 8. Long Working Hours 
SELECT e.FirstName, e.LastName, 
       a.Date, 
       TIMESTAMPDIFF(HOUR, a.CheckInTime, a.CheckOutTime) AS TotalHours
FROM Attendance a
JOIN Employee e ON a.EmployeeID = e.EmployeeID
WHERE TIMESTAMPDIFF(HOUR, a.CheckInTime, a.CheckOutTime) > 10;

  
-- 9. Department Leaders  
SELECT e.FirstName, e.LastName, d.DepartmentName
FROM Employee e
JOIN Department d ON e.DepartmentID = d.DepartmentID
WHERE e.RoleID = 1; 

  
-- 10. Salary Increment Plan 
UPDATE Payroll
SET BaseSalary = BaseSalary * 1.1
WHERE EmployeeID IN (SELECT EmployeeID FROM Employee WHERE HireDate < '2020-01-01');

-- 10. To check updated salaries
SELECT e.FirstName, e.LastName, p.BaseSalary
FROM Employee e
JOIN Payroll p ON e.EmployeeID = p.EmployeeID
WHERE e.HireDate < '2020-01-01';


/*Additional SQL Challenges */

-- 1. Employee Experience Report
SELECT 
    d.DepartmentName,
    COUNT(e.EmployeeID) AS TotalEmployees,
    AVG(DATEDIFF(CURDATE(), e.HireDate) / 365) AS AvgExperience
FROM 
    Employee e
JOIN 
    Department d ON e.DepartmentID = d.DepartmentID
GROUP BY 
    d.DepartmentName;

-- 2. Project Status Overview
SELECT 
    Status, 
    COUNT(ProjectID) AS ProjectCount
FROM 
    Project
GROUP BY 
    Status;
    
-- 3. Late Check-In Report
SELECT 
    E.FirstName,
    E.LastName,
    COUNT(A.EmployeeID) AS LateCheckInCount
FROM 
    Attendance A
JOIN 
    Employee E ON A.EmployeeID = E.EmployeeID
WHERE 
    A.CheckInTime > '09:00:00'
GROUP BY 
    E.EmployeeID
HAVING 
    COUNT(A.EmployeeID) > 5
ORDER BY 
    E.LastName, E.FirstName;

-- 4. Inactive Employees
SELECT e.FirstName, e.LastName, d.DepartmentName
FROM Employee e
JOIN Department d ON e.DepartmentID = d.DepartmentID
LEFT JOIN Attendance a ON e.EmployeeID = a.EmployeeID
WHERE a.Date IS NULL OR a.Date < CURDATE() - INTERVAL 3 MONTH;

-- 5. Employee Role Statistics:
SELECT r.RoleName, COUNT(e.EmployeeID) AS EmployeeCount
FROM Employee e
JOIN Role r ON e.RoleID = r.RoleID
GROUP BY r.RoleName;

-- 6. Overdue Projects
SELECT p.ProjectName, p.Status, DATEDIFF(CURDATE(), p.StartDate) AS OverdueDays
FROM Project p
WHERE p.Status != 'Completed' AND DATEDIFF(CURDATE(), p.StartDate) > 0;

-- 7. Employee Attendance Patterns
SELECT e.FirstName, e.LastName,
       (COUNT(CASE WHEN a.Status = 'Present' THEN 1 END) / COUNT(a.Date)) * 100 AS AttendancePercentage
FROM Employee e
JOIN Attendance a ON e.EmployeeID = a.EmployeeID
WHERE a.Date >= CURDATE() - INTERVAL 1 MONTH
GROUP BY e.EmployeeID
HAVING AttendancePercentage > 90;

-- 8. Highest Paid Employees
SELECT e.FirstName, e.LastName, d.DepartmentName, r.RoleName, p.NetPay
FROM Employee e
JOIN Department d ON e.DepartmentID = d.DepartmentID
JOIN Role r ON e.RoleID = r.RoleID
JOIN Payroll p ON e.EmployeeID = p.EmployeeID
ORDER BY p.NetPay DESC
LIMIT 5;

-- 9. Cross-Department Projects
SELECT p.ProjectName, COUNT(DISTINCT e.DepartmentID) AS DepartmentCount
FROM Project p
JOIN EmployeeProject ep ON p.ProjectID = ep.ProjectID
JOIN Employee e ON ep.EmployeeID = e.EmployeeID
GROUP BY p.ProjectName
HAVING COUNT(DISTINCT e.DepartmentID) > 3;

















