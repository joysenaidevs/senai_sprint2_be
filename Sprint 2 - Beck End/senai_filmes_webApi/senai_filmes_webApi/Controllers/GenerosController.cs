using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using senai_filmes_webApi.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/// <summary>
/// Esta classe é um controller responsavel pelos endpoints(urls) referentes aos generos
/// </summary>
namespace senai_filmes_webApi.Controllers
{
    // define que o tipo de resposta da API é no formato json
    [Produces("application/json")]

    // define que a rota de uma requisição será neste formato dominio/api/nomeController
    //ex: http://localhost:5000/api/Generos
    [Route("api/[controller]")]

    // define que é um controlador de API 
    [ApiController]
    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// objeto chamado _generoRepository irá receber todos os métodos definidos na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }


        /// <summary>
        /// instancia o  objeto _generoRepository para que haja referencia aos métodos no repositorio
        /// </summary>
        public GenerosController()
        {
            // instaciamos o objeto, trazendo a implementação desses métodos
            _generoRepository = new GeneroRepository();
        }


        /// <summary>
        /// Lista todos os generos
        /// </summary>
        /// <returns>retorna uma lista de generos e um status code </returns>
        /// dominio 
        /// http://localhost/api/generos
        [HttpGet]
        public IActionResult Get()
        {
            //vamos retornar uma lista de generos
            //   trazendo a lista de generos        chamamos nosso objeto
            // cria uma lista nomeada listaGeneros para receber os dados
            List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

            // retorna o status code (Ok) com a lista de generos no formato JsonS
            return Ok(listaGeneros);
        }

        /// <summary>
        /// busca um genero atraves do seu id
        /// </summary>
        /// <param name="id">id do genero q sera buscado</param>
        /// <returns>um genero buscado ou NotFound  caso nenhum genero seja encontrado</returns>
        /// http://localhost:5000/api/generos/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // cria o objeto generoBuscado que irá receber o genero buscado do banco de dados 
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            // verifica se o genero foi encontrado
            if (generoBuscado == null)
            {
                // caso nao seja enconttrado, retorna um status code 404 - Not Found com a mensagem personalizada 
                return NotFound("Nenhum gênero foi encontrado!");
            }

            // caso  seja encontrado, retorna o genero buscado com um status code 200 - Ok
            return Ok(generoBuscado);
        }



        /// <summary>
        /// cadastra um novo genero
        /// </summary>
        /// <param name="novoGenero">objeto novoGenero será recebido na requisição</param>
        /// <returns>vamos retornar um status code 201</returns>
        /// http://localhost5000/api/generos
        [HttpPost]

        public IActionResult Post(GeneroDomain novoGenero)
        {
            //FAZ A CHAMADA PARA O METODO .CADASTRAR()
            _generoRepository.Cadastrar(novoGenero);

            //retorna um status code 201
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um genero existente passando seu id 
        /// </summary>
        /// <param name="id">id do genero q sera atyualizado</param>
        /// <param name="generoAtualizado">objeto generoAtalizado com as novas informacoes</param>
        /// <returns>status code</returns>
        /// http://localhost:5000/api/generos/3
        [HttpPut("{id}")]

        public IActionResult PutUrl(int id, GeneroDomain generoAtualizado)
        {
            // criamos um objeto generoBuscado e vai receber o genero bscado no banco de dados 
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            // caso nao seja encontrado retorna NotFound com uma mensagem personalizada e um bool para apresentar o erro
            if (generoBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Genero não encontrado!",
                        erro = true
                    }
                    ) ;
            }

            // tentar atualizar o registro , ou seja tentar executar este codigo
            try
            {
                // fazendo a chamada para o método .AtualizarIdUrl()
                _generoRepository.AtualizarIdUrl(id, generoAtualizado);

                // retorna um status code - No Content()
                return StatusCode(204);
            }
            // caso ocorra algum erro
            catch (Exception erro)
            {
                // retorna um status 400 - BadRequest e o código do erro
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualiza um genero existente passando seu id pelo corpo da requisição
        /// </summary>
        /// <param name="generoAtualizado">objeto generoAtualizado com as novas informações </param>
        /// <returns>um status code </returns>
        [HttpPut]
        public IActionResult PutIdBody(GeneroDomain generoAtualizado)
        {
            // cria um objeto generoBuscado que irá receber o genero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(generoAtualizado.idGenero);

            // verifica se algum genero foi encontrado
            if (generoBuscado != null)
            {
                // se sim tenta atualizar o registro 
                try
                {
                    // faz a chamada para o metodo atualizaridcorpo
                    _generoRepository.AtualizarIdCorpo(generoAtualizado);

                    return NoContent();
                }
                // caso ocorra erro
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            return NotFound
            (
                new
                {
                    mensagem = "Genero não encontrado!",
                    erro = true
                }
            );
        }

        //public IActionResult PutUrl(int id, GeneroDomain generoAtualizado)
        //{
        // faz a chamada do método .AtualizarIdUrl() passando os parâmetros
        // _generoRepository.AtualizarIdUrl(id, generoAtualizado);

        // return StatusCode(204);
        // }

        /// <summary>
        /// DELETA UM GENERO EXISTENTE
        /// </summary>
        /// <param name="id">id do genero q será deletado</param>
        /// <returns>status code 204</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // faz a chamada para o método deletar
            _generoRepository.Deletar(id);
           
            return StatusCode(204);
        }

    }
}
