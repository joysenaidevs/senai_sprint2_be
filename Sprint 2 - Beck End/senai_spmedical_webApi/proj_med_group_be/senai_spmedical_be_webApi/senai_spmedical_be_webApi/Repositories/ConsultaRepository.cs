using Microsoft.EntityFrameworkCore;
using senai_spmedical_be_webApi.Contexts;
using senai_spmedical_be_webApi.Domains;
using senai_spmedical_be_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedical_be_webApi.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        /// <summary>
        /// Objeto contexto que será chamado o EF Core
        /// </summary>
        MedicalContext ctx = new MedicalContext();
        public void Atualizar(int id, Consulta consultaUpdate)
        {
            // criamos um objeto e chamamos o método BuscarPorId 
            //busca uma consulta através do seu id
            //Consulta buscarConsulta = BuscarPorId(id);

            //verifica se a consulta foi informada
            if (consultaUpdate.Situacao != null)
            {
                // atribui novos valores
                consultaUpdate.Situacao = consultaUpdate.Situacao;
            }

            //atualiza a consulta buscada
            ctx.Consultas.Update(consultaUpdate);

            // salva as informaçoes no banco de dados
            ctx.SaveChanges();
        }

        public void AtualizarStatus(int id, string status)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Busca uma consulta através do seu id 
        /// </summary>
        /// <param name="id">id da consulta que será buscada</param>
        /// <returns>retorna um status code 200 com a consulta buscada</returns>
        public Consulta BuscarPorId(int id)
        {
            //retorna a primeira consulta encontrada para o ID informado
            return ctx.Consultas.FirstOrDefault(consulta => consulta.IdConsulta == id);
        }

        /// <summary>
        /// Cadastra uma nova consulta
        /// </summary>
        /// <param name="novaConsulta">objeto para a nova consulta</param>
        public void Cadastrar(Consulta novaConsulta)
        {
            // para cadastrar usamos o Add
            ctx.Consultas.Add(novaConsulta);

            //vamos salvar essa atualizacoes, informacoes e alteracoes para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// deleta uma consulta
        /// </summary>
        /// <param name="id"> consulta deletada através do seu id</param>
        public void Deletar(int id)
        {
            //// buscou a consulta através do seu id
            //Consulta ConsultaBuscada = BuscarPorId(id);

            //// remove a consulta buscada
            //ctx.Consultas.Remove(ConsultaBuscada);

            //// salva as informacoes e alteracoes para gravar no banco de dados
            //ctx.SaveChanges();

            // remove a consulta buscada
            ctx.Consultas.Remove(BuscarPorId(id));

            // salva as alteracoes
            ctx.SaveChanges();


        }

        /// <summary>
        /// Lista todas as consultas
        /// </summary>
        /// <returns>Uma Lista das consultas</returns>
        public List<Consulta> Listar()
        {

            //ctx.Consultas.ToList();
            // Retorna uma lista de consultas
            return ctx.Consultas.ToList();
        }

        public List<Consulta> ListarAgenda(int id)
        {
            return ctx.Consultas
                //busca as informações da consulta que o paciente vai agendar
                .Include(c => c.IdProntuarioNavigation)

                // busca as informacoes do medico que vai realizar a consulta
                .Include(c => c.IdMedicoNavigation)

                .Include(c => c.IdMedicoNavigation.IdEspecialidadeNavigation)

                .Include(c => c.IdMedicoNavigation.Consulta)

                // Estabelece como parâmetro de consulta o ID do usuário recebido
                .Where(c => c.IdProntuarioNavigation.IdUsuario == id ||  c.IdMedicoNavigation.IdUsuario == id)

                .Select(c => new Consulta
                {
                    IdConsulta = c.IdConsulta,
                    DataConsulta = c.DataConsulta,
                    Situacao = c.Situacao,

                    IdProntuarioNavigation = new Prontuario
                    {
                        IdProntuario = c.IdProntuarioNavigation.IdProntuario,
                        IdUsuario = c.IdProntuarioNavigation.IdUsuario,
                        NomeProntuario = c.IdProntuarioNavigation.NomeProntuario,
                    },

                    IdMedicoNavigation = new Medico
                    {
                        IdMedico = c.IdMedicoNavigation.IdMedico,
                        IdUsuario = c.IdMedicoNavigation.IdUsuario,
                        NomeMedico = c.IdMedicoNavigation.NomeMedico,
                        IdEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.IdEspecialidade
                    }
                })

            .Where(c => c.IdProntuarioNavigation.IdUsuario == id || c.IdMedicoNavigation.IdUsuario == id)
            .ToList();

            //return ctx.Consultas.FirstOrDefault(consulta => consulta.IdConsulta == id);
        }

        public List<Consulta> ListarMinhas(int id)
        {
            // listar todas as consultas
            // return ctx.Consultas.ToList();

            return ctx.Consultas
            // adiciona na busca as informações da consulta que o paciente vai agendar
            .Include(c => c.IdProntuarioNavigation)

            // adiciona na busca as informações da consula que o medico vai realizar
            .Include(c => c.IdMedicoNavigation)

            //Adiciona na busca o Medico e a sua especialidade
            .Include(c => c.IdMedicoNavigation.IdEspecialidade)

            // Estabelece como parâmetro de consulta o ID do usuário recebido
            .Where(c => c.IdProntuarioNavigation.IdUsuario == id)

            .Where(c => c.IdProntuarioNavigation.IdUsuario == id || c.IdMedicoNavigation.IdUsuario == id)

            .ToList();
        }

        public void MinhasConsultas(Consulta minhaConsulta)
        {
            throw new NotImplementedException();
        }
    }
}
