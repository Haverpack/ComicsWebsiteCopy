/*
Deployment script for LocalComicsDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "LocalComicsDB"
:setvar DefaultFilePrefix "LocalComicsDB"
:setvar DefaultDataPath "C:\Users\Fady\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\Fady\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating database $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Creating Table [dbo].[Admin]...';


GO
CREATE TABLE [dbo].[Admin] (
    [adminID]  INT           IDENTITY (1, 1) NOT NULL,
    [password] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([adminID] ASC)
);


GO
PRINT N'Creating Table [dbo].[Author]...';


GO
CREATE TABLE [dbo].[Author] (
    [userID] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([userID] ASC)
);


GO
PRINT N'Creating Table [dbo].[Catalog]...';


GO
CREATE TABLE [dbo].[Catalog] (
    [title]    NVARCHAR (MAX) NOT NULL,
    [commName] NVARCHAR (MAX) NULL,
    [creator]  NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([title] ASC)
);


GO
PRINT N'Creating Table [dbo].[Catalog_Tag]...';


GO
CREATE TABLE [dbo].[Catalog_Tag] (
    [catalogTitle] NVARCHAR (MAX) NOT NULL,
    [Tag]          NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([catalogTitle] ASC, [Tag] ASC)
);


GO
PRINT N'Creating Table [dbo].[Chapter]...';


GO
CREATE TABLE [dbo].[Chapter] (
    [chapterNum] INT            NOT NULL,
    [comicTitle] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([chapterNum] ASC)
);


GO
PRINT N'Creating Table [dbo].[Collection_Of]...';


GO
CREATE TABLE [dbo].[Collection_Of] (
    [catalogTitle] NVARCHAR (MAX) NOT NULL,
    [comicTitle]   NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([catalogTitle] ASC, [comicTitle] ASC)
);


GO
PRINT N'Creating Table [dbo].[Comic]...';


GO
CREATE TABLE [dbo].[Comic] (
    [title]  NVARCHAR (MAX) NOT NULL,
    [pages]  NVARCHAR (MAX) NOT NULL,
    [author] NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([title] ASC)
);


GO
PRINT N'Creating Table [dbo].[Comic_Tag]...';


GO
CREATE TABLE [dbo].[Comic_Tag] (
    [comicTitle] NVARCHAR (MAX) NOT NULL,
    [Tag]        NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([comicTitle] ASC, [Tag] ASC)
);


GO
PRINT N'Creating Table [dbo].[Comment]...';


GO
CREATE TABLE [dbo].[Comment] (
    [commentNum] INT           NOT NULL,
    [writer]     NVARCHAR (50) NOT NULL,
    [chapterNum] INT           NOT NULL,
    [timeStamp]  DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([commentNum] ASC, [writer] ASC, [chapterNum] ASC)
);


GO
PRINT N'Creating Table [dbo].[Community]...';


GO
CREATE TABLE [dbo].[Community] (
    [name] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([name] ASC)
);


GO
PRINT N'Creating Table [dbo].[FComment]...';


GO
CREATE TABLE [dbo].[FComment] (
    [commentNum] INT            NOT NULL,
    [forumTitle] NVARCHAR (MAX) NOT NULL,
    [writer]     NVARCHAR (50)  NOT NULL,
    [timeStamp]  DATETIME       NOT NULL,
    [commName]   NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([commentNum] ASC, [forumTitle] ASC, [writer] ASC, [commName] ASC)
);


GO
PRINT N'Creating Table [dbo].[Forum]...';


GO
CREATE TABLE [dbo].[Forum] (
    [title]     NVARCHAR (MAX) NOT NULL,
    [community] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([title] ASC, [community] ASC)
);


GO
PRINT N'Creating Table [dbo].[Member_Of]...';


GO
CREATE TABLE [dbo].[Member_Of] (
    [commName] NVARCHAR (MAX) NOT NULL,
    [userID]   NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([commName] ASC, [userID] ASC)
);


GO
PRINT N'Creating Table [dbo].[Moderates]...';


GO
CREATE TABLE [dbo].[Moderates] (
    [commName] NVARCHAR (MAX) NOT NULL,
    [userID]   NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([commName] ASC, [userID] ASC)
);


GO
PRINT N'Creating Table [dbo].[Report]...';


GO
CREATE TABLE [dbo].[Report] (
    [reportNum]      INT            IDENTITY (1, 1) NOT NULL,
    [creator]        NVARCHAR (50)  NOT NULL,
    [offendingUser]  NVARCHAR (50)  NULL,
    [offendingComic] NVARCHAR (MAX) NULL,
    [infraction]     NVARCHAR (MAX) NOT NULL,
    [timeStamp]      DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([reportNum] ASC, [infraction] ASC, [creator] ASC)
);


GO
PRINT N'Creating Table [dbo].[Reviews]...';


GO
CREATE TABLE [dbo].[Reviews] (
    [reportNum]      INT            NOT NULL,
    [adminID]        INT            NOT NULL,
    [creator]        NVARCHAR (50)  NOT NULL,
    [offendingUser]  NVARCHAR (50)  NULL,
    [offendingComic] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([reportNum] ASC, [creator] ASC, [adminID] ASC)
);


GO
PRINT N'Creating Table [dbo].[Subscribes]...';


GO
CREATE TABLE [dbo].[Subscribes] (
    [comicTitle] NVARCHAR (MAX) NOT NULL,
    [userID]     NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([comicTitle] ASC, [userID] ASC)
);


GO
PRINT N'Creating Table [dbo].[User]...';


GO
CREATE TABLE [dbo].[User] (
    [userID]   NVARCHAR (50) NOT NULL,
    [email]    NVARCHAR (50) NOT NULL,
    [password] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([userID] ASC)
);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Author_User]...';


GO
ALTER TABLE [dbo].[Author]
    ADD CONSTRAINT [FK_Author_User] FOREIGN KEY ([userID]) REFERENCES [dbo].[User] ([userID]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Catalog_Community]...';


GO
ALTER TABLE [dbo].[Catalog]
    ADD CONSTRAINT [FK_Catalog_Community] FOREIGN KEY ([commName]) REFERENCES [dbo].[Community] ([name]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Catalog_User]...';


GO
ALTER TABLE [dbo].[Catalog]
    ADD CONSTRAINT [FK_Catalog_User] FOREIGN KEY ([creator]) REFERENCES [dbo].[User] ([userID]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Catalog_Tag_Catalog]...';


GO
ALTER TABLE [dbo].[Catalog_Tag]
    ADD CONSTRAINT [FK_Catalog_Tag_Catalog] FOREIGN KEY ([catalogTitle]) REFERENCES [dbo].[Catalog] ([title]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Chapter_Comic]...';


GO
ALTER TABLE [dbo].[Chapter]
    ADD CONSTRAINT [FK_Chapter_Comic] FOREIGN KEY ([comicTitle]) REFERENCES [dbo].[Comic] ([title]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Collection_Of_Comic]...';


GO
ALTER TABLE [dbo].[Collection_Of]
    ADD CONSTRAINT [FK_Collection_Of_Comic] FOREIGN KEY ([comicTitle]) REFERENCES [dbo].[Comic] ([title]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Collection_Of_Catalog]...';


GO
ALTER TABLE [dbo].[Collection_Of]
    ADD CONSTRAINT [FK_Collection_Of_Catalog] FOREIGN KEY ([catalogTitle]) REFERENCES [dbo].[Catalog] ([title]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Comic_Author]...';


GO
ALTER TABLE [dbo].[Comic]
    ADD CONSTRAINT [FK_Comic_Author] FOREIGN KEY ([author]) REFERENCES [dbo].[Author] ([userID]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Comic_Tag_Comic]...';


GO
ALTER TABLE [dbo].[Comic_Tag]
    ADD CONSTRAINT [FK_Comic_Tag_Comic] FOREIGN KEY ([comicTitle]) REFERENCES [dbo].[Comic] ([title]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Comment_User]...';


GO
ALTER TABLE [dbo].[Comment]
    ADD CONSTRAINT [FK_Comment_User] FOREIGN KEY ([writer]) REFERENCES [dbo].[User] ([userID]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Comment_Chapter]...';


GO
ALTER TABLE [dbo].[Comment]
    ADD CONSTRAINT [FK_Comment_Chapter] FOREIGN KEY ([chapterNum]) REFERENCES [dbo].[Chapter] ([chapterNum]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_FComment_Forum]...';


GO
ALTER TABLE [dbo].[FComment]
    ADD CONSTRAINT [FK_FComment_Forum] FOREIGN KEY ([forumTitle], [commName]) REFERENCES [dbo].[Forum] ([title], [community]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_FComment_User]...';


GO
ALTER TABLE [dbo].[FComment]
    ADD CONSTRAINT [FK_FComment_User] FOREIGN KEY ([writer]) REFERENCES [dbo].[User] ([userID]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Forum_Community]...';


GO
ALTER TABLE [dbo].[Forum]
    ADD CONSTRAINT [FK_Forum_Community] FOREIGN KEY ([community]) REFERENCES [dbo].[Community] ([name]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Member_Of_Community]...';


GO
ALTER TABLE [dbo].[Member_Of]
    ADD CONSTRAINT [FK_Member_Of_Community] FOREIGN KEY ([commName]) REFERENCES [dbo].[Community] ([name]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Member_Of_User]...';


GO
ALTER TABLE [dbo].[Member_Of]
    ADD CONSTRAINT [FK_Member_Of_User] FOREIGN KEY ([userID]) REFERENCES [dbo].[User] ([userID]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Moderates_Community]...';


GO
ALTER TABLE [dbo].[Moderates]
    ADD CONSTRAINT [FK_Moderates_Community] FOREIGN KEY ([commName]) REFERENCES [dbo].[Community] ([name]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Moderates_User]...';


GO
ALTER TABLE [dbo].[Moderates]
    ADD CONSTRAINT [FK_Moderates_User] FOREIGN KEY ([userID]) REFERENCES [dbo].[User] ([userID]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Report_User]...';


GO
ALTER TABLE [dbo].[Report]
    ADD CONSTRAINT [FK_Report_User] FOREIGN KEY ([creator]) REFERENCES [dbo].[User] ([userID]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Report_User1]...';


GO
ALTER TABLE [dbo].[Report]
    ADD CONSTRAINT [FK_Report_User1] FOREIGN KEY ([offendingUser]) REFERENCES [dbo].[User] ([userID]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Report_Comic]...';


GO
ALTER TABLE [dbo].[Report]
    ADD CONSTRAINT [FK_Report_Comic] FOREIGN KEY ([offendingComic]) REFERENCES [dbo].[Comic] ([title]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Reviews_Admin]...';


GO
ALTER TABLE [dbo].[Reviews]
    ADD CONSTRAINT [FK_Reviews_Admin] FOREIGN KEY ([adminID]) REFERENCES [dbo].[Admin] ([adminID]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Reviews_User]...';


GO
ALTER TABLE [dbo].[Reviews]
    ADD CONSTRAINT [FK_Reviews_User] FOREIGN KEY ([creator]) REFERENCES [dbo].[User] ([userID]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Reviews_User1]...';


GO
ALTER TABLE [dbo].[Reviews]
    ADD CONSTRAINT [FK_Reviews_User1] FOREIGN KEY ([offendingUser]) REFERENCES [dbo].[User] ([userID]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Reviews_Comic]...';


GO
ALTER TABLE [dbo].[Reviews]
    ADD CONSTRAINT [FK_Reviews_Comic] FOREIGN KEY ([offendingComic]) REFERENCES [dbo].[Comic] ([title]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Subscribes_Comic]...';


GO
ALTER TABLE [dbo].[Subscribes]
    ADD CONSTRAINT [FK_Subscribes_Comic] FOREIGN KEY ([comicTitle]) REFERENCES [dbo].[Comic] ([title]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Subscribes_User]...';


GO
ALTER TABLE [dbo].[Subscribes]
    ADD CONSTRAINT [FK_Subscribes_User] FOREIGN KEY ([userID]) REFERENCES [dbo].[User] ([userID]);


GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '39a845e1-7d55-4534-a5ab-9304fb367455')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('39a845e1-7d55-4534-a5ab-9304fb367455')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '7be2bbf9-933b-42e9-8884-7030289c227e')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('7be2bbf9-933b-42e9-8884-7030289c227e')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '4533a49e-6799-4efd-aa8c-c7b110c2985c')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('4533a49e-6799-4efd-aa8c-c7b110c2985c')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'b800c976-740b-4733-93b7-4f4322cca13d')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('b800c976-740b-4733-93b7-4f4322cca13d')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '5ea4f980-b5fb-4d36-af26-97f0841e6f35')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('5ea4f980-b5fb-4d36-af26-97f0841e6f35')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '0bfbec0c-9328-49e1-8c14-41469d3dadb3')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('0bfbec0c-9328-49e1-8c14-41469d3dadb3')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '38ecddd4-193b-45cb-9a8c-9412fe4fb6bc')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('38ecddd4-193b-45cb-9a8c-9412fe4fb6bc')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '23e48c79-270f-499b-a2c2-4e2ba71dab6c')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('23e48c79-270f-499b-a2c2-4e2ba71dab6c')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'bf9edcdd-1014-454c-84c7-a352c20b0867')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('bf9edcdd-1014-454c-84c7-a352c20b0867')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '40375e0b-8cf5-4ab9-bb39-62a3ffb48f5c')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('40375e0b-8cf5-4ab9-bb39-62a3ffb48f5c')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '264be8a9-0e59-42a6-bfd5-cfc4c198c330')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('264be8a9-0e59-42a6-bfd5-cfc4c198c330')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '257d703d-1812-45b6-bc01-f06efeb64e23')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('257d703d-1812-45b6-bc01-f06efeb64e23')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '7249adcb-4b0f-4903-99bb-bed900d17574')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('7249adcb-4b0f-4903-99bb-bed900d17574')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'e09407db-fee9-40ff-8eba-ba012cee439b')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('e09407db-fee9-40ff-8eba-ba012cee439b')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '015e1701-961b-4063-8325-deb496ae266d')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('015e1701-961b-4063-8325-deb496ae266d')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'd56b21c6-5073-4224-b612-927eba335a8e')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('d56b21c6-5073-4224-b612-927eba335a8e')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'ebb970eb-cbff-41d7-b040-0153ac6d172e')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('ebb970eb-cbff-41d7-b040-0153ac6d172e')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '13a0bc5d-d872-495e-bc08-44d1f8e049ce')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('13a0bc5d-d872-495e-bc08-44d1f8e049ce')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '13f46c5d-2ad1-4b16-9f8f-ce7ed8f1a26e')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('13f46c5d-2ad1-4b16-9f8f-ce7ed8f1a26e')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '97e76e1f-b73a-4372-b95f-e28913db3baf')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('97e76e1f-b73a-4372-b95f-e28913db3baf')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '9a9636ca-a71e-491f-8fe5-68d39dbb184f')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('9a9636ca-a71e-491f-8fe5-68d39dbb184f')

GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO
