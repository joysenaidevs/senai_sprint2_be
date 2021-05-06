using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    // interface responsavel por habilidades
    interface IHabilidadeRepository
    {
        /// <summary>
        /// lista todas as habilidades
        /// </summary>
        /// <returns>uma lista de habilidades</returns>
        List<Habilidade> Listar();

        /// <summary>
        /// busca uma habilidade através do seu id
        /// </summary>
        /// <param name="id">id da habilidade que sera buscada</param>
        /// <returns>uma habilidade buscada</returns>
        Habilidade BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova habilidade
        /// </summary>
        /// <param name="novaHabilidade">objeto que será cadastrado</param>
        void Cadastrar(Habilidade novaHabilidade);

        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        /// <param name="id">id da habilidade que sera atualizada</param>
        /// <param name="habilidadeUpdate">objeto habilidadeUpdate com as novas informações</param>
        void Atualizar(int id, Habilidade habilidadeUpdate);

        /// <summary>
        /// Deleta uma habilidade existente
        /// </summary>
        /// <param name="id">id da habilidade que será deletada</param>
        void Deletar(int id);


        /// <summary>
        /// Lista todas as habilidades com suas respectivas habilidades
        /// </summary>
        /// <returns>uma lista de habilidades</returns>
        List<Habilidade> ListarHabilidade();
    }
}
