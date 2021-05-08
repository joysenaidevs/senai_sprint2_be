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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagensController : ControllerBase
    {
        private IPersonagemRepository _personagemRepository { get; set; }

        public PersonagensController()
        {
            _personagemRepository = new PersonagemRepository();
        }


        // http://localhost:5000/api/personagens - Listar
        [HttpGet]
        public IActionResult Get()
        {
            // retorna a resposta da aquisição
            return Ok(_personagemRepository.Listar());
        }

        // http://localhost:5000/api/personagens/1
        [HttpGet("{id}")] // buscar por id
        public IActionResult GetById(int id)
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_personagemRepository.BuscarPorId(id));
        }

        [HttpPost] // cadastrar
        public IActionResult Post(Personagem novoPersonagem)
        {
            _personagemRepository.Cadastrar(novoPersonagem);

            return StatusCode(201);
        }

        [HttpPut] // Atualizar
        public IActionResult Put(int id, Personagem personagemAtualizar)
        {
            // chama o método
            _personagemRepository.Atualizar(id, personagemAtualizar);

            return StatusCode(204);
        }

        [HttpDelete("{id}")] // deletar
        public IActionResult Delete(int id)
        {
            // faz a chamad apara o método
            _personagemRepository.Deletar(id);

            // retorna o status code
            return StatusCode(204);
        }


    }
}
