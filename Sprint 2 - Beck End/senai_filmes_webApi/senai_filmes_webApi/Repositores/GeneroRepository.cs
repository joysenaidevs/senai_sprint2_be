using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Repositores
{
    /// <summary>
    /// Esta classe é responsavel pelo repositório dos  Generos
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// esta variavel é uma string de conexao com o banco de dados que recebe os parametros
        /// Data Source = nome do servidor
        /// initial catalog = nome do banco de dados
        /// user Id=sa e pwd = faz autenticacao com o usuario do sql server passando o login e a senha
        /// integrated security=true : faz a autenticacao com o usuario do sistema (windows)
        /// </summary>
        //                              nome do servidor                banco de comunicacao    usuario que vai se comunicar
        private string stringConexao = "Data Source=DESKTOP-F5RLTTT;  initial catalog=Filmes; user Id=sa; pwd:L@iane/j13";

        // autenticacao com windows
        //private string stringConexao = "Data Source=DESKTOP-F5RLTTT;  initial catalog=Filmes; integrated security=true";

        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateIdBody = "UPDATE Generos Set Nome = @Nome WHERE idGenero = @ID";
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    // passando os valores para os parametros 
                    cmd.Parameters.AddWithValue("@Nome", genero.nome);
                    cmd.Parameters.AddWithValue("@ID", genero.idGenero);

                    // abre a conexao com o banco de dados
                    con.Open();

                    // executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// atualiza o genero passando o id pela url
        /// </summary>
        /// <param name="id">id do genero que sera atualizado</param>
        /// <param name="genero">objeto genero com as novas informaçoes</param>
        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string queryUpdateUrl = "UPDATE Generos SET Nome = @Nome WHERE idGenem ro = @ID";

                // declaramos sqlcommand passando a query q sera executada e a conexao com o parametro
                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    //passa os valors para os parametros 
                    cmd.Parameters.AddWithValue("@", id);
                    cmd.Parameters.AddWithValue("@Nome", genero.nome);

                    con.Open();

                    //executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// busca um genero através do seu id
        /// </summary>
        /// <param name="id">id do genero que será buscado</param>
        /// <returns>um genero buscado ou null caso não seja encontrado</returns>

        public GeneroDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new  SqlConnection(stringConexao))
            {
                // declara a query a ser executada 
                string querySelectById = "SELECT idGenero, Nome FROM Generos WHERE idGenero = @ID";

                con.Open();

                // receber os valores do banco de ddadods 
                SqlDataReader rdr;

                // declara a SqlCommand cmd passando a query q sera executada e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // passar o valor para o parametro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // ler no banco de ddados através do cmd e o que voltar armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // verifica o resultado da query retornou algum registro
                    if(rdr.Read())
                    {
                        // se sim instancia um novo objeto generoBuscado do tipo GeneroDomain
                        GeneroDomain generoBuscado = new GeneroDomain
                        {
                            // atribui à propiedade idGenero o valor da coluna "idGenero" da tabela do banco de dados
                            idGenero = Convert.ToInt32(rdr["idGenero"]),

                            // atribui a propiedade nome o valor da coluna "Nome" da tabela do banco de dados
                            nome = rdr["Nome"].ToString()
                        };

                        // retorna o generoBuscado com os dados obtidos
                        return generoBuscado;

                    }

                    // se não , retorna null
                    return null;


                }

                
            }

        }

        /// <summary>
        /// Cadastra um novo genero
        /// </summary>
        /// <param name="novoGenero">objeto novoGenero com as informacoes que serao cadastradas</param>

        public void Cadastrar(GeneroDomain novoGenero)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
              
                // Será enviado para o banco  INSERT INTO Generos(Nome) VALUES ('Aventura');
                //                    INSERT INTO Generos(Nome) VALUES('Ficção Cientifica ');
                //                    INSERT INTO Generos(Nome) VALUES('Joana D'Arc ');
                //                    INSERT INTO Generos(Nome) VALUES('Ficção Cientifica ');
                //                    INSERT INTO Generos(Nome) VALUES(' ') DROP TABLE Filmes--);
                //string queryInsert  INSERT INTO Generos(Nome) VALUES('"+ novoGenero.nome"') )";
                // nao usar dessa forma pois pode causar o efeito Joana D'Arc
                // Além de permitir SQL Injection
                // Por exemplo:
                // "nome" : "') DROP TABLE Filmes--"
                // ao tentar cadastrar o comando acima irá deletar a tabela Filmes do banco de dados
                //string queryInsert = "INSERT INTO Generos(Nome) VALUES(' " + novoGenero.nome + " ')";

                // Declarando a query que sera executada 
                string queryInsert = "INSERT INTO Generos(Nome) VALUES(@Nome)";

                // enviar a informação para ser cadastrada
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor para o  parametro @Nome
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.nome);
                    // abre a conexao com o banco de dados
                    con.Open();

                    // executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta o genero atraves do seu id
        /// </summary>
        /// <param name="id">id do genero que será deletado</param>
        public void Deletar(int id)
        {
            // declara a SqlConnection con passando a string de conexao como parametro 
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // declara a query a ser executada passando valor como parametro, no caso o ID
                string queryDelete = "DELETE FROM Generos WHERE idGenero = @ID";

                // declara o sqlCommand cmd passando a query que será executada e a execucao como parametros
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // define o valor recebido  no método como o valor do parametro ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    //abre a conexao com os dadods
                    con.Open();

                    // executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }
        // fim deletar

        /// <summary>
        /// Este metodo lista todos os generos
        /// </summary>
        /// <returns> Este metódo retorna uma lista de generos</returns>
        public List<GeneroDomain> ListarTodos()
        {
            //criando uma lista para armazenar todos os dados
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            // criar uma nova conexao   declara a SqlConnection con passando como parametro a string de conexao
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // comandos sql que vai ser enviado para o banco de dados para rodar o script
                //     vai selecionar todos os generos
                string querySelectAll = "SELECT idGenero, Nome FROM Generos";
                // declara a instrucao a ser executada

                //vamos abrir a conexao -- Estou conectando em meu banco de dados
                con.Open();

                //leitor de dados   estou declarando um SqlDataReader rdr para percorrer a tabela banco de dados
                // apenas foi declarado, nao esta sendo executado.
                SqlDataReader rdr;

                // vou criar um objeto para executar um comando (cnd - command abreviado)
                //                                     parametros do cmd
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con) )
                {
                    // vamos executar
                    //    atribuindo cmd e executando - armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //percorrer o rdr - criaremos um laço while
                    //      enquanto houver registros para serem lidos, o laço se repetirá
                    while (rdr.Read())
                    {
                        // criar um objeto para definer qual propiedade vai cada valor
                        //instaciamos este objeto chamado genero do tipo GeneroDomain
                        GeneroDomain genero = new GeneroDomain()
                        {
                            // estou convertendo para inteiro e armazenando no idGenero
                            //atribui a propiedade idGenero o valor da primeira coluna da tabela
                            idGenero = Convert.ToInt32(rdr[0]),

                            //atribui a propiedade nome  o valor da segunda coluna da tabela banco de dados
                            nome = rdr[1].ToString() // convertendo valor em string e armazenando no nome
                        };

                        // adicionar o objeto (genero) na lista
                        listaGeneros.Add(genero);

                    }

                }
         
            }
                // retorna a lista de generos  - retornar resultado antes do metódo fechar {}S
                return listaGeneros; 
        }
        //fim listarF
    }
}
