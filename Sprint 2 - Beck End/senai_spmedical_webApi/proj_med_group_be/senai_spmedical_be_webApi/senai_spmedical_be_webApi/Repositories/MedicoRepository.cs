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
    public class MedicoRepository : IMedicoRepository
    {
        MedicalContext ctx = new MedicalContext();

        public void Atualizar(int id, Medico medicoAtualizado)
        {
            //atualiza um medico buscado
            ctx.Medicos.Update(medicoAtualizado);

            // salva as informaçoes no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Buscar um medico através do seu id
        /// </summary>
        /// <param name="id">id do medico que sera buscada</param>
        /// <returns>retorna um medico buscado e status code 200 </returns>
        public Medico BuscarPorId(int id)
        {
            return ctx.Medicos.FirstOrDefault(medico => medico.IdMedico == id);
        }


        /// <summary>
        /// Cadastra um novo medico
        /// </summary>
        /// <param name="novoMedico">objeto que será cadastrado</param>
        public void Cadastrar(Medico novoMedico)
        {
            ctx.Medicos.Add(novoMedico);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um medico existente
        /// </summary>
        /// <param name="id">id do objeto que será deletado</param>
        public void Deletar(int id)
        {
            Medico medicoBuscado = ctx.Medicos.Find(id);

            ctx.Medicos.Remove(medicoBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os medicos
        /// </summary>
        /// <returns>uma lista de medicos e um status code 200</returns>

        public List<Medico> Listar()
        {
            return ctx.Medicos
                .Include(m => m.IdEspecialidadeNavigation)

                .Include(m => m.IdClinicaNavigation)

                .Select(m => new Medico
                {
                    IdMedico = m.IdMedico,
                    NomeMedico = m.NomeMedico,
                   

                    IdEspecialidadeNavigation = new Especialidade
                    {
                        IdEspecialidade = m.IdEspecialidadeNavigation.IdEspecialidade,
                       
                    },

                    IdClinicaNavigation = new Clinica
                    {
                        IdClinica = m.IdClinicaNavigation.IdClinica,
                        NomeFantasia = m.IdClinicaNavigation.NomeFantasia
                    }

                })

                .ToList();
        }
    }
}
