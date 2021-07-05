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
    /// repositório responsavel por TipoUsuario
    /// </summary>
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto que será chamado o EF Core
        /// </summary>
        MedicalContext ctx = new  MedicalContext();

        public void Atualizar(int id, TipoUsuario tipoUsuarioUpdate)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            if (tipoUsuarioUpdate.NomeTipoUsuario!= null)
            {
                tipoUsuarioBuscado.NomeTipoUsuario = tipoUsuarioUpdate.NomeTipoUsuario;
            }

            ctx.TipoUsuarios.Update(tipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(t => t.IdTipoUsuario == id);
        }

        /// <summary>
        /// Cadastra um novo tipo de usuario
        /// </summary>
        /// <param name="novoTipoUsuario">objeto novo tipo de usuario cadastrado</param>
        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            //ctx.TipoUsuarios.Add(novoTipoUsuario);
            ctx.TipoUsuarios.Add(novoTipoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // remove a consulta buscada
            ctx.TipoUsuarios.Remove(BuscarPorId(id));

            // salva as alteracoes
            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
