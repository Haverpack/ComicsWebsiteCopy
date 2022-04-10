CREATE TABLE [dbo].[Report]
(
	[reportNum] INT NOT NULL  IDENTITY, 
    [creator] NVARCHAR(50) NOT NULL, 
    [offendingUser] NVARCHAR(50) NULL, 
    [offendingComic] NVARCHAR(450) NULL, 
    [infraction] NVARCHAR(450) NOT NULL, 
    [timeStamp] DATETIME NOT NULL DEFAULT getdate(), 
    PRIMARY KEY ([reportNum], [infraction], [creator]), 
    CONSTRAINT [FK_Report_User] FOREIGN KEY ([creator]) REFERENCES [User]([userID]) ON DELETE Cascade ON UPDATE Cascade, 
    CONSTRAINT [FK_Report_User1] FOREIGN KEY ([offendingUser]) REFERENCES [User]([userID]), 
    CONSTRAINT [FK_Report_Comic] FOREIGN KEY ([offendingComic]) REFERENCES [Comic]([title])
) 
