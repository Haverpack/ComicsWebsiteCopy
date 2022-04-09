﻿CREATE TABLE [dbo].[Comic]
(
	[title] NVARCHAR(450) NOT NULL PRIMARY KEY, 
    [pages] NVARCHAR(450) NOT NULL, 
    [author] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Comic_Author] FOREIGN KEY ([Author]) REFERENCES [Author]([userID])
)