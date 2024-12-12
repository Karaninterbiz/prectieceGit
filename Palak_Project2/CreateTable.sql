create database Project_2;
use Project_2;
-- Create Employee Table
CREATE TABLE Employee (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT,
    RoleID INT,
    HireDate DATE
);

-- Create Department Table
CREATE TABLE Department (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

-- Create Role Table
CREATE TABLE Role (
    RoleID INT PRIMARY KEY,
    RoleName VARCHAR(100)
);

-- Create Project Table
CREATE TABLE Project (
    ProjectID INT PRIMARY KEY,
    ProjectName VARCHAR(100),
    Status VARCHAR(50),
    StartDate DATE
);

-- Create EmployeeProject Table
CREATE TABLE EmployeeProject (
    EmployeeID INT,
    ProjectID INT,
    RoleInProject VARCHAR(100),
    PRIMARY KEY (EmployeeID, ProjectID),
    FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID),
    FOREIGN KEY (ProjectID) REFERENCES Project(ProjectID)
);

-- Create Attendance Table
CREATE TABLE Attendance (
    EmployeeID INT,
    Date DATE,
    CheckInTime TIME,
    CheckOutTime TIME,
    Status VARCHAR(50),
    PRIMARY KEY (EmployeeID, Date),
    FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID)
);

-- Create Payroll Table
CREATE TABLE Payroll (
    EmployeeID INT,
    BaseSalary DECIMAL(10, 2),
    Bonuses DECIMAL(10, 2),
    Deductions DECIMAL(10, 2),
    NetPay DECIMAL(10, 2),
    PRIMARY KEY (EmployeeID),
    FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID)
);
