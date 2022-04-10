CREATE TABLE [dbo].[Moderates]
(
	[commName] NVARCHAR(450) NOT NULL , 
    [userID] NVARCHAR(50) NOT NULL
	CONSTRAINT [FK_Moderates_Community] FOREIGN KEY ([commName]) REFERENCES [Community]([name]) ON DELETE Cascade ON UPDATE Cascade,  
    CONSTRAINT [FK_Moderates_User] FOREIGN KEY ([userID]) REFERENCES [User]([userID]) ON DELETE Cascade ON UPDATE Cascade, 
    PRIMARY KEY ([commName], [userID])
)
