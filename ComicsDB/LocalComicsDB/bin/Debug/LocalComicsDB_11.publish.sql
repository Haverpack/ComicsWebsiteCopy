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
:setvar DefaultDataPath "C:\Users\Salman\AppData\Local\Microsoft\VisualStudio\SSDT\"
:setvar DefaultLogPath "C:\Users\Salman\AppData\Local\Microsoft\VisualStudio\SSDT\"

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
PRINT N'Dropping Foreign Key [dbo].[FK_Report_Comic]...';


GO
ALTER TABLE [dbo].[Report] DROP CONSTRAINT [FK_Report_Comic];


GO
PRINT N'Creating Foreign Key [dbo].[FK_Report_Comic]...';


GO
ALTER TABLE [dbo].[Report] WITH NOCHECK
    ADD CONSTRAINT [FK_Report_Comic] FOREIGN KEY ([offendingComic]) REFERENCES [dbo].[Comic] ([title]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Report_User1]...';


GO
ALTER TABLE [dbo].[Report] WITH NOCHECK
    ADD CONSTRAINT [FK_Report_User1] FOREIGN KEY ([offendingUser]) REFERENCES [dbo].[User] ([userID]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Reviews_Comic]...';


GO
ALTER TABLE [dbo].[Reviews] WITH NOCHECK
    ADD CONSTRAINT [FK_Reviews_Comic] FOREIGN KEY ([offendingComic]) REFERENCES [dbo].[Comic] ([title]) ON DELETE CASCADE ON UPDATE CASCADE;


GO
PRINT N'Creating Foreign Key [dbo].[FK_Reviews_User]...';


GO
ALTER TABLE [dbo].[Reviews] WITH NOCHECK
    ADD CONSTRAINT [FK_Reviews_User] FOREIGN KEY ([creator]) REFERENCES [dbo].[User] ([userID]) ON DELETE CASCADE ON UPDATE CASCADE;


GO
PRINT N'Creating Foreign Key [dbo].[FK_Reviews_User1]...';


GO
ALTER TABLE [dbo].[Reviews] WITH NOCHECK
    ADD CONSTRAINT [FK_Reviews_User1] FOREIGN KEY ([offendingUser]) REFERENCES [dbo].[User] ([userID]) ON DELETE CASCADE ON UPDATE CASCADE;


GO
PRINT N'Creating Foreign Key [dbo].[FK_Subscribes_Comic]...';


GO
ALTER TABLE [dbo].[Subscribes] WITH NOCHECK
    ADD CONSTRAINT [FK_Subscribes_Comic] FOREIGN KEY ([comicTitle]) REFERENCES [dbo].[Comic] ([title]) ON DELETE CASCADE ON UPDATE CASCADE;


GO
PRINT N'Creating Foreign Key [dbo].[FK_Subscribes_User]...';


GO
ALTER TABLE [dbo].[Subscribes] WITH NOCHECK
    ADD CONSTRAINT [FK_Subscribes_User] FOREIGN KEY ([userID]) REFERENCES [dbo].[User] ([userID]) ON DELETE CASCADE ON UPDATE CASCADE;


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Report] WITH CHECK CHECK CONSTRAINT [FK_Report_Comic];

ALTER TABLE [dbo].[Report] WITH CHECK CHECK CONSTRAINT [FK_Report_User1];

ALTER TABLE [dbo].[Reviews] WITH CHECK CHECK CONSTRAINT [FK_Reviews_Comic];

ALTER TABLE [dbo].[Reviews] WITH CHECK CHECK CONSTRAINT [FK_Reviews_User];

ALTER TABLE [dbo].[Reviews] WITH CHECK CHECK CONSTRAINT [FK_Reviews_User1];

ALTER TABLE [dbo].[Subscribes] WITH CHECK CHECK CONSTRAINT [FK_Subscribes_Comic];

ALTER TABLE [dbo].[Subscribes] WITH CHECK CHECK CONSTRAINT [FK_Subscribes_User];


GO
PRINT N'Update complete.';


GO
