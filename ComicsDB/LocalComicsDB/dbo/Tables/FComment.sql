CREATE TABLE [dbo].[FComment]
(
	[commentNum] INT NOT NULL IDENTITY , 
    [forumTitle] NVARCHAR(450) NOT NULL, 
    [writer] NVARCHAR(50) NOT NULL, 
    [timeStamp] DATETIME NOT NULL DEFAULT getdate(), 
    [commName] NVARCHAR(450) NOT NULL, 
    [body] NVARCHAR(450) NULL, 
    PRIMARY KEY ([commentNum], [forumTitle], [writer], [commName]),
    CONSTRAINT [FK_FComment_Forum] FOREIGN KEY ([forumTitle],[commName]) REFERENCES [Forum]([title],[community]) ON DELETE Cascade ON UPDATE Cascade, 
    CONSTRAINT [FK_FComment_User] FOREIGN KEY ([writer]) REFERENCES [User]([userID]) ON DELETE Cascade ON UPDATE Cascade
)
