using senai_filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Interfaces
{
    /// <summary>
    /// Interface responsavel pelo repositório GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        //  tipo de retorno do metódo, nome do metedo, invocando uma funçao: ()
        //          tipoRetorno           NomeMetodo         (tipoParametro nomeParametro);
        //      void Cadastrar(); -- sem retorno e não recebe parâmetro
        // fim exemplo

        // tipo de retorno para método de listagem
        /// <summary>
        ///  Este metodo retorna todos os generos
        /// </summary>
        /// <returns> uma lista de generos /returns>
        List<GeneroDomain> ListarTodos(); //o repositorio GeneroRepository vai precisar listar, este ListarTodos
        // fim List


        // este metedo nao vai retornar todos -- buscando id pelo genero dele -- vamos retornar apenas um, portanto,
        // nao usamos List
        /// <summary>
        /// Busca um genero através do seu id
        /// </summary>
        /// <param name="id">id do genero que sera buscado</param>
        /// <returns> um objeto do tipo GeneroDomain </returns>
        GeneroDomain BuscarPorId(int id);
        //fim Buscar id

        
        //sem retorno   estou cadastrando um novo genero , um objeto sendo passado como parametro
        /// <summary>
        ///  Cadastrar um novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto que se chama novoGenero que será cadastrado </param>
        /// 
        ///            tipoParametro  nomeParametro
        void Cadastrar(GeneroDomain novoGenero);
        //fim cadastrar

        /// <summary>
        /// Atualiza um genero existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto genero que será atualizado com as novas informações</param>
        void AtualizarIdCorpo(GeneroDomain genero);
        //fim atualizar id

        //receber um id pela url
        /// <summary>
        /// Atualiza um genero existente, passando o id  pela url da requisição
        /// </summary>
        /// <param name="id">id do genero que será atualizado, recebido por fora do objeto</param>
        /// <param name="genero">objeto com as novas infomações</param>
        void AtualizarIdUrl(int id, GeneroDomain genero);
        // fim atualizar url


        //          PARAMETRO PARA ENCONTRAR UM DETERMINADO GENERO

        /// <summary>
        /// DELETA UM GENERO
        /// </summary>
        /// <param name="id">id do genero que será deletado</param>
        void Deletar(int id);




    }
}
