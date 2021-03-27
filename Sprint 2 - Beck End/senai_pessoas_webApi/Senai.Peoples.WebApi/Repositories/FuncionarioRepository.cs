using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
   
    /// <summary>
    /// repositorio dos funcionarios
    /// </summary>
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private string stringConexao = "DataSource=DESKTOP-F5RLTTT; initial catalog=M_Peoples; user Id=sa; pwd=L@iane/j13";
        public void AtualizarIdCorpo(FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string idBody = "UPDATE funcionarios SET nome, sobrenome WHERE idFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(idBody, con))
                {
                    cmd.Parameters.AddWithValue("@nome", funcionario.nome);
                    cmd.Parameters.AddWithValue("@sobrenome", funcionario.sobreNome);
                    cmd.Parameters.AddWithValue("@ID", funcionario.idFuncionario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }        
        }

        /// <summary>
        /// buscar um genero através do seu id
        /// </summary>
        /// <param name="id">id do genero que sera buscado </param>
        /// <returns>um funcionario buscado ou null</returns>
        public FuncionarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection (stringConexao))
            {
                string selectById = "SELECT idFuncionario, nome, sobrenome FROM funcionarios WHERE idFuncionario = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand (selectById,con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    // se no rdr eu obtiver algo para ler
                    if (rdr.Read())
                    {
                        // caso não
                        FuncionarioDomain funcionarioBuscado = new FuncionarioDomain
                        {
                            idFuncionario = Convert.ToInt32(rdr["idFuncionario"]),
                            nome = rdr["nome"].ToString(),
                            sobreNome = rdr["sobrenome"].ToString()
                        };

                        return funcionarioBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(FuncionarioDomain novoFuncionario)
        {
            using (SqlConnection con = new  SqlConnection(stringConexao))
            {
                string insert = "INSERT INTO funcionarios(nome) funcionarios(sobrenome) VALUES (@nome), (@sobrenome)";
                

                using (SqlCommand cmd = new SqlCommand(insert, con))
                {
                    cmd.Parameters.AddWithValue("@nome", novoFuncionario.nome);
                    cmd.Parameters.AddWithValue("@sobrenome", novoFuncionario.sobreNome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string delete = "DELETE FROM funcionarios WHERE idFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(delete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// lista todos os funcionarios 
        /// </summary>
        /// <returns>uma lista de funcionarios</returns>
        public List<FuncionarioDomain> ListarTodos()
        {
            List<FuncionarioDomain> listaFuncionarios = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string query = "SELECT idFuncionario, nome, sobrenome FROM funcionarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    // enquanto houver registros para serem lidos, o laço vai repetir
                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain()
                        {
                            idFuncionario = Convert.ToInt32(rdr[0]),
                            nome = rdr[1].ToString()

                        };


                        listaFuncionarios.Add(funcionario);
                    }
                }
            }

            return listaFuncionarios;
        }
    }
}
