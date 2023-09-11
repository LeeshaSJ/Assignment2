CREATE TABLE [dbo].[UserModel] (
    [Id]         NVARCHAR (450) NOT NULL,
    [FullName]   NVARCHAR (150) NOT NULL,
    [Email]      NVARCHAR (150) NOT NULL,
    [Department] NVARCHAR (150) NOT NULL,
    CONSTRAINT [PK_UserModel] PRIMARY KEY CLUSTERED ([Id] ASC)
);

