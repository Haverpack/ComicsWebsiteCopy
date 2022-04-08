CREATE TABLE [dbo].[Comic_Tag]
(
	[comicTitle] NVARCHAR(450) NOT NULL , 
    [Tag] NVARCHAR(50) NOT NULL, 
    PRIMARY KEY ([comicTitle], [Tag]),
    CONSTRAINT [FK_Comic_Tag_Comic] FOREIGN KEY ([comicTitle]) REFERENCES [Comic]([title])
)
