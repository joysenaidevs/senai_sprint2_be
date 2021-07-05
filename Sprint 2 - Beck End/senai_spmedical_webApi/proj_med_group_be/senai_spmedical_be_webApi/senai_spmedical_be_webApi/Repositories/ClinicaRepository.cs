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
            Clinica clinicaBuscada = ctx.Clinicas.Find(id);

            if (clinicaUpdate.RazaoSocial != null)
            {
                clinicaBuscada.RazaoSocial = clinicaUpdate.RazaoSocial;
            }
            if (clinicaUpdate.NomeFantasia != null)
            {
                clinicaBuscada.NomeFantasia = clinicaUpdate.NomeFantasia;
            }
            if (clinicaUpdate.Endereco != null)
            {
                clinicaBuscada.Endereco = clinicaUpdate.Endereco;
            }

            clinicaBuscada.HorarioFuncionamento = clinicaUpdate.HorarioFuncionamento;

            if (clinicaUpdate.Cnpj != null)
            {
                clinicaBuscada.Cnpj = clinicaUpdate.Cnpj;
            }
            

            ctx.Clinicas.Update(clinicaBuscada);

            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(int id)
        {
            // retorna clinicas para o ID informado
            return ctx.Clinicas.FirstOrDefault(c => c.IdClinica == id);


        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Clinica clinicaBuscada = ctx.Clinicas.Find(id);

            ctx.Clinicas.Remove(clinicaBuscada);

            ctx.SaveChanges();
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

       
    }
}
