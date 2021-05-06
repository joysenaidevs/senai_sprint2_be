using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    // o tipo de resposta da api sera json
    [Produces("application/json")]
    // a rota que uma requisição será no formato domínio/api/nomeController
    //ex: http://localhost:5000/api/habilidades
    [Route("api/[controller]")]
    // define que é um controlador api
    [ApiController]
    public class HabilidadesController : ControllerBase
    {
        /// <summary>
        /// Objeto _habilidadeRepository que irá receber todos os métodos  definidos na interface
        /// </summary>
        private IHabilidadeRepository _habilidadeRepository { get; set; }

        public HabilidadesController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            // retorna a resposta da aquisição
            return Ok(_habilidadeRepository.Listar());
        }

        /// <summary>
        /// Busca um estúdio através o seu ID
        /// </summary>
        /// <param name="id">ID da habilidade que será buscada</param>
        /// <returns>uma habilidade encontrada</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_habilidadeRepository.BuscarPorId(id));   
        }


        /// <summary>
        /// Cadastra uma nova habilidade
        /// </summary>
        /// <param name="novaHabilidade">objeto que será cadastrado</param>
        /// <returns>status code 201</returns>
        [HttpPost]
        public IActionResult Post(Habilidade novaHabilidade)
        {
            _habilidadeRepository.Cadastrar(novaHabilidade);

            return StatusCode(201);
        }


        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        /// <param name="id">ID da habilidade que sera atualizada</param>
        /// <param name="habilidadeUpdate">objeto com as novas informações</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(int id, Habilidade habilidadeUpdate)
        {
            // chama o método
            _habilidadeRepository.Atualizar(id, habilidadeUpdate);

            return StatusCode(204);
        }


        /// <summary>
        /// Deleta uma habilidade existente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}"]
        public IActionResult Delete(int id)
        {
            // faz a chamad apara o método
            _habilidadeRepository.Deletar(id);

            // retorna o status code
            return StatusCode(204);
        }


        /// <summary>
        /// lista as habilidades com as suas respectivas habilidades
        /// </summary>
        /// <returns>retorna um status code e uma lista de habilidades
        [HttpGet("habilidades")]
        public IActionResult GetHability()
        {
            return Ok(_habilidadeRepository.ListarHabilidade());
        }
    }
}
