IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [TB_TAREFAS] (
    [Id] int NOT NULL IDENTITY,
    [Título] varchar(200) NOT NULL,
    [Descricao] varchar(200) NOT NULL,
    [Observacao] varchar(200) NOT NULL,
    [Classe] int NOT NULL,
    CONSTRAINT [PK_TB_TAREFAS] PRIMARY KEY ([Id])
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Classe', N'Descricao', N'Observacao', N'Título') AND [object_id] = OBJECT_ID(N'[TB_TAREFAS]'))
    SET IDENTITY_INSERT [TB_TAREFAS] ON;
INSERT INTO [TB_TAREFAS] ([Id], [Classe], [Descricao], [Observacao], [Título])
VALUES (1, 2, 'Estudar para á prova', 'Andamento', 'Estudar'),
(2, 3, 'Viagem para pesquisa/trabalho da universidade', 'Não iniciado', 'Viagem'),
(3, 1, 'Fazer atividade em grupo na casa da Mariana', 'Concluido', 'Trablho em grupo'),
(4, 3, 'Aniversario de uma amiga', 'nao iniciada', 'Compromisso');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Classe', N'Descricao', N'Observacao', N'Título') AND [object_id] = OBJECT_ID(N'[TB_TAREFAS]'))
    SET IDENTITY_INSERT [TB_TAREFAS] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241130225052_InitialCreate', N'9.0.0');

COMMIT;
GO

