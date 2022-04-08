CREATE TABLE [dbo].[Forum]
(
	[title] NVARCHAR(450) NOT NULL , 
    [community] NVARCHAR(450) NOT NULL, 
    PRIMARY KEY ([title], [community]), 
    CONSTRAINT [FK_Forum_Community] FOREIGN KEY ([community]) REFERENCES [Community]([name])
)
