using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {
        HroadsContext contex = new HroadsContext();
        public void Atualizar(int id, Personagem personagemUpdate)
        {
            // busca um personagem através do id
            Personagem personagemSearch = contex.Personagens.Find(id);

            // verifica se o nome do personagem foi informado
            if (personagemUpdate.Nome != null)
            {

                //atribui os novos valores aos campos existentes
                personagemSearch.Nome = personagemUpdate.Nome;
            }

            // atualiza o personagem q foi buscado
            contex.Personagens.Update(personagemSearch);

            // salva as informações para serem gravadas no banco de dados
            contex.SaveChanges();
        }

        public Personagem BuscarPorId(int id)
        {
            return contex.Personagens.FirstOrDefault(p => p.IdPersonagem == id);
        }

        public void Cadastrar(Personagem novoPersonagem)
        {
            contex.Personagens.Add(novoPersonagem);

            contex.SaveChanges();
        }

        public void Deletar(int id)
        {
            Personagem personagemBuscado = contex.Personagens.Find(id);

            contex.Personagens.Remove(personagemBuscado);

            contex.SaveChanges();
        }

        public List<Personagem> Listar()
        {
            return contex.Personagens.ToList();
        }
    }
}
