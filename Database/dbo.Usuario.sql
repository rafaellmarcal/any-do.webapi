CREATE TABLE [dbo].[Usuario] (
    [UsuarioID] INT            IDENTITY (1, 1) NOT NULL,
    [Nome]      NVARCHAR (255) NOT NULL,
    [Senha]     NVARCHAR (255) NOT NULL,
    [Email]     NVARCHAR (225) NOT NULL,
    PRIMARY KEY CLUSTERED ([UsuarioID] ASC)
);

