-- UNITY SACCO SQL Server setup for Assignment 7
-- Run this script in SQL Server Management Studio before testing the UWP application.

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

-- Seed staff login accounts for each user role.
-- Password hashes below are SHA-256 hashes of the exact passwords shown in the comments.
-- They match the UTF-8 SHA-256 hashing used by DatabaseService.cs.

IF NOT EXISTS (SELECT 1 FROM dbo.Staff WHERE Email = N'manager@unitysacco.ug')
BEGIN
    INSERT INTO dbo.Staff (FullName, Email, PasswordHash, Role, IsActive)
    VALUES
    (
        N'Grace Namusoke',
        N'manager@unitysacco.ug',
        0xE8392925A98C9C22795D1FC5D0DFEE5B9A6943F6B768EC5A2A0C077E5ED119CF,
        N'Manager',
        1
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Staff WHERE Email = N'members@unitysacco.ug')
BEGIN
    INSERT INTO dbo.Staff (FullName, Email, PasswordHash, Role, IsActive)
    VALUES
    (
        N'Daniel Okello',
        N'members@unitysacco.ug',
        0xC64455E1914C956B173F80DE55A9AE59716BFEB785E4AD3719E5EC469E5A8A49,
        N'Member Services Officer',
        1
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Staff WHERE Email = N'loans@unitysacco.ug')
BEGIN
    INSERT INTO dbo.Staff (FullName, Email, PasswordHash, Role, IsActive)
    VALUES
    (
        N'Sarah Achieng',
        N'loans@unitysacco.ug',
        0x7D2585B1D1ABDA024688964B5B8579BA4B26C22E005CBD126CAD93199158B9D4,
        N'Loan Officer',
        1
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Staff WHERE Email = N'accountant@unitysacco.ug')
BEGIN
    INSERT INTO dbo.Staff (FullName, Email, PasswordHash, Role, IsActive)
    VALUES
    (
        N'Peter Mugisha',
        N'accountant@unitysacco.ug',
        0x934975BF2A884E397D6E3F50DED9D96221B82EC6AF04565A5917FF74B8347C2C,
        N'Accountant',
        1
    );
END
GO

-- Test credentials:
-- Manager:                 manager@unitysacco.ug    / Manager@123
-- Member Services Officer: members@unitysacco.ug    / Members@123
-- Loan Officer:            loans@unitysacco.ug      / Loans@123
-- Accountant:              accountant@unitysacco.ug / Accounts@123
