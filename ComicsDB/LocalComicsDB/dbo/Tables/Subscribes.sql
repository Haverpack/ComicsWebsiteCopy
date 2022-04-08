CREATE TABLE [dbo].[Subscribes]
(
	[comicTitle] NVARCHAR(450) NOT NULL , 
    [userID] NVARCHAR(50) NOT NULL, 
    PRIMARY KEY ([comicTitle], [userID]),
    CONSTRAINT [FK_Subscribes_Comic] FOREIGN KEY ([comicTitle]) REFERENCES [Comic]([title]), 
    CONSTRAINT [FK_Subscribes_User] FOREIGN KEY ([userID]) REFERENCES [User]([userID])
)
