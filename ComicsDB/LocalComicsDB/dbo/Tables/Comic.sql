CREATE TABLE [dbo].[Comic]
(
	[title] NVARCHAR(450) NOT NULL PRIMARY KEY, 
    [pages] NVARCHAR(450) NULL, 
    [author] NVARCHAR(50) NULL, 
    [banner] NVARCHAR(450) NULL,
    CONSTRAINT [FK_Comic_Author] FOREIGN KEY ([author]) REFERENCES [Author]([userID]) 
)
