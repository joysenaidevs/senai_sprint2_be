using senai_spmedical_be_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedical_be_webApi.Interfaces
{
    /// <summary>
    /// Interface responsavel pelas ClinicasRepository
    /// </summary>
    interface IClinicaRepository
    {
        /// <summary>
        /// Lista todas as clinicas
        /// </summary>
        /// <returns>Uma lista de clinicas com statuscode 200</returns>
        List<Clinica> Listar();

        /// <summary>
        /// Cadastra uma nova clinica
        /// </summary>
        /// <param name="novaClinica">objeto que sera cadastrado</param>
        void Cadastrar(Clinica novaClinica);

        /// <summary>
        /// Busca uma clinica através do seu id
        /// </summary>
        /// <param name="id">Id da clinica que será buscada</param>
        /// <returns>uma clinica buscada</returns>
        Clinica BuscarPorId(int id);

        /// <summary>
        /// Atualiza uma clinica existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clinicaUpdate"></param>
        void Atualizar(int id, Clinica clinicaUpdate);


        /// <summary>
        /// Deleta uma clinica
        /// </summary>
        /// <param name="id">Id da calinica que será deletada</param>
        void Deletar(int id);


        /// <summary>
        /// Lista todas as clinicas com seus respectivos medicos
        /// </summary>
        /// <returns>Uma lista de clinicas com seus medicos</returns>
        /// metódo a parte, relacionando duas entidades ou mais
        List<Clinica> ListarClinicas();
    }
}
