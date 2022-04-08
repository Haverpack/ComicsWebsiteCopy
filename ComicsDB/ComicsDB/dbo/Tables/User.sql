CREATE TABLE [dbo].[User] (
    [userID]   NVARCHAR(50)        NOT NULL,
    [email]    NVARCHAR(50) NOT NULL,
    [password] NVARCHAR(50) NOT NULL,
    PRIMARY KEY CLUSTERED ([userID] ASC)
);

