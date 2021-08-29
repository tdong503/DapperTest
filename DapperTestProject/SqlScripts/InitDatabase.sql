use master;

create database DapperDB;
create database DapperDBTest;
use DapperDB;
create table dbo.Employee
(
    [Id]           [uniqueidentifier] ROWGUIDCOL NOT NULL UNIQUE,
    [Name]         VARCHAR(200) UNIQUE,
    [Email]        VARCHAR(200)                  NULL,
    [DepartmentId] INTEGER                       NOT NULL,
)

create table dbo.Department
(
    [Id]           [uniqueidentifier] ROWGUIDCOL NOT NULL UNIQUE,
    [Name]         VARCHAR(200) UNIQUE,
)

use DapperDBTest;

create table dbo.Employee
(
    [Id]    [uniqueidentifier] ROWGUIDCOL NOT NULL UNIQUE,
    [Name]  VARCHAR(200) UNIQUE,
    [Email] VARCHAR(200)                  NULL,
    [DepartmentId] INTEGER NOT NULL,
)

create table dbo.Department
(
    [Id]           [uniqueidentifier] ROWGUIDCOL NOT NULL UNIQUE,
    [Name]         VARCHAR(200) UNIQUE,
)