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
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
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
                // Declarando a query que sera executada 
              // Será enviado para o banco  INSERT INTO Generos(Nome) VALUES ('Aventura');
                string queryInsert = "INSERT INTO Generos(Nome) VALUES(' " + novoGenero.nome + " ')";

                // enviar a informação para ser cadastrada
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // abre a conexao com o banco de dados
                    con.Open();

                    // executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
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
        //fim listar
    }
}
