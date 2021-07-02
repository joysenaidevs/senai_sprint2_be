using senai_spmedical_be_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedical_be_webApi.Interfaces
{
    interface IConsultaRepository
    {

        /// <summary>
        /// Cadastra uma nova consulta
        /// </summary>
        /// <param name="novaConsulta">objeto novaConsulta cadastrada</param>
        void Cadastrar(Consulta novaConsulta);

        /// <summary>
        /// Listar uma consulta
        /// </summary>
        /// <returns>uma lista de consultas</returns>
        List<Consulta> Listar();

        /// <summary>
        /// Buscar consulta através do seu id
        /// </summary>
        /// <param name="id">id da consulta buscada</param>
        /// <returns></returns>
        Consulta BuscarPorId(int id);

        /// <summary>
        /// Atualiza uma consulta existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="consultaUpdate"></param>
        void Atualizar(int id, Consulta consultaUpdate);

        /// <summary>
        /// Deleta uma consulta existente
        /// </summary>
        /// <param name="id">id da consulta deletada</param>
        void Deletar(int id);

        /// <summary>
        /// Listar todas as consultas de um determnado paciente
        /// </summary>
        /// <param name="id">id do usuario que faz a consulta</param>
        /// <returns>retorna uma lista de consultas</returns>
        List<Consulta> ListarMinhas(int id);

        /// <summary>
        /// Lista a agenda do admnistrador
        /// </summary>
        /// <param name="id">objeto com as informacoes</param>
        /// <returns>retorna uma  lista de agendas</returns>
        List<Consulta> ListarAgenda(int id);

        /// <summary>
        /// cria uma nova consulta
        /// </summary>
        /// <param name="minhaConsulta"></param>
        void MinhasConsultas(Consulta minhaConsulta);

        /// <summary>
        /// Altera o status da consulta
        /// </summary>
        /// <param name="id">id da consulta que tera a situacao alterada</param>
        /// <param name="status">Parâmetro que atualiza o situação da consulta para 1 - Agendada, 2 - Cancelada </param>
        void AtualizarStatus(int id, string status);

    }
}
