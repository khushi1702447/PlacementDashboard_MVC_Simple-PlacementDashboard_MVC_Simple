IF DB_ID('PlacementDB') IS NULL CREATE DATABASE PlacementDB;
GO
USE PlacementDB;
GO
IF OBJECT_ID('dbo.PlacementRecords','U') IS NOT NULL DROP TABLE dbo.PlacementRecords;
IF OBJECT_ID('dbo.Students','U') IS NOT NULL DROP TABLE dbo.Students;
GO
CREATE TABLE dbo.Students (
 StudentID INT IDENTITY(1,1) PRIMARY KEY,
 EnrollmentNo NVARCHAR(30) NOT NULL UNIQUE,
 StudentName NVARCHAR(100) NOT NULL,
 Department NVARCHAR(80) NOT NULL,
 GraduationYear INT NOT NULL,
 Email NVARCHAR(150) NULL,
 CGPA DECIMAL(4,2) NOT NULL
);
CREATE TABLE dbo.PlacementRecords (
 PlacementID INT IDENTITY(1,1) PRIMARY KEY,
 StudentID INT NOT NULL FOREIGN KEY REFERENCES dbo.Students(StudentID),
 CompanyName NVARCHAR(120) NOT NULL,
 JobRole NVARCHAR(120) NOT NULL,
 PackageLPA DECIMAL(8,2) NOT NULL,
 PlacementStatus NVARCHAR(20) NOT NULL CHECK (PlacementStatus IN ('Placed','Interview','Not Placed')),
 OfferDate DATE NULL
);
GO
INSERT INTO dbo.Students (EnrollmentNo,StudentName,Department,GraduationYear,Email,CGPA) VALUES
('MUCE24001','Aarav Shah','Computer Engineering',2027,'aarav@example.com',8.60),
('MUCE24002','Diya Patel','Information Technology',2027,'diya@example.com',9.10),
('MUCE24003','Rohan Mehta','Computer Engineering',2027,'rohan@example.com',7.80),
('MUCE24004','Anaya Joshi','Electronics Engineering',2027,'anaya@example.com',8.20);
INSERT INTO dbo.PlacementRecords (StudentID,CompanyName,JobRole,PackageLPA,PlacementStatus,OfferDate) VALUES
(1,'TechNova','Software Engineer',8.50,'Placed','2026-08-12'),
(2,'CloudBridge','Data Analyst',10.00,'Placed','2026-08-18'),
(3,'TechNova','Graduate Engineer Trainee',6.00,'Interview',NULL),
(4,'CircuitWorks','Embedded Engineer',5.50,'Placed','2026-09-02');
GO
