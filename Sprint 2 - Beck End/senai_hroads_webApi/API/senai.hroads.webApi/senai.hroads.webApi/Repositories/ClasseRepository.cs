using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    
    public class ClasseRepository : IClasseRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(int id, Classe classeUpdate)
        {
            // buscaa classe através do id
            Classe classeSearch = ctx.Classes.Find(id);

            // verifica se o nome da classe foi informada
            if (classeUpdate.Nome != null)
            {

                //atribui os novos valores aos campos existentes
                classeSearch.Nome = classeUpdate.Nome;
            }

            // atualiza o personagem q foi buscado
            ctx.Classes.Update(classeSearch);

            // salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Classe BuscarPorId(int id)
        {
            return ctx.Classes.FirstOrDefault(c => c.IdClasse == id);
        }

        public void Cadastrar(Classe novaClasse)
        {
            ctx.Classes.Add(novaClasse);
        }

        public void Deletar(int id)
        {
            Classe classeBuscada = ctx.Classes.Find(id);

            ctx.Classes.Remove(classeBuscada);

            ctx.SaveChanges();
        }

        public List<Classe> Listar()
        {
            return ctx.Classes.ToList();
        }

        public List<Classe> ListarClasse()
        {
            return ctx.Classes.Include(e => e.ClasseHabilidades).ToList();
        }
    }
}
