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
    /// repositório responsavel pelos Repositorio Especialidade
    /// </summary>
    public class EspecialidadeRepository : IEspecialidadeRepository
    {

        ///objeto do tipo MedicalContext (ctx) para utilizar em todos os métodos
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        MedicalContext ctx = new MedicalContext();

        public void Atualizar(int id, Especialidade especialidadeUpdate)
        {
            // criamos um objeto e chamamos o método BuscarPorId 
            //busca uma especialidade através do seu id
            //Especialidade especialidadeBuscada = BuscarPorId(id);

            Especialidade especialidadeBuscada = ctx.Especialidades.Find(id);

            // verifica se a especialidade foi atualizada 
            if (especialidadeUpdate.NomeEspecialidade != null)
            {
                //atribui novos valores
                especialidadeBuscada.NomeEspecialidade = especialidadeUpdate.NomeEspecialidade;
            }
            if (especialidadeUpdate.Medicos != null)
            {
                especialidadeBuscada.Medicos = especialidadeUpdate.Medicos;
            }
            //atualiza a especialidade buscada
            ctx.Especialidades.Update(especialidadeUpdate);

            // salva as informaçoes no banco de dados
            ctx.SaveChanges();


        }

        /// <summary>
        /// Busca uma especialidade através do seu id
        /// </summary>
        /// <param name="id">id da especialidade buscada</param>
        /// <returns>retorna a especialidade do medico buscada</returns>
        public Especialidade BuscarPorId(int id)
        {
            //
            //return ctx.Especialidades.FirstOrDefault(e => e.IdEspecialidade == id);
            return ctx.Especialidades.FirstOrDefault(e => e.IdEspecialidade == id);
        }
        

        /// <summary>
        /// Cadastra uma nova especialidade
        /// </summary>
        /// <param name="novaEspecialidade">objeto para nova especialidade</param>
        public void Cadastrar(Especialidade novaEspecialidade)
        {
            // para cadastrar usamos o Add
            ctx.Especialidades.Add(novaEspecialidade);

            //vamos salvar essa atualizacoes, informacoes e alteracoes para serem gravadas no banco
            ctx.SaveChanges();
        }

        // void nao tem retorno (return)
        public void Deletar(int id)
        {
            // remove a especialidade através do seu id
            ctx.Especialidades.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista as especialidades
        /// </summary>
        /// <returns></returns>
        public List<Especialidade> Listar()
        {
            // retorna uma lista de especialidades
            return ctx.Especialidades.ToList();
        }

       
    }
}
