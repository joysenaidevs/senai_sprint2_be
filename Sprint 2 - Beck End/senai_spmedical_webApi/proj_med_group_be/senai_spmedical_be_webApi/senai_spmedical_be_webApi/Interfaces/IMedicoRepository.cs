using senai_spmedical_be_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedical_be_webApi.Interfaces
{
    /// <summary>
    /// interface responsavel pelo repositório de medicos
    /// </summary>
    interface IMedicoRepository
    {
        /// <summary>
        /// Cadastra um novo medico
        /// </summary>
        /// <param name="novoMedico">objeto novoMedico que será cadastrado</param>
        void Cadastrar(Medico novoMedico);

        /// <summary>
        /// Lista todos os medicos
        /// </summary>
        /// <returns>uma lista de medicos cadastrados</returns>
        List<Medico> Listar();

        /// <summary>
        /// Busca um medico através do seu id
        /// </summary>
        /// <param name="id">objeto que será buscado</param>
        /// <returns>retorna o medico buscado e status code 200</returns>
        Medico BuscarPorId(int id);

        /// <summary>
        /// Atualiza um medico existente
        /// </summary>
        /// <param name="id">id do medico atualizado</param>
        /// <param name="medicoAtualizado">objeto que será atualizado</param>
        void Atualizar(int id, Medico medicoAtualizado);

        /// <summary>
        /// Deleta um medico existente através do seu id
        /// </summary>
        /// <param name="id">id do medico que será deletado</param>
        void Deletar(int id);
    }
}
