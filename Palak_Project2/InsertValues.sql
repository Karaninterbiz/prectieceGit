use Project_2;

-- 1. Insert data into Employee Table
INSERT INTO Employee (EmployeeID, FirstName, LastName, DepartmentID, RoleID, HireDate) VALUES
(1, 'Palak', 'Mishra', 2, 1, '2015-06-10'),
(2, 'Sita', 'Sharma', 2, 2, '2018-07-15'),
(3, 'Aarav', 'Patel', 3, 4, '2020-05-25'),
(4, 'Ravi', 'Kumar', 2, 3, '2019-04-10'),
(5, 'Raj', 'Singh', 1, 2, '2021-09-15'),
(6, 'Ravi', 'Verma', 2, 1, '2015-06-10'),
(7, 'Anita', 'Kumar', 2, 2, '2018-07-15'),
(8, 'Priya', 'Mehta', 3, 4, '2020-05-25'),
(9, 'Suresh', 'Patel', 2, 3, '2019-04-10'),
(10, 'Amit', 'Sharma', 1, 2, '2021-09-15'),
(11, 'Riya', 'Singh', 3, 2, '2022-08-01'),
(12, 'Pyl', 'Mishra', 4, 2, '2022-08-01');

/*SET FOREIGN_KEY_CHECKS = 0;
DELETE FROM Employee;
SET FOREIGN_KEY_CHECKS = 1;

SET SQL_SAFE_UPDATES = 0;
DELETE FROM Employee;
SET SQL_SAFE_UPDATES = 1;*/

select * from Employee;   

-- 2. Insert data into Department Table
INSERT INTO Department (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'Engineering'),
(3, 'Marketing');

select * from Department;

-- 3. Insert data into Role Table
INSERT INTO Role (RoleID, RoleName) VALUES
(1, 'Manager'),
(2, 'Engineer'),
(3, 'Developer'),
(4, 'Marketing Specialist');

-- 4. Insert data into Project Table
INSERT INTO Project (ProjectID, ProjectName, Status, StartDate) VALUES
(1, 'Tech Upgrade', 'Ongoing', '2023-01-01'),
(2, 'Marketing Campaign', 'Completed', '2023-05-10'),
(3, 'AI Development', 'Ongoing', '2023-03-20');
INSERT INTO Project (ProjectID, ProjectName, Status, StartDate)
VALUES (4, 'AI Development', 'Pending', '2023-06-25');
INSERT INTO Project (ProjectID, ProjectName, Status, StartDate) VALUES
(5, 'Cloud Migration', 'Ongoing', '2023-04-15');
INSERT INTO Project (ProjectID, ProjectName, Status, StartDate) VALUES
(6, 'Marketing Campaign', 'Pending', '2023-07-25');
INSERT INTO Project (ProjectID, ProjectName, Status, StartDate) VALUES
(7, 'AI Development', 'Ongoing', '2023-05-20');

select * from Project;

-- 5. Insert data into EmployeeProject Table
-- ProjectID = 1
INSERT INTO EmployeeProject (EmployeeID, ProjectID, RoleInProject) VALUES
(1, 1, 'Manager'),   
(2, 1, 'Engineer'),   
(3, 1, 'Developer'),  
(4, 1, 'Engineer'),   
(5, 1, 'Marketing Specialist'),  
(12, 1, 'Sales Manager'); 

-- ProjectID = 2
INSERT INTO EmployeeProject (EmployeeID, ProjectID, RoleInProject) VALUES
(6, 2, 'Manager'),    
(7, 2, 'Engineer'),   
(8, 2, 'Developer'),  
(9, 2, 'Engineer'),   
(10, 2, 'Marketing Specialist'),  
(12, 2, 'Sales Manager');  

-- ProjectID = 3
INSERT INTO EmployeeProject (EmployeeID, ProjectID, RoleInProject) VALUES
(1, 3, 'Manager'),    
(2, 3, 'Engineer'),   
(3, 3, 'Developer'), 
(5, 3, 'Marketing Specialist'),  
(6, 3, 'Manager'),  
(12, 3, 'Sales Manager');  

-- Inserting additional projects for Employee 1 (Palak) to make them work on more than 3 ongoing projects.
INSERT INTO EmployeeProject (EmployeeID, ProjectID, RoleInProject) VALUES
(1, 2, 'Manager'),   
(1, 3, 'Manager');  

-- Inserting additional projects for Employee 2 (Sita)
INSERT INTO EmployeeProject (EmployeeID, ProjectID, RoleInProject) VALUES
(2, 3, 'Engineer');  


-- Assign employees to the new project
INSERT INTO EmployeeProject (EmployeeID, ProjectID, RoleInProject) VALUES
(1, 4, 'Manager'),   
(2, 4, 'Engineer'),  
(3, 4, 'Developer'), 
(5, 4, 'Marketing Specialist'),  
(12, 4, 'Sales Manager');  

-- Assign additional employees to create a scenario where some employees work on more than three ongoing projects
INSERT INTO EmployeeProject (EmployeeID, ProjectID, RoleInProject) VALUES
(1, 1, 'Manager'),   
(1, 3, 'Manager'),   
(1, 4, 'Manager');  

-- Assign Palak to additional ongoing projects
INSERT INTO EmployeeProject (EmployeeID, ProjectID, RoleInProject) VALUES
(1, 5, 'Manager'),  
(1, 3, 'Manager'),  
(1, 4, 'Manager'); 

INSERT INTO EmployeeProject (EmployeeID, ProjectID, RoleInProject) VALUES
(1, 2, 'Manager'), 
(1, 3, 'Manager'), 
(1, 4, 'Manager'), 
(1, 5, 'Manager');

-- Assign additional projects to Sita (EmployeeID = 2)
INSERT INTO EmployeeProject (EmployeeID, ProjectID, RoleInProject) 
VALUES 
(2, 5, 'Engineer'),  
(2, 6, 'Engineer');  

-- Assign additional projects to Aarav (EmployeeID = 3)
INSERT INTO EmployeeProject (EmployeeID, ProjectID, RoleInProject) 
VALUES 
(3, 5, 'Developer'),  
(3, 6, 'Developer');  

-- Assign additional projects to Ravi (EmployeeID = 4)
INSERT INTO EmployeeProject (EmployeeID, ProjectID, RoleInProject) 
VALUES 
(4, 5, 'Engineer'),  
(4, 6, 'Engineer');  

SELECT * FROM EmployeeProject;

/*DELETE FROM EmployeeProject;
SET SQL_SAFE_UPDATES = 0;
SET SQL_SAFE_UPDATES = 1;*/


-- 6. Insert data into Attendance Table
INSERT INTO Attendance (EmployeeID, Date, CheckInTime, CheckOutTime, Status) VALUES
(1, '2024-11-01', '09:00:00', '17:00:00', 'Present'),
(2, '2024-11-01', '09:15:00', '17:15:00', 'Absent'),
(3, '2024-11-01', '09:20:00', '17:00:00', 'Present'),
(1, '2024-11-02', '09:10:00', '17:00:00', 'Absent'),
(2, '2024-11-02', '09:00:00', '17:00:00', 'Absent'),
(1, '2024-11-03', '09:05:00', '17:00:00', 'Present'),
(2, '2024-11-03', '09:02:00', '17:00:00', 'Absent');
INSERT INTO Attendance (EmployeeID, Date, CheckInTime, CheckOutTime, Status) VALUES
(3, '2024-11-02', '09:25:00', '17:00:00', 'Present');
INSERT INTO Attendance (EmployeeID, Date, CheckInTime, CheckOutTime, Status) VALUES
(2, '2024-11-11', '09:30:00', '17:00:00', 'Present');

-- Adding additional late check-ins to Employee 1 to meet the condition of 5+ late check-ins
INSERT INTO Attendance (EmployeeID, Date, CheckInTime, CheckOutTime, Status) VALUES
(1, '2024-11-04', '09:10:00', '17:00:00', 'Present'),
(1, '2024-11-05', '09:15:00', '17:00:00', 'Present'),
(1, '2024-11-06', '09:20:00', '17:00:00', 'Present'),
(1, '2024-11-07', '09:25:00', '17:00:00', 'Present');

-- Adding additional late check-ins 
INSERT INTO Attendance (EmployeeID, Date, CheckInTime, CheckOutTime, Status) VALUES
(2, '2024-11-04', '09:10:00', '17:00:00', 'Present'),
(2, '2024-11-05', '09:30:00', '17:00:00', 'Present'),
(2, '2024-11-06', '09:20:00', '17:00:00', 'Present'),
(2, '2024-11-07', '09:35:00', '17:00:00', 'Present');

-- Adding more absences for satisfy the condition
INSERT INTO Attendance (EmployeeID, Date, CheckInTime, CheckOutTime, Status) VALUES
(2, '2024-11-08', NULL, NULL, 'Absent'),
(2, '2024-11-09', NULL, NULL, 'Absent'),
(2, '2024-11-10', NULL, NULL, 'Absent');

-- Adding entries where employees worked more than 10 hours
INSERT INTO Attendance (EmployeeID, Date, CheckInTime, CheckOutTime, Status) VALUES
(1, '2024-11-12', '08:00:00', '19:00:00', 'Present'), 
(2, '2024-11-13', '07:30:00', '18:00:00', 'Present'), 
(3, '2024-11-14', '07:45:00', '18:15:00', 'Present'); 

select * from Attendance;

-- 7. Insert data into Payroll Table
INSERT INTO Payroll (EmployeeID, BaseSalary, Bonuses, Deductions, NetPay) VALUES
(1, 50000, 5000, 2000, 48000),
(2, 60000, 7000, 2500, 57000),
(3, 55000, 6000, 1000, 54000),
(4, 45000, 3000, 1500, 42000),
(5, 40000, 2000, 1000, 38000);

-- Add more payroll entries with NetPay < 60% of BaseSalary
INSERT INTO Payroll (EmployeeID, BaseSalary, Bonuses, Deductions, NetPay) VALUES
(6, 50000, 2000, 30000, 19000),
(7, 80000, 1000, 55000, 26000); 

select * from Payroll;

