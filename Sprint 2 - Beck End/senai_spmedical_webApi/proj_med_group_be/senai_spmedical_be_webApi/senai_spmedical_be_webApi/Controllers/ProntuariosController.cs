using Microsoft.AspNetCore.Authorization;
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
    /// Controlador responsavel pelo repositorio de prontuarios
    /// </summary>

    //define que a API sera no formato json
    [Produces("application/json")]

    // define a rota da api
    //ex: http://localhost:5000/api/prontuarios
    [Route("api/[controller]")]

    // define um controlador de api
    [ApiController]
    public class ProntuariosController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _prontuarioRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IProntuarioRepository _prontuarioRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public ProntuariosController()
        {
            _prontuarioRepository = new ProntuarioRepository();
        }


        /// <summary>
        /// Lista todos os prontuarios
        /// </summary>
        /// <returns>Uma lIsta de prontuarios e um status code 200</returns>
        /// define que somento o ADM pode acessar o método
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            // tratamento de excessão
            try
            {
                // retorna a resposta da aquisicao fazendo a chamada para o metodo
                return Ok(_prontuarioRepository.Listar());
            }
            catch (Exception ex)
            {
                // retorna um status code 400
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca um prontuario através do ID
        /// </summary>
        /// <param name="id">ID da prontuario que será buscado</param>
        /// <returns>Um prontuario buscado e um status code 200 - Ok</returns>
        // Define que somente o administrador pode acessar o método
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                // Retora a resposta da requisição fazendo a chamada para o método
                return Ok(_prontuarioRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Cadastra um novo prontuario
        /// </summary>
        /// <param name="novoProntuario">Objeto novaProntuario que será cadastrada</param>
        /// <returns>Um status code 201 - Created</returns>
        // Define que somente o administrador pode acessar o método
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Prontuario novoProntuario)
        {
            try
            {
                // Faz a chamada para o método
                _prontuarioRepository.Cadastrar(novoProntuario);

                // Retorna um status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um prontuario existente
        /// </summary>
        /// <param name="id">ID da prontuario que será atualizado</param>
        /// <param name="prontuarioUpdate">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        // Define que somente o administrador pode acessar o método
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Prontuario prontuarioUpdate)
        {
            try
            {
                // Faz a chamada para o método
                _prontuarioRepository.Atualizar(id, prontuarioUpdate);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um prontuario existente
        /// </summary>
        /// <param name="id">ID da prontuario que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        // Define que somente o administrador pode acessar o método
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método
                _prontuarioRepository.Deletar(id);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
