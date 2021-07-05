using senai_spmedical_be_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedical_be_webApi.Interfaces
{
    /// <summary>
    /// Interface responsavel pelos tipos de usuarios
    /// </summary>
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista de tiposUsuarios
        /// </summary>
        /// <returns>retorna uma lista de usuarios</returns>
        List<TipoUsuario> Listar();

        /// <summary>
        /// Cadastra um novo tipo de usuario
        /// </summary>
        /// <param name="novoTipoUsuario">objeto que será cadastrado</param>
        void Cadastrar(TipoUsuario novoTipoUsuario);


        /// <summary>
        /// Busca um tipo de usuario através do seu id
        /// </summary>
        /// <param name="id">id do tipo usuario buscado</param>
        /// <returns></returns>
        TipoUsuario BuscarPorId(int id);


        /// <summary>
        /// Atualiza um tipo de usuario existente através do seu id
        /// </summary>
        /// <param name="id">id do usuario existente</param>
        /// <param name="tipoUsuarioUpdate">objeto que será atualizado</param>
        void Atualizar(int id, TipoUsuario tipoUsuarioUpdate);

        /// <summary>
        /// Delta um tipo de usuario existente
        /// </summary>
        /// <param name="id">id do tipo de usuario deletado</param>
        void Deletar(int id);
    }
}
