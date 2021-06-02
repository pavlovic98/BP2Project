
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/01/2021 18:37:50
-- Generated from EDMX file: C:\Users\Mladen\Desktop\Mladen Pavlovic DB project\DataBase\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DB2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PlayerPlayerPosition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlayerPositions] DROP CONSTRAINT [FK_PlayerPlayerPosition];
GO
IF OBJECT_ID(N'[dbo].[FK_PositionPlayerPosition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlayerPositions] DROP CONSTRAINT [FK_PositionPlayerPosition];
GO
IF OBJECT_ID(N'[dbo].[FK_BasketballClubBasketballClub]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BasketballClubs] DROP CONSTRAINT [FK_BasketballClubBasketballClub];
GO
IF OBJECT_ID(N'[dbo].[FK_BasketballClubLicense]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Licenses] DROP CONSTRAINT [FK_BasketballClubLicense];
GO
IF OBJECT_ID(N'[dbo].[FK_BasketballClubClubLeague]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClubLeagues] DROP CONSTRAINT [FK_BasketballClubClubLeague];
GO
IF OBJECT_ID(N'[dbo].[FK_LeagueClubLeague]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClubLeagues] DROP CONSTRAINT [FK_LeagueClubLeague];
GO
IF OBJECT_ID(N'[dbo].[FK_LeagueLicense]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Licenses] DROP CONSTRAINT [FK_LeagueLicense];
GO
IF OBJECT_ID(N'[dbo].[FK_BasketballClubPlayer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Players] DROP CONSTRAINT [FK_BasketballClubPlayer];
GO
IF OBJECT_ID(N'[dbo].[FK_EconomistArena]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_Economist] DROP CONSTRAINT [FK_EconomistArena];
GO
IF OBJECT_ID(N'[dbo].[FK_ShopSeller]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_Seller] DROP CONSTRAINT [FK_ShopSeller];
GO
IF OBJECT_ID(N'[dbo].[FK_MedicalCenterMedicalStaff]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_MedicalStaff] DROP CONSTRAINT [FK_MedicalCenterMedicalStaff];
GO
IF OBJECT_ID(N'[dbo].[FK_MatchArena]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Matches] DROP CONSTRAINT [FK_MatchArena];
GO
IF OBJECT_ID(N'[dbo].[FK_PlayerPlayerCenter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlayerCenters] DROP CONSTRAINT [FK_PlayerPlayerCenter];
GO
IF OBJECT_ID(N'[dbo].[FK_MedicalCenterPlayerCenter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlayerCenters] DROP CONSTRAINT [FK_MedicalCenterPlayerCenter];
GO
IF OBJECT_ID(N'[dbo].[FK_Economist_inherits_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_Economist] DROP CONSTRAINT [FK_Economist_inherits_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_Arena_inherits_Facility]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Facilities_Arena] DROP CONSTRAINT [FK_Arena_inherits_Facility];
GO
IF OBJECT_ID(N'[dbo].[FK_Shop_inherits_Facility]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Facilities_Shop] DROP CONSTRAINT [FK_Shop_inherits_Facility];
GO
IF OBJECT_ID(N'[dbo].[FK_Seller_inherits_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_Seller] DROP CONSTRAINT [FK_Seller_inherits_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_MedicalCenter_inherits_Facility]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Facilities_MedicalCenter] DROP CONSTRAINT [FK_MedicalCenter_inherits_Facility];
GO
IF OBJECT_ID(N'[dbo].[FK_MedicalStaff_inherits_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_MedicalStaff] DROP CONSTRAINT [FK_MedicalStaff_inherits_Employee];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BasketballClubs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BasketballClubs];
GO
IF OBJECT_ID(N'[dbo].[Licenses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Licenses];
GO
IF OBJECT_ID(N'[dbo].[Leagues]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Leagues];
GO
IF OBJECT_ID(N'[dbo].[ClubLeagues]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClubLeagues];
GO
IF OBJECT_ID(N'[dbo].[Players]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Players];
GO
IF OBJECT_ID(N'[dbo].[Positions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Positions];
GO
IF OBJECT_ID(N'[dbo].[PlayerPositions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlayerPositions];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[Facilities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Facilities];
GO
IF OBJECT_ID(N'[dbo].[Matches]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Matches];
GO
IF OBJECT_ID(N'[dbo].[PlayerCenters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlayerCenters];
GO
IF OBJECT_ID(N'[dbo].[Employees_Economist]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees_Economist];
GO
IF OBJECT_ID(N'[dbo].[Facilities_Arena]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Facilities_Arena];
GO
IF OBJECT_ID(N'[dbo].[Facilities_Shop]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Facilities_Shop];
GO
IF OBJECT_ID(N'[dbo].[Employees_Seller]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees_Seller];
GO
IF OBJECT_ID(N'[dbo].[Facilities_MedicalCenter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Facilities_MedicalCenter];
GO
IF OBJECT_ID(N'[dbo].[Employees_MedicalStaff]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees_MedicalStaff];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BasketballClubs'
CREATE TABLE [dbo].[BasketballClubs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [BasketballClubId] int  NULL
);
GO

-- Creating table 'Licenses'
CREATE TABLE [dbo].[Licenses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NameOfTeam] nvarchar(max)  NOT NULL,
    [NameOfLeague] nvarchar(max)  NOT NULL,
    [BasketballClubId] int  NULL,
    [LeagueId] int  NULL
);
GO

-- Creating table 'Leagues'
CREATE TABLE [dbo].[Leagues] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [NumberOfClubs] int  NOT NULL
);
GO

-- Creating table 'ClubLeagues'
CREATE TABLE [dbo].[ClubLeagues] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BasketballClubId] int  NOT NULL,
    [LeagueId] int  NOT NULL
);
GO

-- Creating table 'Players'
CREATE TABLE [dbo].[Players] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Age] nvarchar(max)  NOT NULL,
    [Salary] int  NOT NULL,
    [BasketballClubId] int  NULL
);
GO

-- Creating table 'Positions'
CREATE TABLE [dbo].[Positions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PlayerPositions'
CREATE TABLE [dbo].[PlayerPositions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PlayerId] int  NOT NULL,
    [PositionId] int  NOT NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Salary] int  NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [BasketballClubId] int  NOT NULL
);
GO

-- Creating table 'Facilities'
CREATE TABLE [dbo].[Facilities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [BasketballClubId] int  NOT NULL
);
GO

-- Creating table 'Matches'
CREATE TABLE [dbo].[Matches] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] nvarchar(max)  NOT NULL,
    [Guest] nvarchar(max)  NOT NULL,
    [Host] nvarchar(max)  NOT NULL,
    [Result] nvarchar(max)  NOT NULL,
    [ArenaId] int  NOT NULL
);
GO

-- Creating table 'PlayerCenters'
CREATE TABLE [dbo].[PlayerCenters] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PlayerId] int  NOT NULL,
    [MedicalCenterId] int  NOT NULL
);
GO

-- Creating table 'Employees_Economist'
CREATE TABLE [dbo].[Employees_Economist] (
    [ArenaId] int  NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Facilities_Arena'
CREATE TABLE [dbo].[Facilities_Arena] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'Facilities_Shop'
CREATE TABLE [dbo].[Facilities_Shop] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'Employees_Seller'
CREATE TABLE [dbo].[Employees_Seller] (
    [ShopId] int  NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Facilities_MedicalCenter'
CREATE TABLE [dbo].[Facilities_MedicalCenter] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'Employees_MedicalStaff'
CREATE TABLE [dbo].[Employees_MedicalStaff] (
    [MedicalCenterId] int  NULL,
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'BasketballClubs'
ALTER TABLE [dbo].[BasketballClubs]
ADD CONSTRAINT [PK_BasketballClubs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Licenses'
ALTER TABLE [dbo].[Licenses]
ADD CONSTRAINT [PK_Licenses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Leagues'
ALTER TABLE [dbo].[Leagues]
ADD CONSTRAINT [PK_Leagues]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClubLeagues'
ALTER TABLE [dbo].[ClubLeagues]
ADD CONSTRAINT [PK_ClubLeagues]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Players'
ALTER TABLE [dbo].[Players]
ADD CONSTRAINT [PK_Players]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Positions'
ALTER TABLE [dbo].[Positions]
ADD CONSTRAINT [PK_Positions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlayerPositions'
ALTER TABLE [dbo].[PlayerPositions]
ADD CONSTRAINT [PK_PlayerPositions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Facilities'
ALTER TABLE [dbo].[Facilities]
ADD CONSTRAINT [PK_Facilities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Matches'
ALTER TABLE [dbo].[Matches]
ADD CONSTRAINT [PK_Matches]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlayerCenters'
ALTER TABLE [dbo].[PlayerCenters]
ADD CONSTRAINT [PK_PlayerCenters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employees_Economist'
ALTER TABLE [dbo].[Employees_Economist]
ADD CONSTRAINT [PK_Employees_Economist]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Facilities_Arena'
ALTER TABLE [dbo].[Facilities_Arena]
ADD CONSTRAINT [PK_Facilities_Arena]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Facilities_Shop'
ALTER TABLE [dbo].[Facilities_Shop]
ADD CONSTRAINT [PK_Facilities_Shop]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employees_Seller'
ALTER TABLE [dbo].[Employees_Seller]
ADD CONSTRAINT [PK_Employees_Seller]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Facilities_MedicalCenter'
ALTER TABLE [dbo].[Facilities_MedicalCenter]
ADD CONSTRAINT [PK_Facilities_MedicalCenter]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employees_MedicalStaff'
ALTER TABLE [dbo].[Employees_MedicalStaff]
ADD CONSTRAINT [PK_Employees_MedicalStaff]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PlayerId] in table 'PlayerPositions'
ALTER TABLE [dbo].[PlayerPositions]
ADD CONSTRAINT [FK_PlayerPlayerPosition]
    FOREIGN KEY ([PlayerId])
    REFERENCES [dbo].[Players]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerPlayerPosition'
CREATE INDEX [IX_FK_PlayerPlayerPosition]
ON [dbo].[PlayerPositions]
    ([PlayerId]);
GO

-- Creating foreign key on [PositionId] in table 'PlayerPositions'
ALTER TABLE [dbo].[PlayerPositions]
ADD CONSTRAINT [FK_PositionPlayerPosition]
    FOREIGN KEY ([PositionId])
    REFERENCES [dbo].[Positions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PositionPlayerPosition'
CREATE INDEX [IX_FK_PositionPlayerPosition]
ON [dbo].[PlayerPositions]
    ([PositionId]);
GO

-- Creating foreign key on [BasketballClubId] in table 'BasketballClubs'
ALTER TABLE [dbo].[BasketballClubs]
ADD CONSTRAINT [FK_BasketballClubBasketballClub]
    FOREIGN KEY ([BasketballClubId])
    REFERENCES [dbo].[BasketballClubs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BasketballClubBasketballClub'
CREATE INDEX [IX_FK_BasketballClubBasketballClub]
ON [dbo].[BasketballClubs]
    ([BasketballClubId]);
GO

-- Creating foreign key on [BasketballClubId] in table 'Licenses'
ALTER TABLE [dbo].[Licenses]
ADD CONSTRAINT [FK_BasketballClubLicense]
    FOREIGN KEY ([BasketballClubId])
    REFERENCES [dbo].[BasketballClubs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BasketballClubLicense'
CREATE INDEX [IX_FK_BasketballClubLicense]
ON [dbo].[Licenses]
    ([BasketballClubId]);
GO

-- Creating foreign key on [BasketballClubId] in table 'ClubLeagues'
ALTER TABLE [dbo].[ClubLeagues]
ADD CONSTRAINT [FK_BasketballClubClubLeague]
    FOREIGN KEY ([BasketballClubId])
    REFERENCES [dbo].[BasketballClubs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BasketballClubClubLeague'
CREATE INDEX [IX_FK_BasketballClubClubLeague]
ON [dbo].[ClubLeagues]
    ([BasketballClubId]);
GO

-- Creating foreign key on [LeagueId] in table 'ClubLeagues'
ALTER TABLE [dbo].[ClubLeagues]
ADD CONSTRAINT [FK_LeagueClubLeague]
    FOREIGN KEY ([LeagueId])
    REFERENCES [dbo].[Leagues]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LeagueClubLeague'
CREATE INDEX [IX_FK_LeagueClubLeague]
ON [dbo].[ClubLeagues]
    ([LeagueId]);
GO

-- Creating foreign key on [LeagueId] in table 'Licenses'
ALTER TABLE [dbo].[Licenses]
ADD CONSTRAINT [FK_LeagueLicense]
    FOREIGN KEY ([LeagueId])
    REFERENCES [dbo].[Leagues]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LeagueLicense'
CREATE INDEX [IX_FK_LeagueLicense]
ON [dbo].[Licenses]
    ([LeagueId]);
GO

-- Creating foreign key on [BasketballClubId] in table 'Players'
ALTER TABLE [dbo].[Players]
ADD CONSTRAINT [FK_BasketballClubPlayer]
    FOREIGN KEY ([BasketballClubId])
    REFERENCES [dbo].[BasketballClubs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BasketballClubPlayer'
CREATE INDEX [IX_FK_BasketballClubPlayer]
ON [dbo].[Players]
    ([BasketballClubId]);
GO

-- Creating foreign key on [ArenaId] in table 'Employees_Economist'
ALTER TABLE [dbo].[Employees_Economist]
ADD CONSTRAINT [FK_EconomistArena]
    FOREIGN KEY ([ArenaId])
    REFERENCES [dbo].[Facilities_Arena]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EconomistArena'
CREATE INDEX [IX_FK_EconomistArena]
ON [dbo].[Employees_Economist]
    ([ArenaId]);
GO

-- Creating foreign key on [ShopId] in table 'Employees_Seller'
ALTER TABLE [dbo].[Employees_Seller]
ADD CONSTRAINT [FK_ShopSeller]
    FOREIGN KEY ([ShopId])
    REFERENCES [dbo].[Facilities_Shop]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShopSeller'
CREATE INDEX [IX_FK_ShopSeller]
ON [dbo].[Employees_Seller]
    ([ShopId]);
GO

-- Creating foreign key on [MedicalCenterId] in table 'Employees_MedicalStaff'
ALTER TABLE [dbo].[Employees_MedicalStaff]
ADD CONSTRAINT [FK_MedicalCenterMedicalStaff]
    FOREIGN KEY ([MedicalCenterId])
    REFERENCES [dbo].[Facilities_MedicalCenter]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MedicalCenterMedicalStaff'
CREATE INDEX [IX_FK_MedicalCenterMedicalStaff]
ON [dbo].[Employees_MedicalStaff]
    ([MedicalCenterId]);
GO

-- Creating foreign key on [ArenaId] in table 'Matches'
ALTER TABLE [dbo].[Matches]
ADD CONSTRAINT [FK_MatchArena]
    FOREIGN KEY ([ArenaId])
    REFERENCES [dbo].[Facilities_Arena]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MatchArena'
CREATE INDEX [IX_FK_MatchArena]
ON [dbo].[Matches]
    ([ArenaId]);
GO

-- Creating foreign key on [PlayerId] in table 'PlayerCenters'
ALTER TABLE [dbo].[PlayerCenters]
ADD CONSTRAINT [FK_PlayerPlayerCenter]
    FOREIGN KEY ([PlayerId])
    REFERENCES [dbo].[Players]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerPlayerCenter'
CREATE INDEX [IX_FK_PlayerPlayerCenter]
ON [dbo].[PlayerCenters]
    ([PlayerId]);
GO

-- Creating foreign key on [MedicalCenterId] in table 'PlayerCenters'
ALTER TABLE [dbo].[PlayerCenters]
ADD CONSTRAINT [FK_MedicalCenterPlayerCenter]
    FOREIGN KEY ([MedicalCenterId])
    REFERENCES [dbo].[Facilities_MedicalCenter]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MedicalCenterPlayerCenter'
CREATE INDEX [IX_FK_MedicalCenterPlayerCenter]
ON [dbo].[PlayerCenters]
    ([MedicalCenterId]);
GO

-- Creating foreign key on [BasketballClubId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_BasketballClubEmployee]
    FOREIGN KEY ([BasketballClubId])
    REFERENCES [dbo].[BasketballClubs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BasketballClubEmployee'
CREATE INDEX [IX_FK_BasketballClubEmployee]
ON [dbo].[Employees]
    ([BasketballClubId]);
GO

-- Creating foreign key on [BasketballClubId] in table 'Facilities'
ALTER TABLE [dbo].[Facilities]
ADD CONSTRAINT [FK_BasketballClubFacility]
    FOREIGN KEY ([BasketballClubId])
    REFERENCES [dbo].[BasketballClubs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BasketballClubFacility'
CREATE INDEX [IX_FK_BasketballClubFacility]
ON [dbo].[Facilities]
    ([BasketballClubId]);
GO

-- Creating foreign key on [Id] in table 'Employees_Economist'
ALTER TABLE [dbo].[Employees_Economist]
ADD CONSTRAINT [FK_Economist_inherits_Employee]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Facilities_Arena'
ALTER TABLE [dbo].[Facilities_Arena]
ADD CONSTRAINT [FK_Arena_inherits_Facility]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Facilities]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Facilities_Shop'
ALTER TABLE [dbo].[Facilities_Shop]
ADD CONSTRAINT [FK_Shop_inherits_Facility]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Facilities]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Employees_Seller'
ALTER TABLE [dbo].[Employees_Seller]
ADD CONSTRAINT [FK_Seller_inherits_Employee]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Facilities_MedicalCenter'
ALTER TABLE [dbo].[Facilities_MedicalCenter]
ADD CONSTRAINT [FK_MedicalCenter_inherits_Facility]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Facilities]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Employees_MedicalStaff'
ALTER TABLE [dbo].[Employees_MedicalStaff]
ADD CONSTRAINT [FK_MedicalStaff_inherits_Employee]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------