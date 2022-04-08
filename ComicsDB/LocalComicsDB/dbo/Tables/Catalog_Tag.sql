CREATE TABLE [dbo].[Catalog_Tag]
(
	[catalogTitle] NVARCHAR(450) NOT NULL , 
    [Tag] NVARCHAR(450) NOT NULL, 
    PRIMARY KEY ([catalogTitle], [Tag]), 
    CONSTRAINT [FK_Catalog_Tag_Catalog] FOREIGN KEY ([catalogTitle]) REFERENCES [Catalog]([title])
)
