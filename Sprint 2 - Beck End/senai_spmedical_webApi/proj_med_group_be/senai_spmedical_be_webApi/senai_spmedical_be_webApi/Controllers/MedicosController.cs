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
    /// Controlador responsavel por medicos 
    /// </summary>
    /// 

    // define que a api será no formato json
    [Produces("application/json")]

    // define  a rota (http://localhost:5000/api/medicos)
    [Route("api/[controller]")]

    //controlador de api
    [ApiController]
    public class MedicosController : ControllerBase
    {
        // Criar um objeto que irá receber todos os métodos da interface
        private IMedicoRepository _medicoRepository{ get; set; }


        /// <summary>
        /// Instancia o objeto _medeicoRepository para que haja referencia aos métodos do repositorio
        /// </summary>
        public MedicosController()
        {
            _medicoRepository = new MedicoRepository();
        }



        /// <summary>
        /// Lista de todos os medicos
        /// </summary>
        /// <returns>Lista de medicose statuscode 200 (Ok)</returns>
        [HttpGet]           // endpoint de listagem
        public IActionResult Get()
        {
            //tratamento de excessões
            try
            {
                //retorna uma lista de medicos fazendo a chamada para o método
                return Ok(_medicoRepository.Listar());
            }
            catch (Exception ex)
            {
                // retorna um badrequest (statuscode 400 - a requisição n deu certo )
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca um medico através do seu id
        /// </summary>
        /// <param name="id">objeto que será buscado</param>
        /// <returns>retorna o medico buscado e status code 200</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // tratamento de excessao
            try
            {
                // retorna a resposta da requisicao fazendo a chamada para o método
                return Ok(_medicoRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                // retorna uma exception e um statusCode 400 - Bad Request
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra um medico
        /// </summary>
        /// <param name="novoMedico">objeto novoMedico que será cadastrada</param>
        /// <returns>StatusCode 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Medico novoMedico)
        {
            // tratamento de excessao
            try
            {
                //Faz chamada para o metodo
                _medicoRepository.Cadastrar(novoMedico);

                //retorna status code Created
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                //retorna um bad request (status code 400)
                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Atualiza um medico existente
        /// </summary>
        /// <param name="id">id do medico que sera atualizado</param>
        /// <param name="medicoAtualizado">objeto com as novas informacoes</param>
        /// <returns>status code 204 no content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Medico medicoAtualizado)
        {
            // tratamento de excessao
            try
            {
                // faz a chamada para o metodo
                _medicoRepository.Atualizar(id, medicoAtualizado);

                //retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                // retorna um status code 400
                return BadRequest(ex);

            }
        }

        /// <summary>
        /// Deleta um nedico atraves do seu id
        /// </summary>
        /// <param name="id">id do medico que sera deletada</param>
        /// <returns>um statuscode 204</returns>
        [HttpDelete("{id}")]
        public IActionResult Del(int id)
        {
            //tratamento de excessão
            try
            {
                // faz a chamada para o método
                _medicoRepository.Deletar(id);

                //retorna um status code 204
                return StatusCode(204);

            }
            catch (Exception ex)
            {
                // retorna um status code 400
                return BadRequest(ex);
            }
        }

    }
}
