USE InfnetMovieDataBase;

CREATE TABLE [dbo].[Pessoa] (
    [Id]             INT           NOT NULL PRIMARY KEY IDENTITY,
    [Nome]           VARCHAR (255) NULL,
    [Sobrenome]      VARCHAR (255) NULL,
    [DataNascimento] DATE          NULL
);

INSERT INTO [dbo].[Pessoa] (Nome, Sobrenome, DataNascimento) VALUES ('Sylvester', 'Stallone', '07/06/1946');
INSERT INTO [dbo].[Pessoa] (Nome, Sobrenome, DataNascimento) VALUES ('Arnold', 'Schwarzenegger', '07/30/1947');
INSERT INTO [dbo].[Pessoa] (Nome, Sobrenome, DataNascimento) VALUES ('Jackie', 'Chan', '04/07/1954');