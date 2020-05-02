USE InfnetMovieDataBase;

CREATE TABLE [dbo].[Filme]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Titulo] VARCHAR(255) NULL, 
    [TituloOriginal] VARCHAR(255) NULL, 
    [Ano] INT NULL 
);

INSERT INTO [dbo].[Filme] ([Titulo], [TituloOriginal], [Ano]) 
	VALUES ('Rocky: Um Lutador', 'Rocky', 1976);

INSERT INTO [dbo].[Filme] ([Titulo], [TituloOriginal], [Ano]) 
	VALUES ('Exterminador do Futuro', 'Terminator', 1984);

INSERT INTO [dbo].[Filme] ([Titulo], [TituloOriginal], [Ano]) 
	VALUES ('O Poderoso Chefão', 'The Godfather', 1972);