CREATE TABLE [dbo].[Author]
(
	[userID] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    CONSTRAINT [FK_Author_User] FOREIGN KEY ([userID]) REFERENCES [User]([userID])
)