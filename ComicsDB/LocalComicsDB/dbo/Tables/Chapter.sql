CREATE TABLE [dbo].[Chapter]
(
	[chapterNum] INT NOT NULL PRIMARY KEY, 
    [comicTitle] NVARCHAR(450) NOT NULL, 
    CONSTRAINT [FK_Chapter_Comic] FOREIGN KEY ([comicTitle]) REFERENCES [Comic]([title])
)
