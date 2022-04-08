CREATE TABLE [dbo].[Comment]
(
	[commentNum] INT NOT NULL, 
    [writer] NVARCHAR(50) NOT NULL, 
    [chapterNum] INT NOT NULL, 
    [timeStamp] DATETIME NOT NULL
    PRIMARY KEY(commentNum,writer,chapterNum), 
    CONSTRAINT [FK_Comment_User] FOREIGN KEY ([writer]) REFERENCES [User]([userID]), 
    CONSTRAINT [FK_Comment_Chapter] FOREIGN KEY ([chapterNum]) REFERENCES [Chapter]([chapterNum])
)
