using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    /// <summary>
    /// controllers responsaveis  pelos endpoints referente aos funcionarios
    /// </summary>
namespace Senai.Peoples.WebApi.Controllers
{
    // o tipo de resposta da API será no formato json
     [Produces("application/json")]

    // http://localhost:44336/api/Funcionarios
    [Route("api/[controller]")]

    // controlador API
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        /// <summary>
        /// _funcionarioRepository = vai receber todos os metodos definidos na interface IFuncionarioRepository
        /// </summary>
        private IFuncionarioRepository  _funcionarioRepository { get; set; }

        public FuncionariosController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }


        /// <summary>
        /// dominio/api/funcionarios
        /// </summary>
        /// <returns>a lista de funcionarios e um status code</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            List<FuncionarioDomain> listaFuncionarios = _funcionarioRepository.ListarTodos();

            return Ok(listaFuncionarios);
        }

        //  https://localhost:44335/api/funcionarios/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            //verifica se nenhum funcionario foi encontrado
            if (funcionarioBuscado == null)
            {
                return NotFound("Este funcionario não consta no sistema!");
            }

            return Ok(funcionarioBuscado);
        }

        [HttpPut]
        public IActionResult PutIdBody(FuncionarioDomain funcionarioAtualizado)
        {
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(funcionarioAtualizado.idFuncionario);

            if (funcionarioBuscado != null)
            {
                try
                {
                    _funcionarioRepository.AtualizarIdCorpo(funcionarioAtualizado);

                    return NoContent();
                }
                catch (Exception error)
                {

                    return BadRequest(error);
                }
            }

            return NotFound
                (
                    new
                    {
                        
                        mensagem = "Funcionario não identificado!"
                    }
                );
        }

        // https://localhost:44335/api/funcionarios
        [HttpPost]
        public IActionResult Post(FuncionarioDomain novoFuncionario)
        {
            _funcionarioRepository.Cadastrar(novoFuncionario);

            return StatusCode(201);
        }


        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            _funcionarioRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
