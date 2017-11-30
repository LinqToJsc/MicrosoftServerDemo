
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/30/2017 15:27:43
-- Generated from EDMX file: D:\CONDING\MicrosoftServerDemo\MicrosoftServerDemos\TDF.JK.WebAdmin\Repository\ImageModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Face];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserInfoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfoSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserInfoSet'
CREATE TABLE [dbo].[UserInfoSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Age] nvarchar(max)  NOT NULL,
    [Gender] nvarchar(max)  NOT NULL,
    [Education] nvarchar(max)  NOT NULL,
    [NativePlace] nvarchar(max)  NOT NULL,
    [Nation] nvarchar(max)  NOT NULL,
    [Identification] nvarchar(max)  NOT NULL,
    [Height] nvarchar(max)  NOT NULL,
    [Weight] nvarchar(max)  NOT NULL,
    [Avocation] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [Marital] nvarchar(max)  NOT NULL,
    [Interest] nvarchar(max)  NOT NULL,
    [LearningExperience] nvarchar(max)  NOT NULL,
    [workExperience] nvarchar(max)  NOT NULL,
    [SelfEvaluation] nvarchar(max)  NOT NULL,
    [ImgSrc] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserInfoSet'
ALTER TABLE [dbo].[UserInfoSet]
ADD CONSTRAINT [PK_UserInfoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------