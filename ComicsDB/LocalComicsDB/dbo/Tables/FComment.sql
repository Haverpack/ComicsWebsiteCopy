CREATE TABLE [dbo].[FComment]
(
	[commentNum] INT NOT NULL , 
    [forumTitle] NVARCHAR(450) NOT NULL, 
    [writer] NVARCHAR(50) NOT NULL, 
    [timeStamp] DATETIME NOT NULL, 
    [commName] NVARCHAR(450) NOT NULL, 
    PRIMARY KEY ([commentNum], [forumTitle], [writer], [commName]),
    CONSTRAINT [FK_FComment_Forum] FOREIGN KEY ([forumTitle],[commName]) REFERENCES [Forum]([title],[community]), 
    CONSTRAINT [FK_FComment_User] FOREIGN KEY ([writer]) REFERENCES [User]([userID])
)
