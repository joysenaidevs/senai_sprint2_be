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

    // http://localhost:5000/api/Funcionarios
    [Route("api/[controller]")]

    // controlador API
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        /// <summary>
        /// _funcionarioRepository = vai receber todos os metodos definidos na interface IFuncionarioRepository
        /// </summary>
        private IFuncionarioRepository _funcionarioRepository { get; set; }

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

    }
}
