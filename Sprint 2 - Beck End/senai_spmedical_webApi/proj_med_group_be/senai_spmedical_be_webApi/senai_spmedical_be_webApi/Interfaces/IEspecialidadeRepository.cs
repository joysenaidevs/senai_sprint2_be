using senai_spmedical_be_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedical_be_webApi.Interfaces
{
    interface IEspecialidadeRepository
    {
        /// <summary>
        /// Listar as especialidades
        /// </summary>
        /// <returns>uma lista de especialidades</returns>
        List<Especialidade> Listar();

        /// <summary>
        /// Cadastra uma especialidade
        /// </summary>
        /// <param name="novaEspecialidade">objeto novaEspecialidade cadastrada</param>
        void Cadastrar(Especialidade novaEspecialidade);


        /// <summary>
        /// Busca uma especialidade  através do seu id
        /// </summary>
        /// <param name="id">id da especialidade buscada</param>
        /// <returns>retorna a especialidade buscada</returns>
        Especialidade BuscarPorId(int id);


        /// <summary>
        /// Atualiza uma especialidade existente
        /// </summary>
        /// <param name="id">id da especialidade do medico</param>
        /// <param name="especialidadeUpdate">retorna uma especialidade atualizada</param>
        void Atualizar(int id, Especialidade especialidadeUpdate);

        /// <summary>
        /// Deleta uma especialidade existente
        /// </summary>
        /// <param name="id">id da especialidade</param>
        void Deletar(int id);
    }
}
