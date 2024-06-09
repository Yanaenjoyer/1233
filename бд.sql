/*
Created: 20.05.2024
Modified: 26.05.2024
Model: 1 logmodel
Database: MS SQL Server 2019
*/


-- Create tables section -------------------------------------------------

-- Table User

CREATE TABLE [User]
(
 [Employee_ID] Nvarchar(20) NOT NULL,
 [User_ID] Nvarchar(20) NOT NULL,
 [Role] Nvarchar(15) NOT NULL
)
go

-- Add keys for table User

ALTER TABLE [User] ADD CONSTRAINT [Unique_Identifier1] PRIMARY KEY ([Employee_ID],[User_ID])
go

-- Table Computer_Facilities

CREATE TABLE [Computer_Facilities]
(
 [Serial_number] Nvarchar(20) NOT NULL,
 [Inventory_number] Nvarchar(20) NOT NULL,
 [Employee_ID] Nvarchar(20) NOT NULL,
 [Type] Nvarchar(30) NOT NULL,
 [Description] Nvarchar(max) NOT NULL
)
go

-- Add keys for table Computer_Facilities

ALTER TABLE [Computer_Facilities] ADD CONSTRAINT [Unique_Identifier2] PRIMARY KEY ([Serial_number],[Inventory_number],[Employee_ID])
go

-- Table Buildings

CREATE TABLE [Buildings]
(
 [Building_number] Nvarchar(20) NOT NULL,
 [Home] Nvarchar(30) NOT NULL,
 [Street] Nvarchar(30) NOT NULL,
 [City] Nvarchar(30) NOT NULL
)
go

-- Add keys for table Buildings

ALTER TABLE [Buildings] ADD CONSTRAINT [Unique_Identifier4] PRIMARY KEY ([Building_number])
go

-- Table Employees

CREATE TABLE [Employees]
(
 [Employee_ID] Nvarchar(20) NOT NULL,
 [First_name] Nvarchar(30) NOT NULL,
 [Last_name] Nvarchar(30) NOT NULL,
 [Patronymic] Nvarchar(30) NOT NULL,
 [Phone] Nvarchar(11) NOT NULL,
 [Home] Nvarchar(30) NOT NULL,
 [Street] Nvarchar(30) NOT NULL,
 [City] Nvarchar(30) NOT NULL
)
go

-- Add keys for table Employees

ALTER TABLE [Employees] ADD CONSTRAINT [Unique_Identifier5] PRIMARY KEY ([Employee_ID])
go

-- Table Orders

CREATE TABLE [Orders]
(
 [Employee_ID] Nvarchar(20) NOT NULL,
 [User_ID] Nvarchar(20) NOT NULL,
 [Order_ID] Nvarchar(20) NOT NULL,
 [Type] Nvarchar(30) NOT NULL,
 [Quantity] Int NOT NULL,
 [Description] Nvarchar(max) NULL
)
go

-- Add keys for table Orders

ALTER TABLE [Orders] ADD CONSTRAINT [Unique_Identifier8] PRIMARY KEY ([Employee_ID],[User_ID],[Order_ID])
go

-- Table Equipment_Transfer

CREATE TABLE [Equipment_Transfer]
(
 [Department_ID] Nvarchar(20) NOT NULL,
 [Serial_number] Nvarchar(20) NOT NULL,
 [Inventory_number] Nvarchar(20) NOT NULL,
 [Building_number] Nvarchar(20) NOT NULL,
 [Employee_ID] Nvarchar(20) NOT NULL
)
go

-- Add keys for table Equipment_Transfer

ALTER TABLE [Equipment_Transfer] ADD CONSTRAINT [Unique_Identifier9] PRIMARY KEY ([Department_ID],[Serial_number],[Inventory_number],[Building_number],[Employee_ID])
go

-- Table Repair_requests

CREATE TABLE [Repair_requests]
(
 [Employee_ID] Nvarchar(20) NOT NULL,
 [User_ID] Nvarchar(20) NOT NULL,
 [Repair_ID] Nvarchar(20) NOT NULL,
 [Description] Nvarchar(max) NOT NULL
)
go

-- Add keys for table Repair_requests

ALTER TABLE [Repair_requests] ADD CONSTRAINT [Unique_Identifier11] PRIMARY KEY ([Employee_ID],[User_ID],[Repair_ID])
go

-- Table Department

CREATE TABLE [Department]
(
 [Department_ID] Nvarchar(20) NOT NULL,
 [Building_number] Nvarchar(20) NOT NULL,
 [Person_number] Int NOT NULL,
 [Seats_number] Int NOT NULL
)
go

-- Add keys for table Department

ALTER TABLE [Department] ADD CONSTRAINT [Unique_Identifier12] PRIMARY KEY ([Department_ID],[Building_number])
go

-- Table Employees_Department

CREATE TABLE [Employees_Department]
(
 [Department_ID] Nvarchar(20) NOT NULL,
 [Employee_ID] Nvarchar(20) NOT NULL,
 [Building_number] Nvarchar(20) NOT NULL
)
go

-- Table User_Repair_requests

CREATE TABLE [User_Repair_requests]
(
 [Employee_ID] Nvarchar(20) NOT NULL,
 [User_ID] Nvarchar(20) NOT NULL
)
go

-- Add keys for table User_Repair_requests

ALTER TABLE [User_Repair_requests] ADD CONSTRAINT [PK_User_Repair_requests] PRIMARY KEY ([Employee_ID],[User_ID])
go

-- Create foreign keys (relationships) section ------------------------------------------------- 


ALTER TABLE [User] ADD CONSTRAINT [Является] FOREIGN KEY ([Employee_ID]) REFERENCES [Employees] ([Employee_ID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Department] ADD CONSTRAINT [Относится/Включает] FOREIGN KEY ([Building_number]) REFERENCES [Buildings] ([Building_number]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Equipment_Transfer] ADD CONSTRAINT [Передается] FOREIGN KEY ([Serial_number], [Inventory_number], [Employee_ID]) REFERENCES [Computer_Facilities] ([Serial_number], [Inventory_number], [Employee_ID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Equipment_Transfer] ADD CONSTRAINT [Передается_] FOREIGN KEY ([Department_ID], [Building_number]) REFERENCES [Department] ([Department_ID], [Building_number]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [User_Repair_requests] ADD CONSTRAINT [Создает] FOREIGN KEY ([Employee_ID], [User_ID]) REFERENCES [User] ([Employee_ID], [User_ID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Repair_requests] ADD CONSTRAINT [Relationship8] FOREIGN KEY ([Employee_ID], [User_ID]) REFERENCES [User_Repair_requests] ([Employee_ID], [User_ID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Orders] ADD CONSTRAINT [Заказывает] FOREIGN KEY ([Employee_ID], [User_ID]) REFERENCES [User] ([Employee_ID], [User_ID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Computer_Facilities] ADD CONSTRAINT [Принадлежит] FOREIGN KEY ([Employee_ID]) REFERENCES [Employees] ([Employee_ID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go




