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
    /// <summary>
    /// classe responsavel pelo repositorio das habilidades
    /// </summary>
    public class HabilidadeRepository : IHabilidadeRepository
    {
        //instanciamos o contexto, para utilizar o ctx em todos os métodos
        /// <summary>
        /// Objeto contex por onde serão chamados os métodos do EF Core
        /// </summary>
        HroadsContext contex = new HroadsContext();
        public void Atualizar(int id, Habilidade habilidadeUpdate)
        {
            // busca uma habilidade através do id
            Habilidade habilidadeSearch = contex.Habilidades.Find(id);

            // verifica se o nome do estudio foi informado
             if (habilidadeUpdate.Nome != null)
             {

                //atribui os novos valores aos campos existentes
                habilidadeSearch.Nome = habilidadeUpdate.Nome;
             }

            // atualiza o estudio q foi buscado
            contex.Habilidades.Update(habilidadeSearch);
            
            // salva as informações para serem gravadas no banco de dados
            contex.SaveChanges();
        }

        public Habilidade BuscarPorId(int id)
        {
            // Retorna a primeira habilidade encontrada para o ID informado
           return contex.Habilidades.FirstOrDefault(h => h.IdHabilidade == id);
        }

        /// <summary>
        /// Cadastra uma nova habilidade
        /// </summary>
        /// <param name="novaHabilidade">objeto que sera cadastrado</param>
        public void Cadastrar(Habilidade novaHabilidade)
        {
            // Adiciona este novaHabilidade
            contex.Habilidades.Add(novaHabilidade);

            // Salva as infiormacoes para serem gravadas no banco de dados
            contex.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca uma habilidade através do seu id
            Habilidade habilidadeBuscada = contex.Habilidades.Find(id);

            // Remove a habilidade buscada
            contex.Habilidades.Remove(habilidadeBuscada);

            // Salva as alterações no banco de dados
            contex.SaveChanges();
        }

        /// <summary>
        /// Lista todas as habilidades
        /// </summary>
        /// <returns>uma lista de habilidades</returns>
        public List<Habilidade> Listar()
        {
            // retorna uma lista com todas  as informacoes de habilidades
            return contex.Habilidades.ToList();
        }

        public List<Habilidade> ListarHabilidade()
        {
            return contex.Habilidades.Include(e => e.ClasseHabilidades).ToList();
        }
    }
}
