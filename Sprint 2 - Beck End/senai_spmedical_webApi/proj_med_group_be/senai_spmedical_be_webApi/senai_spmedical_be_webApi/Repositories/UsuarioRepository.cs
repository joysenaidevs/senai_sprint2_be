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
    public class UsuarioRepository :IUsuarioRepository 
    {
        MedicalContext ctx = new MedicalContext();


        public void Atualizar(int id, Usuario usuarioUpdate)
        {
            // Busca um usuário através do id
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            // Verifica se o nome do usuário foi informado
            if (usuarioUpdate.NomeUsuario != null)
            {
                // Atribui os novos valores ao campos existentes
                usuarioBuscado.NomeUsuario = usuarioUpdate.NomeUsuario;
            }

            // Verifica se o e-mail do usuário foi informado
            if (usuarioUpdate.Email != null)
            {
                // Atribui os novos valores ao campos existentes
                usuarioBuscado.Email = usuarioUpdate.Email;
            }

            // Verifica se a senha do usuário foi informado
            if (usuarioUpdate.Senha != null)
            {
                // Atribui os novos valores ao campos existentes
                usuarioBuscado.Senha = usuarioUpdate.Senha;
            }

            // Atualiza o tipo de usuário que foi buscado
            ctx.Usuarios.Update(usuarioBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }


        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios
               .Include(u => u.IdTipoUsuarioNavigation)

               .Select(u => new Usuario
               {
                   IdUsuario = u.IdUsuario,
                   Email = u.Email,

                   IdTipoUsuarioNavigation = new TipoUsuario
                   {
                       IdTipoUsuario = u.IdTipoUsuarioNavigation.IdTipoUsuario,
                       NomeTipoUsuario = u.IdTipoUsuarioNavigation.NomeTipoUsuario
                   }
               })
               .FirstOrDefault(u => u.IdUsuario == id);
        }
        public Medico BuscarMedicoId(int id)
        {
            return ctx.Medicos.FirstOrDefault(u => u.IdUsuario == id);
        }

        public Prontuario BuscarProntuarioId(int id)
        {
            return ctx.Prontuarios.FirstOrDefault(u => u.IdUsuario == id);
        }



        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        public void Cadastrar(Usuario novoUsuario)
        {

            // Adiciona este novoUsuario
            ctx.Usuarios.Add(novoUsuario);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será deletado</param>
        public void Deletar(int id)
        {
            // Remove o tipo de usuário que foi buscado
            ctx.Usuarios.Remove(BuscarPorId(id));

            // Salva as alterações
            ctx.SaveChanges();
        }


        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        public List<Usuario> Listar()
        {
            // Retorna uma lista com todas as informações dos tipos de usuários, exceto as senhas
            return ctx.Usuarios
                .Select(u => new Usuario()
                {
                    IdUsuario = u.IdUsuario,
                    NomeUsuario = u.NomeUsuario,
                    Email = u.Email,
                    IdTipoUsuario = u.IdTipoUsuario,

                    IdTipoUsuarioNavigation = new TipoUsuario()
                    {
                        IdTipoUsuario = u.IdTipoUsuarioNavigation.IdTipoUsuario,
                        NomeTipoUsuario = u.IdTipoUsuarioNavigation.NomeTipoUsuario
                    }
                })
                .ToList();
        }




        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">e-mail do usuário</param>
        /// <param name="senha">senha do usuário</param>
        /// <returns>Um objeto do tipo Usuario que foi buscado</returns>ns>
        public Usuario Login(string email, string senha)
        {
            // Retorna o usuário encontrado através do e-mail e da senha
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }

}

