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
    public class ClassesController : ControllerBase
    {
        private IClasseRepository _classeRepository { get; set; }

        public ClassesController()
        {
            _classeRepository = new ClasseRepository();
        }

        // http://localhost:5000/api/classes - Listar
        [HttpGet]
        public IActionResult Get()
        {
            // retorna a resposta da aquisição
            return Ok(_classeRepository.Listar());
        }

        // http://localhost:5000/api/classes/1
        [HttpGet("{id}")] // buscar por id
        public IActionResult GetById(int id)
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_classeRepository.BuscarPorId(id));
        }

        [HttpPut] // Atualizar
        public IActionResult Put(int id, Classe classeAtualizar)
        {
            // chama o método
            _classeRepository.Atualizar(id, classeAtualizar);

            return StatusCode(204);
        }

        [HttpDelete("{id}")] // deletar
        public IActionResult Delete(int id)
        {
            // faz a chamad apara o método
            _classeRepository.Deletar(id);

            // retorna o status code
            return StatusCode(204);
        }


        [HttpGet("ClasseHabilidade")]
        public IActionResult GetHability()
        {
            return Ok(_classeRepository.ListarClasse());
        }
    }
}
