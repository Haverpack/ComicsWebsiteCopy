CREATE TABLE [dbo].[Member_Of]
(
	[commName] NVARCHAR(450) NOT NULL , 
    [userID] NVARCHAR(50) NOT NULL, 
    PRIMARY KEY ([commName], [userID]), 
    CONSTRAINT [FK_Member_Of_Community] FOREIGN KEY ([commName]) REFERENCES [Community]([name]), 
    CONSTRAINT [FK_Member_Of_User] FOREIGN KEY ([userID]) REFERENCES [User]([userID])
)
