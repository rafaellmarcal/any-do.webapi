CREATE TABLE [dbo].[Tarefa] (
    [TarefaID]      INT            IDENTITY (1, 1) NOT NULL,
    [Titulo]        NVARCHAR (50)  NOT NULL,
    [Descricao]     NVARCHAR (MAX) NOT NULL,
    [DataCadastro]  DATETIME       NOT NULL,
    [DataConclusao] DATETIME       NULL,
    [Concluida]     BIT            DEFAULT ((0)) NOT NULL,
    [UsuarioID]     INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([TarefaID] ASC),
    CONSTRAINT [FK_Usuario_Tarefa] FOREIGN KEY ([UsuarioID]) REFERENCES [dbo].[Usuario] ([UsuarioID])
);

