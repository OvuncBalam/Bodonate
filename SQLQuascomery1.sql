CREATE TABLE [dbo].[comments] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Message]      NVARCHAR (MAX) NULL,
    [user_Id]      INT            NULL,
    [Requester_Id] INT            NULL,
    CONSTRAINT [PK_dbo.comments] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.comments_dbo.Users_user_Id] FOREIGN KEY ([user_Id]) REFERENCES [dbo].[Users] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_user_Id]
    ON [dbo].[comments]([user_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Requester_Id]
    ON [dbo].[comments]([Requester_Id] ASC);
