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
            throw new NotImplementedException();
        }

        public FuncionarioDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(FuncionarioDomain novoFuncionario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
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
