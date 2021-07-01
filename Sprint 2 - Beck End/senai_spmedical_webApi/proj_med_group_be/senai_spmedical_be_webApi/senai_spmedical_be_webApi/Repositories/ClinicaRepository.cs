using senai_spmedical_be_webApi.Contexts;
using senai_spmedical_be_webApi.Domains;
using senai_spmedical_be_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedical_be_webApi.Repositories
{
    /// <summary>
    /// Classe responsavel pelas clinicas
    /// </summary>
    public class ClinicaRepository : IClinicaRepository
    {
        //objeto do tipo MedicalContext (ctx) para utilizar em todos os métodos
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        MedicalContext ctx = new MedicalContext();

        public void Atualizar(int id, Clinica clinicaUpdate)
        {
            throw new NotImplementedException();
        }

        public Clinica BuscarPorId(int id)
        {
            // retorna clinicas para o ID informado
            return ctx.Clinicas.FirstOrDefault(e => e.IdClinica == id);
            //    try
            //    {
            //        // Retora a resposta da requisição fazendo a chamada para o método
            //        return Ok(_clinicaRepository.BuscarPorId(id));
            //    }
            //    catch (Exception erro)
            //    {
            //        return BadRequest(erro);
            //    }
        }

        public void Cadastrar(Clinica novaClinica)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Listar todas as clinicas
        /// </summary>
        /// <returns>uma lista de clinicas</returns>
        public List<Clinica> Listar()
        {
            // RETORNA A LISTA DE CLINICAS
            return ctx.Clinicas.ToList();
        }

        public List<Clinica> ListarClinicas()
        {
            throw new NotImplementedException();
        }
    }
}
