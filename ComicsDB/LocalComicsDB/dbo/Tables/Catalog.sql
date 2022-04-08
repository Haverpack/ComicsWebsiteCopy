CREATE TABLE [dbo].[Catalog]
(
	[title] NVARCHAR(450) NOT NULL PRIMARY KEY, 
    [commName] NVARCHAR(450) NULL, 
    [creator] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Catalog_Community] FOREIGN KEY ([commName]) REFERENCES [Community]([name]), 
    CONSTRAINT [FK_Catalog_User] FOREIGN KEY ([creator]) REFERENCES [User]([userID])
)
