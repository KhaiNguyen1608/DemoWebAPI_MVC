create database CRUDDB
use CRUDDB

CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](50) NULL,
	[Position] [nvarchar](50) NULL,
	[Age] [int] NULL,
	[Salary] [int] NULL)


create table City
(
	[CityID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	CityName nvarchar(50) null
)
create table District
(
	[DistrictID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	DistrictName nvarchar(50) null
)
create table Ward
(
	[WardID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	WardName int null
)

insert into City(CityName) values(N'Hồ Chí Minh')
insert into City(CityName) values(N'Đã Nẵng')
insert into City(CityName) values(N'Thanh Hóa')
insert into City(CityName) values(N'Hà Nội')
insert into City(CityName) values(N'Đà Lạt')

insert into District(DistrictName) values(N'Gò Vấp')
insert into District(DistrictName) values(N'Bình Thạnh')

insert into Ward(WardName) values(16)
insert into Ward(WardName) values(17)