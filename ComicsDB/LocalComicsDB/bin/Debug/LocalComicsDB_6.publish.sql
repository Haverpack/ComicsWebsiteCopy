﻿/*
Deployment script for ComicsDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ComicsDB"
:setvar DefaultFilePrefix "ComicsDB"
:setvar DefaultDataPath "C:\Users\Ec_71\AppData\Local\Microsoft\VisualStudio\SSDT\"
:setvar DefaultLogPath "C:\Users\Ec_71\AppData\Local\Microsoft\VisualStudio\SSDT\"

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
USE [$(DatabaseName)];


GO
PRINT N'Rename refactoring operation with key 39a845e1-7d55-4534-a5ab-9304fb367455 is skipped, element [dbo].[Admin].[Id] (SqlSimpleColumn) will not be renamed to adminID';


GO
PRINT N'Rename refactoring operation with key 7be2bbf9-933b-42e9-8884-7030289c227e is skipped, element [dbo].[Community].[Id] (SqlSimpleColumn) will not be renamed to name';


GO
PRINT N'Rename refactoring operation with key 4533a49e-6799-4efd-aa8c-c7b110c2985c is skipped, element [dbo].[Catalog].[Id] (SqlSimpleColumn) will not be renamed to title';


GO
PRINT N'Rename refactoring operation with key b800c976-740b-4733-93b7-4f4322cca13d is skipped, element [dbo].[FK_Catalog_ToTable] (SqlForeignKeyConstraint) will not be renamed to [FK_Catalog_Community]';


GO
PRINT N'Rename refactoring operation with key 5ea4f980-b5fb-4d36-af26-97f0841e6f35 is skipped, element [dbo].[Chapter].[Id] (SqlSimpleColumn) will not be renamed to chapterNum';


GO
PRINT N'Rename refactoring operation with key 0bfbec0c-9328-49e1-8c14-41469d3dadb3 is skipped, element [dbo].[Comic].[Id] (SqlSimpleColumn) will not be renamed to title';


GO
PRINT N'Rename refactoring operation with key 38ecddd4-193b-45cb-9a8c-9412fe4fb6bc is skipped, element [dbo].[Comment].[Id] (SqlSimpleColumn) will not be renamed to commentNum';


GO
PRINT N'Rename refactoring operation with key 23e48c79-270f-499b-a2c2-4e2ba71dab6c is skipped, element [dbo].[FComment].[Id] (SqlSimpleColumn) will not be renamed to commentNum';


GO
PRINT N'Rename refactoring operation with key bf9edcdd-1014-454c-84c7-a352c20b0867 is skipped, element [dbo].[Forum].[Id] (SqlSimpleColumn) will not be renamed to title';


GO
PRINT N'Rename refactoring operation with key 40375e0b-8cf5-4ab9-bb39-62a3ffb48f5c is skipped, element [dbo].[Member_Of].[Id] (SqlSimpleColumn) will not be renamed to commName';


GO
PRINT N'Rename refactoring operation with key 264be8a9-0e59-42a6-bfd5-cfc4c198c330 is skipped, element [dbo].[Moderates].[Id] (SqlSimpleColumn) will not be renamed to commName';


GO
PRINT N'Rename refactoring operation with key 257d703d-1812-45b6-bc01-f06efeb64e23 is skipped, element [dbo].[Report].[Id] (SqlSimpleColumn) will not be renamed to reportNum';


GO
PRINT N'Rename refactoring operation with key 7249adcb-4b0f-4903-99bb-bed900d17574 is skipped, element [dbo].[Report].[Infraction] (SqlSimpleColumn) will not be renamed to infraction';


GO
PRINT N'Rename refactoring operation with key e09407db-fee9-40ff-8eba-ba012cee439b is skipped, element [dbo].[Reviews].[Id] (SqlSimpleColumn) will not be renamed to reportNum';


GO
PRINT N'Rename refactoring operation with key 015e1701-961b-4063-8325-deb496ae266d is skipped, element [dbo].[FK_Forum_ToTable] (SqlForeignKeyConstraint) will not be renamed to [FK_Forum_Community]';


GO
PRINT N'Rename refactoring operation with key d56b21c6-5073-4224-b612-927eba335a8e is skipped, element [dbo].[Author].[Id] (SqlSimpleColumn) will not be renamed to userID';


GO
PRINT N'Rename refactoring operation with key ebb970eb-cbff-41d7-b040-0153ac6d172e is skipped, element [dbo].[Subscribes].[Id] (SqlSimpleColumn) will not be renamed to comicTitle';


GO
PRINT N'Rename refactoring operation with key 13a0bc5d-d872-495e-bc08-44d1f8e049ce is skipped, element [dbo].[Comic_Tag].[Id] (SqlSimpleColumn) will not be renamed to comicTitle';


GO
PRINT N'Rename refactoring operation with key 13f46c5d-2ad1-4b16-9f8f-ce7ed8f1a26e is skipped, element [dbo].[Catalog_Tag].[Id] (SqlSimpleColumn) will not be renamed to catalogTitle';


GO
PRINT N'Rename refactoring operation with key 97e76e1f-b73a-4372-b95f-e28913db3baf, 9a9636ca-a71e-491f-8fe5-68d39dbb184f is skipped, element [dbo].[Collection_Of].[Id] (SqlSimpleColumn) will not be renamed to catalogTitle';


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
    [title]    NVARCHAR (450) NOT NULL,
    [commName] NVARCHAR (450) NULL,
    [creator]  NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([title] ASC)
);


GO
PRINT N'Creating Table [dbo].[Catalog_Tag]...';


GO
CREATE TABLE [dbo].[Catalog_Tag] (
    [catalogTitle] NVARCHAR (450) NOT NULL,
    [Tag]          NVARCHAR (450) NOT NULL,
    PRIMARY KEY CLUSTERED ([catalogTitle] ASC, [Tag] ASC)
);


GO
PRINT N'Creating Table [dbo].[Chapter]...';


GO
CREATE TABLE [dbo].[Chapter] (
    [chapterNum] INT            NOT NULL,
    [comicTitle] NVARCHAR (450) NOT NULL,
    PRIMARY KEY CLUSTERED ([chapterNum] ASC)
);


GO
PRINT N'Creating Table [dbo].[Collection_Of]...';


GO
CREATE TABLE [dbo].[Collection_Of] (
    [catalogTitle] NVARCHAR (450) NOT NULL,
    [comicTitle]   NVARCHAR (450) NOT NULL,
    PRIMARY KEY CLUSTERED ([catalogTitle] ASC, [comicTitle] ASC)
);


GO
PRINT N'Creating Table [dbo].[Comic]...';


GO
CREATE TABLE [dbo].[Comic] (
    [title]  NVARCHAR (450) NOT NULL,
    [pages]  NVARCHAR (450) NOT NULL,
    [author] NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([title] ASC)
);


GO
PRINT N'Creating Table [dbo].[Comic_Tag]...';


GO
CREATE TABLE [dbo].[Comic_Tag] (
    [comicTitle] NVARCHAR (450) NOT NULL,
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
    [name] NVARCHAR (450) NOT NULL,
    PRIMARY KEY CLUSTERED ([name] ASC)
);


GO
PRINT N'Creating Table [dbo].[FComment]...';


GO
CREATE TABLE [dbo].[FComment] (
    [commentNum] INT            NOT NULL,
    [forumTitle] NVARCHAR (450) NOT NULL,
    [writer]     NVARCHAR (50)  NOT NULL,
    [timeStamp]  DATETIME       NOT NULL,
    [commName]   NVARCHAR (450) NOT NULL,
    PRIMARY KEY CLUSTERED ([commentNum] ASC, [forumTitle] ASC, [writer] ASC, [commName] ASC)
);


GO
PRINT N'Creating Table [dbo].[Forum]...';


GO
CREATE TABLE [dbo].[Forum] (
    [title]     NVARCHAR (450) NOT NULL,
    [community] NVARCHAR (450) NOT NULL,
    PRIMARY KEY CLUSTERED ([title] ASC, [community] ASC)
);


GO
PRINT N'Creating Table [dbo].[Member_Of]...';


GO
CREATE TABLE [dbo].[Member_Of] (
    [commName] NVARCHAR (450) NOT NULL,
    [userID]   NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([commName] ASC, [userID] ASC)
);


GO
PRINT N'Creating Table [dbo].[Moderates]...';


GO
CREATE TABLE [dbo].[Moderates] (
    [commName] NVARCHAR (450) NOT NULL,
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
    [offendingComic] NVARCHAR (450) NULL,
    [infraction]     NVARCHAR (450) NOT NULL,
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
    [offendingComic] NVARCHAR (450) NULL,
    PRIMARY KEY CLUSTERED ([reportNum] ASC, [creator] ASC, [adminID] ASC)
);


GO
PRINT N'Creating Table [dbo].[Subscribes]...';


GO
CREATE TABLE [dbo].[Subscribes] (
    [comicTitle] NVARCHAR (450) NOT NULL,
    [userID]     NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([comicTitle] ASC, [userID] ASC)
);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Author_User]...';


GO
ALTER TABLE [dbo].[Author] WITH NOCHECK
    ADD CONSTRAINT [FK_Author_User] FOREIGN KEY ([userID]) REFERENCES [dbo].[User] ([userID]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Catalog_Community]...';


GO
ALTER TABLE [dbo].[Catalog] WITH NOCHECK
    ADD CONSTRAINT [FK_Catalog_Community] FOREIGN KEY ([commName]) REFERENCES [dbo].[Community] ([name]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Catalog_User]...';


GO
ALTER TABLE [dbo].[Catalog] WITH NOCHECK
    ADD CONSTRAINT [FK_Catalog_User] FOREIGN KEY ([creator]) REFERENCES [dbo].[User] ([userID]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Catalog_Tag_Catalog]...';


GO
ALTER TABLE [dbo].[Catalog_Tag] WITH NOCHECK
    ADD CONSTRAINT [FK_Catalog_Tag_Catalog] FOREIGN KEY ([catalogTitle]) REFERENCES [dbo].[Catalog] ([title]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Chapter_Comic]...';


GO
ALTER TABLE [dbo].[Chapter] WITH NOCHECK
    ADD CONSTRAINT [FK_Chapter_Comic] FOREIGN KEY ([comicTitle]) REFERENCES [dbo].[Comic] ([title]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Collection_Of_Comic]...';


GO
ALTER TABLE [dbo].[Collection_Of] WITH NOCHECK
    ADD CONSTRAINT [FK_Collection_Of_Comic] FOREIGN KEY ([comicTitle]) REFERENCES [dbo].[Comic] ([title]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Collection_Of_Catalog]...';


GO
ALTER TABLE [dbo].[Collection_Of] WITH NOCHECK
    ADD CONSTRAINT [FK_Collection_Of_Catalog] FOREIGN KEY ([catalogTitle]) REFERENCES [dbo].[Catalog] ([title]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Comic_Author]...';


GO
ALTER TABLE [dbo].[Comic] WITH NOCHECK
    ADD CONSTRAINT [FK_Comic_Author] FOREIGN KEY ([author]) REFERENCES [dbo].[Author] ([userID]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Comic_Tag_Comic]...';


GO
ALTER TABLE [dbo].[Comic_Tag] WITH NOCHECK
    ADD CONSTRAINT [FK_Comic_Tag_Comic] FOREIGN KEY ([comicTitle]) REFERENCES [dbo].[Comic] ([title]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Comment_User]...';


GO
ALTER TABLE [dbo].[Comment] WITH NOCHECK
    ADD CONSTRAINT [FK_Comment_User] FOREIGN KEY ([writer]) REFERENCES [dbo].[User] ([userID]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Comment_Chapter]...';


GO
ALTER TABLE [dbo].[Comment] WITH NOCHECK
    ADD CONSTRAINT [FK_Comment_Chapter] FOREIGN KEY ([chapterNum]) REFERENCES [dbo].[Chapter] ([chapterNum]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_FComment_Forum]...';


GO
ALTER TABLE [dbo].[FComment] WITH NOCHECK
    ADD CONSTRAINT [FK_FComment_Forum] FOREIGN KEY ([forumTitle], [commName]) REFERENCES [dbo].[Forum] ([title], [community]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_FComment_User]...';


GO
ALTER TABLE [dbo].[FComment] WITH NOCHECK
    ADD CONSTRAINT [FK_FComment_User] FOREIGN KEY ([writer]) REFERENCES [dbo].[User] ([userID]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Forum_Community]...';


GO
ALTER TABLE [dbo].[Forum] WITH NOCHECK
    ADD CONSTRAINT [FK_Forum_Community] FOREIGN KEY ([community]) REFERENCES [dbo].[Community] ([name]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Member_Of_Community]...';


GO
ALTER TABLE [dbo].[Member_Of] WITH NOCHECK
    ADD CONSTRAINT [FK_Member_Of_Community] FOREIGN KEY ([commName]) REFERENCES [dbo].[Community] ([name]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Member_Of_User]...';


GO
ALTER TABLE [dbo].[Member_Of] WITH NOCHECK
    ADD CONSTRAINT [FK_Member_Of_User] FOREIGN KEY ([userID]) REFERENCES [dbo].[User] ([userID]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Moderates_Community]...';


GO
ALTER TABLE [dbo].[Moderates] WITH NOCHECK
    ADD CONSTRAINT [FK_Moderates_Community] FOREIGN KEY ([commName]) REFERENCES [dbo].[Community] ([name]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Moderates_User]...';


GO
ALTER TABLE [dbo].[Moderates] WITH NOCHECK
    ADD CONSTRAINT [FK_Moderates_User] FOREIGN KEY ([userID]) REFERENCES [dbo].[User] ([userID]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Report_User]...';


GO
ALTER TABLE [dbo].[Report] WITH NOCHECK
    ADD CONSTRAINT [FK_Report_User] FOREIGN KEY ([creator]) REFERENCES [dbo].[User] ([userID]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Report_User1]...';


GO
ALTER TABLE [dbo].[Report] WITH NOCHECK
    ADD CONSTRAINT [FK_Report_User1] FOREIGN KEY ([offendingUser]) REFERENCES [dbo].[User] ([userID]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Report_Comic]...';


GO
ALTER TABLE [dbo].[Report] WITH NOCHECK
    ADD CONSTRAINT [FK_Report_Comic] FOREIGN KEY ([offendingComic]) REFERENCES [dbo].[Comic] ([title]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Reviews_Admin]...';


GO
ALTER TABLE [dbo].[Reviews] WITH NOCHECK
    ADD CONSTRAINT [FK_Reviews_Admin] FOREIGN KEY ([adminID]) REFERENCES [dbo].[Admin] ([adminID]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Reviews_User]...';


GO
ALTER TABLE [dbo].[Reviews] WITH NOCHECK
    ADD CONSTRAINT [FK_Reviews_User] FOREIGN KEY ([creator]) REFERENCES [dbo].[User] ([userID]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Reviews_User1]...';


GO
ALTER TABLE [dbo].[Reviews] WITH NOCHECK
    ADD CONSTRAINT [FK_Reviews_User1] FOREIGN KEY ([offendingUser]) REFERENCES [dbo].[User] ([userID]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Reviews_Comic]...';


GO
ALTER TABLE [dbo].[Reviews] WITH NOCHECK
    ADD CONSTRAINT [FK_Reviews_Comic] FOREIGN KEY ([offendingComic]) REFERENCES [dbo].[Comic] ([title]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Subscribes_Comic]...';


GO
ALTER TABLE [dbo].[Subscribes] WITH NOCHECK
    ADD CONSTRAINT [FK_Subscribes_Comic] FOREIGN KEY ([comicTitle]) REFERENCES [dbo].[Comic] ([title]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Subscribes_User]...';


GO
ALTER TABLE [dbo].[Subscribes] WITH NOCHECK
    ADD CONSTRAINT [FK_Subscribes_User] FOREIGN KEY ([userID]) REFERENCES [dbo].[User] ([userID]);


GO
-- Refactoring step to update target server with deployed transaction logs
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
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Author] WITH CHECK CHECK CONSTRAINT [FK_Author_User];

ALTER TABLE [dbo].[Catalog] WITH CHECK CHECK CONSTRAINT [FK_Catalog_Community];

ALTER TABLE [dbo].[Catalog] WITH CHECK CHECK CONSTRAINT [FK_Catalog_User];

ALTER TABLE [dbo].[Catalog_Tag] WITH CHECK CHECK CONSTRAINT [FK_Catalog_Tag_Catalog];

ALTER TABLE [dbo].[Chapter] WITH CHECK CHECK CONSTRAINT [FK_Chapter_Comic];

ALTER TABLE [dbo].[Collection_Of] WITH CHECK CHECK CONSTRAINT [FK_Collection_Of_Comic];

ALTER TABLE [dbo].[Collection_Of] WITH CHECK CHECK CONSTRAINT [FK_Collection_Of_Catalog];

ALTER TABLE [dbo].[Comic] WITH CHECK CHECK CONSTRAINT [FK_Comic_Author];

ALTER TABLE [dbo].[Comic_Tag] WITH CHECK CHECK CONSTRAINT [FK_Comic_Tag_Comic];

ALTER TABLE [dbo].[Comment] WITH CHECK CHECK CONSTRAINT [FK_Comment_User];

ALTER TABLE [dbo].[Comment] WITH CHECK CHECK CONSTRAINT [FK_Comment_Chapter];

ALTER TABLE [dbo].[FComment] WITH CHECK CHECK CONSTRAINT [FK_FComment_Forum];

ALTER TABLE [dbo].[FComment] WITH CHECK CHECK CONSTRAINT [FK_FComment_User];

ALTER TABLE [dbo].[Forum] WITH CHECK CHECK CONSTRAINT [FK_Forum_Community];

ALTER TABLE [dbo].[Member_Of] WITH CHECK CHECK CONSTRAINT [FK_Member_Of_Community];

ALTER TABLE [dbo].[Member_Of] WITH CHECK CHECK CONSTRAINT [FK_Member_Of_User];

ALTER TABLE [dbo].[Moderates] WITH CHECK CHECK CONSTRAINT [FK_Moderates_Community];

ALTER TABLE [dbo].[Moderates] WITH CHECK CHECK CONSTRAINT [FK_Moderates_User];

ALTER TABLE [dbo].[Report] WITH CHECK CHECK CONSTRAINT [FK_Report_User];

ALTER TABLE [dbo].[Report] WITH CHECK CHECK CONSTRAINT [FK_Report_User1];

ALTER TABLE [dbo].[Report] WITH CHECK CHECK CONSTRAINT [FK_Report_Comic];

ALTER TABLE [dbo].[Reviews] WITH CHECK CHECK CONSTRAINT [FK_Reviews_Admin];

ALTER TABLE [dbo].[Reviews] WITH CHECK CHECK CONSTRAINT [FK_Reviews_User];

ALTER TABLE [dbo].[Reviews] WITH CHECK CHECK CONSTRAINT [FK_Reviews_User1];

ALTER TABLE [dbo].[Reviews] WITH CHECK CHECK CONSTRAINT [FK_Reviews_Comic];

ALTER TABLE [dbo].[Subscribes] WITH CHECK CHECK CONSTRAINT [FK_Subscribes_Comic];

ALTER TABLE [dbo].[Subscribes] WITH CHECK CHECK CONSTRAINT [FK_Subscribes_User];


GO
PRINT N'Update complete.';


GO
