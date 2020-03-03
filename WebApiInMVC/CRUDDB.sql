create database CRUDDB
use CRUDDB

CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](50) NULL,
	[Position] [nvarchar](50) NULL,
	[Age] [int] NULL,
	[Salary] [int] NULL)

select * from Employee