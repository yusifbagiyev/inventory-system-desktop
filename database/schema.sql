-- Inventory System - SQL Server schema (reconstructed from the tables the application uses).
-- Create an empty database first, e.g.:  CREATE DATABASE InventoryDb;  then run this script in it.

CREATE TABLE dbo.Category (
    catId    INT IDENTITY(1,1) PRIMARY KEY,
    catname  NVARCHAR(100) NOT NULL
);

CREATE TABLE dbo.Department (
    depID    INT IDENTITY(1,1) PRIMARY KEY,
    dname    NVARCHAR(100) NOT NULL,
    dhead    NVARCHAR(100) NULL,
    dcontact NVARCHAR(100) NULL,
    ddesc    NVARCHAR(600) NULL
);

-- Products are linked to their category and department by name (as in the original design).
CREATE TABLE dbo.Product (
    ID           INT IDENTITY(1,1) PRIMARY KEY,
    prodCode     NVARCHAR(100) NOT NULL,   -- inventory code printed on the label
    pcategory    NVARCHAR(100) NULL,
    pvendor      NVARCHAR(100) NULL,
    pmodel       NVARCHAR(100) NULL,
    pdepartment  NVARCHAR(100) NULL,
    pworker      NVARCHAR(100) NULL,
    pdescription NVARCHAR(600) NULL
);

-- Every move of a product between departments / workers (the product's history).
CREATE TABLE dbo.Route (
    RouteId     INT IDENTITY(1,1) PRIMARY KEY,
    prodCode    NVARCHAR(100) NOT NULL,
    FrmDep      NVARCHAR(100) NULL,
    FrmWorker   NVARCHAR(100) NULL,
    ToDep       NVARCHAR(100) NULL,
    ToWorker    NVARCHAR(100) NULL,
    [Date]      NVARCHAR(100) NULL,        -- dd.MM.yyyy
    Description NVARCHAR(600) NULL
);

CREATE TABLE dbo.Users (
    ID         INT IDENTITY(1,1) PRIMARY KEY,
    fullname   NVARCHAR(100) NOT NULL,
    [password] NVARCHAR(256) NOT NULL,     -- AES-encrypted (key: PasswordKey in App.config)
    [type]     NVARCHAR(20)  NOT NULL,     -- Admin | User
    online     NVARCHAR(20)  NULL,         -- online | offline
    suspended  NVARCHAR(20)  NULL,         -- enabled | disabled
    [session]  NVARCHAR(100) NULL,         -- machine name of the active session
    ip_address NVARCHAR(50)  NULL,
    [language] NVARCHAR(20)  NULL          -- English | Russian
);

CREATE TABLE dbo.[Log] (
    ID       INT IDENTITY(1,1) PRIMARY KEY,
    [Time]   NVARCHAR(50)   NULL,
    Logs     NVARCHAR(MAX)  NULL,
    fullname NVARCHAR(100)  NULL
);
