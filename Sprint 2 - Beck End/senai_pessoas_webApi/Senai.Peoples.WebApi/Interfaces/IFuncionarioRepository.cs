using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    public interface IFuncionarioRepository
    {
        // tipoRetorno NomeMetodo();

       /// <summary>
       /// retorna todos os funcionarios
       /// </summary>
       /// <returns>lista de funcionario</returns>
        List<FuncionarioDomain> ListarTodos();

        /// <summary>
        /// busca o funcionario atraves do seu id
        /// </summary>
        /// <param name="id">id do funcionario</param>
        /// <returns>objeto do tipo FuncionarioDomain que foi buscado</returns>
        FuncionarioDomain BuscarPorId(int id);

        /// <summary>
        /// cadastra um novo funcionario
        /// </summary>
        /// <param name="novoFuncionario">objeto novoFuncionario que será cadastrado</param>
        void Cadastrar(FuncionarioDomain novoFuncionario);

        /// <summary>
        /// atualiza um funcionario existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="funcionario">objeto que será atualizado</param>
        void AtualizarIdCorpo(FuncionarioDomain funcionario);

        /// <summary>
        /// deleta um funcionario
        /// </summary>
        /// <param name="id">id do funcionario que será deletado</param>
        void Deletar(int id);

    }
}
