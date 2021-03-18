using senai_filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Interfaces
{
    public interface IFilmesRepository
    {

        //  tipo de retorno do metódo, nome do metedo, invocando uma funçao: ()
        //          tipoRetorno           NomeMetodo         (tipoParametro nomeParametro);
        //      void Cadastrar(); -- sem retorno e não recebe parâmetro
        // fim exemplo


        // Este metodo retorna todos os Filmes
        List<FilmesDomain> ListarTodos();


        // Busca um filme através do seu id
        FilmesDomain BuscarPorId(int id);

        // Cadastra um novo filme
        void Cadastrar(FilmesDomain novoFilme);

        // Atualiza um filme existente passando o id pelo corpo da requisição
        void AtualizarIdCorpo(FilmesDomain titulo);

        // deleta um filme , passando como parametro o id do filme que será deletado
        void Deletar(int id);
    }
}
