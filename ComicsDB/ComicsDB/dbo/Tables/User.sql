CREATE TABLE [dbo].[User] (
    [userID]   INT        NOT NULL,
    [email]    NCHAR (10) NULL,
    [userName] NCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([userID] ASC)
);

