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
            return Ok (listaGeneros);
        }

        /// <summary>
        /// cadastra um novo genero
        /// </summary>
        /// <param name="novoGenero">objeto novoGenero será recebido na requisição</param>
        /// <returns>vamos retornar um status code 201</returns>
        /// http://localhost5000/api/generos
        [HttpPost]
        
        public IActionResult Post (GeneroDomain novoGenero)
        {
            //FAZ A CHAMADA PARA O METODO .CADASTRAR()
            _generoRepository.Cadastrar(novoGenero);

            //retorna um status code 201
            return StatusCode(201);
        }


    }
}
