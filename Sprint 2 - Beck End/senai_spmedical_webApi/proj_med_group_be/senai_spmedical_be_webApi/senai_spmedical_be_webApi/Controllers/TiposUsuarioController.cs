using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_spmedical_be_webApi.Domains;
using senai_spmedical_be_webApi.Interfaces;
using senai_spmedical_be_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedical_be_webApi.Controllers
{
    /// <summary>
    /// Controllers responsaveis pelos tipos usuarios
    /// </summary>
    


    //define que a api será no formato json
    [Produces("application/json")]

    // define a rota da api 
    // ex: http://localhost:5000/api/tiposusuarios
    [Route("api/[controller]")]

    //controlador de api
    [ApiController]
    public class TiposUsuarioController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _tipoUsuarioRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public TiposUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipo a ser cadastrado</param>
        /// <returns>Um StatusCode 201 - Created</returns>
        //[Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipoUsuario)
        {
            //tratamento de excessao
            try
            {
                //Faz chamada para o metodo
                _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

                //retorna um status code 201
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                //retoran um bad request 400
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Lista todos tipos de usuários existentes
        /// </summary>
        /// <returns>Uma lista de tipos de usuário e um StatusCode 200 - Ok</returns>
        //[Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // retorna uma lista de tipos usuarios fazendo a chamada para o método
                return Ok(_tipoUsuarioRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca um tipo de usuário pelo seu id
        /// </summary>
        /// <param name="id">Id do tipo de usuário buscado</param>
        /// <returns>Um tipo de usuario buscado e um StatusCode 200 - Ok</returns>
        //[Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_tipoUsuarioRepository.BuscarPorId(id));


            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualiza uma tipo de usuário existente
        /// </summary>
        /// <param name="id">Id do tipo de usuário a ser atualizado</param>
        /// <param name="tipoUsuarioUpdate">Objeto tipoAtualizado com as novas informações</param>
        /// <returns>Um StatusCode 204 - No Content</returns>
        //[Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario tipoUsuarioUpdate)
        {
            try
            {
                _tipoUsuarioRepository.Atualizar(id, tipoUsuarioUpdate);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta um tipo de usuário existente
        /// </summary>
        /// <param name="id">Id do tipo de usuário a ser deletado</param>
        /// <returns>Um StatusCode 204 - No Content</returns>
        //[Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _tipoUsuarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
