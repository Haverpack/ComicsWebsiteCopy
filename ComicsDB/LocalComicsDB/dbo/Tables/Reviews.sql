CREATE TABLE [dbo].[Reviews]
(
	[reportNum] INT NOT NULL , 
    [adminID] INT NOT NULL, 
    [creator] NVARCHAR(50) NOT NULL, 
    [offendingUser] NVARCHAR(50) NULL, 
    [offendingComic] NVARCHAR(450) NULL, 
    PRIMARY KEY ([reportNum], [creator], [adminID]), 
    CONSTRAINT [FK_Reviews_Admin] FOREIGN KEY ([adminID]) REFERENCES [Admin]([adminID]),
    CONSTRAINT [FK_Reviews_User] FOREIGN KEY ([creator]) REFERENCES [User]([userID]),
    CONSTRAINT [FK_Reviews_User1] FOREIGN KEY ([offendingUser]) REFERENCES [User]([userID]),
    CONSTRAINT [FK_Reviews_Comic] FOREIGN KEY ([offendingcomic]) REFERENCES [Comic]([title])
)
