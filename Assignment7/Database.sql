-- UNITY SACCO SQL Server setup for Assignment 7
-- Run in SQL Server Management Studio before testing the UWP application.

IF DB_ID(N'SaccoDB') IS NULL
BEGIN
    CREATE DATABASE SaccoDB;
END
GO

USE SaccoDB;
GO

IF OBJECT_ID(N'dbo.Staff', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Staff
    (
        StaffId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        FullName NVARCHAR(120) NOT NULL,
        Email NVARCHAR(150) NOT NULL UNIQUE,
        PasswordHash VARBINARY(32) NOT NULL,
        Role NVARCHAR(60) NOT NULL,
        IsActive BIT NOT NULL CONSTRAINT DF_Staff_IsActive DEFAULT (1)
    );
END
GO

-- Add your own staff records here. PasswordHash must contain a SHA-256 hash
-- of the password entered on the Login Page.
