CREATE TABLE [dbo].[Collection_Of]
(
	[catalogTitle] NVARCHAR(450) NOT NULL , 
    [comicTitle] NVARCHAR(450) NOT NULL, 
    PRIMARY KEY ([catalogTitle], [comicTitle]),
    CONSTRAINT [FK_Collection_Of_Comic] FOREIGN KEY ([comicTitle]) REFERENCES [Comic]([title]),
    CONSTRAINT [FK_Collection_Of_Catalog] FOREIGN KEY ([catalogTitle]) REFERENCES [Catalog]([title])
)
