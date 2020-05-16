using InfnetMovieDataBase.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace InfnetMovieDataBase.Repository
{
    public class FilmeRepository
    {
        //A aplicação precisa saber achar o banco.
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=InfnetMovieDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Listar filmes
        public IEnumerable<Filme> ListarFilmes()
        {
            // Onde vamos armazenar o resultado da consulta?
            var filmes = new List<Filme>();

            using var connection = new SqlConnection(connectionString); // Dá close e dispose
            // Agora, a conexão existe.
            // O que queremos acessar do banco?
            var cmdText = "SELECT * FROM Filme";
            // Vincular esse comando a uma conexão:
            var select = new SqlCommand(cmdText, connection);
            try
            {
                //Abrir a conexão
                connection.Open();
                using var reader = select.ExecuteReader(CommandBehavior.CloseConnection);
                // A conexão está aberta; O comando SQL foi executado
                while (reader.Read())
                {
                    //Enquanto for possível ler de reader significa que ainda temos Filmes armazenados no banco
                    var filme = new Filme();
                    filme.Id = (int)reader["Id"]; 
                    filme.Titulo = reader["Titulo"].ToString();
                    filme.TituloOriginal = reader["TituloOriginal"].ToString();
                    filme.Ano = (int)reader["Ano"];
                    filmes.Add(filme);
                }
            }
            catch (Exception e)
            {

            }
            finally
            {

            }

            return filmes;
        }

        //Listar elenco do filme
        public IEnumerable<Pessoa> ListarElenco(int id)
        {
            var elenco = new List<Pessoa>();

            using var connection = new SqlConnection(connectionString);
            var sp = "ListarAtoresPorFilme";
            //Vinculando o que desejamos executar (a stored procedure)
            //à conexão na qual desejamos executá-la (connection)
            var sqlCommand = new SqlCommand(sp, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@FilmeId", id);

            try
            {
                connection.Open();
                using var reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var pessoa = new Pessoa
                    {
                        Nome = reader["Nome"].ToString(),
                        Sobrenome = reader["Sobrenome"].ToString()
                    };

                    elenco.Add(pessoa);
                }
            } catch (Exception e)
            {

            }
            finally
            {
                connection.Close();
            }

            return elenco;
        }

        //Criar filmes
        public void CriarFilme(Filme filme)
        {
            using var connection = new SqlConnection(connectionString);
            var cmdText = "INSERT INTO Filme (Titulo, TituloOriginal, Ano) VALUES (@Titulo, @TituloOriginal, @Ano)";
            var insert = new SqlCommand(cmdText, connection);
            insert.CommandType = CommandType.Text;
            //Configurar os parâmetros @Titulo, @TituloOriginal e @Ano:
            insert.Parameters.AddWithValue("@Titulo", filme.Titulo);
            insert.Parameters.AddWithValue("@TituloOriginal", filme.TituloOriginal);
            insert.Parameters.AddWithValue("@Ano", filme.Ano);
            try
            {
                connection.Open();
                insert.ExecuteNonQuery();
            } catch (Exception e)
            {
                throw e; 
            }
        }

        //Atualizar filmes
        public void AtualizarFilme(Filme filme)
        {
            throw new NotImplementedException();
        }

        //Detalhar filmes
        public Filme DetalharFilme(int id)
        {
            throw new NotImplementedException();
        }

        //Excluir filmes
        public void ExcluirFilme(int id)
        {
            throw new NotImplementedException();
        }
    }
}
