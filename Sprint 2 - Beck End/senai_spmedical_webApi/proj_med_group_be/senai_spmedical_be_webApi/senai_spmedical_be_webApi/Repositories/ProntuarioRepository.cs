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
    public class ProntuarioRepository : IProntuarioRepository
    {
        MedicalContext ctx = new MedicalContext();

        public void Atualizar(int id, Prontuario prontuarioUpdate)
        {
            // busca um prontuario atrav´s do seu id
            Prontuario prontuarioBuscado = ctx.Prontuarios.Find(id);

            // verifica se o id do usuario foi informado
            if (prontuarioUpdate.IdUsuario != null)
            {
                //atribui os novos valores ao campos existentes
                prontuarioBuscado.IdUsuario = prontuarioUpdate.IdUsuario;
            }

            //verifica se o nome do prontuario foi informado
            if (prontuarioUpdate.NomeProntuario != null)
            {
                // atribui novos valores
                prontuarioBuscado.NomeProntuario = prontuarioUpdate.NomeProntuario;
            }

            //verifica se o RG foi informado
            if (prontuarioUpdate.Rg != null)
            {
                prontuarioBuscado.Rg = prontuarioUpdate.Rg;
            }

            // Verfica se o telefone foi infromado
            if (prontuarioUpdate.Telefone != 0)
            {
                prontuarioBuscado.Telefone = prontuarioUpdate.Telefone;
            }

            //verifica se o endereco foi informado
            if (prontuarioUpdate.Endereco != null)
            {
                prontuarioBuscado.Endereco = prontuarioUpdate.Endereco;
            }

            // verifica se o cpf foi informado
            if (prontuarioUpdate.Cpf != null)
            {
                prontuarioBuscado.Cpf = prontuarioUpdate.Cpf;
            }

            // Atualiza o prontuario que foi buscado
            ctx.Prontuarios.Update(prontuarioBuscado);

            //salva as informacoes gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Buscar um prontuario através do seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Prontuario BuscarPorId(int id)
        {
            // Retorna a primeira presença encontrada para o ID informado
            return ctx.Prontuarios.FirstOrDefault(p => p.IdProntuario == id);
        }

        /// <summary>
        /// Cadastrar um prontuario
        /// </summary>
        /// <param name="novoProntuario">objeto que será cadastrado</param>
        public void Cadastrar(Prontuario novoProntuario)
        {
            ctx.Prontuarios.Add(novoProntuario);

            ctx.SaveChanges();
        }


        public void Deletar(int id)
        {
            // Busca um prontuario através do id
            Prontuario prontuarioBuscado = ctx.Prontuarios.Find(id);

            // Remove o prontuario que foi buscado
            ctx.Prontuarios.Remove(prontuarioBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista de prontuarios
        /// </summary>
        /// <returns>retorna uma lista de prontuarios</returns>
        public List<Prontuario> Listar()
        {
            return ctx.Prontuarios

                .Include(p => p.IdUsuarioNavigation)
                .Select(p => new Prontuario
                {
                    IdUsuario = p.IdUsuario,
                    IdProntuario = p.IdProntuario,
                    NomeProntuario = p.NomeProntuario,
                    DataNascimento = p.DataNascimento,
                    Telefone = p.Telefone,
                    Rg = p.Rg,
                    Cpf = p.Cpf,
                    Endereco = p.Endereco
                })

                .ToList();
        }
    }
}
