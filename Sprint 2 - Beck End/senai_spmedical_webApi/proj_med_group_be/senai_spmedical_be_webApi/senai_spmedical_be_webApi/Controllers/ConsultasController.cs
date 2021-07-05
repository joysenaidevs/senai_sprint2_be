using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_spmedical_be_webApi.Domains;
using senai_spmedical_be_webApi.Interfaces;
using senai_spmedical_be_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;


        // <summary>
        // controlador responsavel pelas consultas e seus endpoints (urls)
        // </summary>
        //

namespace senai_spmedical_be_webApi.Controllers
{
  
    // Resposta da api no formato json
    [Produces("application/json")]

    // define  a rota (http://localhost:5000/api/consultas)
    [Route("api/[controller]")]

    // controlador de API
    [ApiController]

    [Authorize(Roles = "1")]
    public class ConsultasController : ControllerBase
    {
        // Criar um objeto que irá receber todos os métodos da interface
        private IConsultaRepository _consultasRepository { get; set; }

        // iremos inicializar o objeto através de um construtor (ctor)
        /// <summary>
        /// Instancia o objeto _consultaRepository para que haja referencia aos métodos do repositorio
        /// </summary>
        public ConsultasController()
        {
            _consultasRepository = new ConsultaRepository();
        }

        
        /// <summary>
        /// Lista de todas as consultas
        /// </summary>
        /// <returns>Lista de consulta e statuscode 200 (Ok)</returns>
        [HttpGet]           // endpoint de listagem
        [Authorize(Roles = "1")]
        public IActionResult Get()
        {
            //tratamento de excessões
            try
            {
                //retorna uma lista de consultas fazendo a chamada para o método
                return Ok(_consultasRepository.Listar());
            }
            catch (Exception ex)
            {
                // retorna um badrequest (statuscode 400 - a requisição n deu certo )
                return BadRequest(ex);
            }
        }


        /// <summary>
        /// retorna uma consulta através do seu id
        /// </summary>
        /// <param name="id">ID da consulta que será buscada</param>
        /// <returns>retorna uma consulta buscada e status code 200</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult GetById(int id)
        {
            // tratamento de excessao
            try
            {
                // retorna a resposta da requisicao fazendo a chamada para o método
                return Ok(_consultasRepository.BuscarPorId(id));
            }
            catch (Exception ex) 
            {
                // retorna uma exception e um statusCode 400 - Bad Request
                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Cadastra uma consulta
        /// </summary>
        /// <param name="novaConsulta">objeto novaConsulta que será cadastrada</param>
        /// <returns>StatusCode 201 - Created</returns>
        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Post(Consulta novaConsulta)
        {
            // tratamento de excessao
            try
            {
                //Faz chamada para o metodo
                _consultasRepository.Cadastrar(novaConsulta);

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
        /// Atualiza uma consulta existente
        /// </summary>
        /// <param name="id">od da consulta que sera atuaçizada</param>
        /// <param name="consultaAtualizada">objeto com as novas informacoes</param>
        /// <returns>status code 204 no content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Consulta consultaAtualizada)
        {
            // tratamento de excessao
            try
            {
                // faz a chamada para o metodo
                _consultasRepository.Atualizar(id, consultaAtualizada);

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
        /// Deleta uma consulta 
        /// </summary>
        /// <param name="id">id da consulta q sera deletada</param>
        /// <returns>um statuscode 204</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Del (int id)
        {
            //tratamento de excessão
            try
            {
                // faz a chamada para o método
                _consultasRepository.Deletar(id);

                //retorna um status code 204
                return StatusCode(204);

            }
            catch (Exception ex)
            {
                // retorna um status code 400
                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Lista as consultas relacionadas com o id de quem estiver logado (médico ou paciente) 
        /// </summary>
        /// <returns>Uma lista das consultas e um StatusCode 200 - Ok</returns>
        [Authorize(Roles = "2,3")]
        [HttpGet("minhas")]
        public IActionResult GetMy()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consultasRepository.ListarMinhas(idUsuario));
            }
            catch (Exception erro)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as consultas se o usuário não estiver logado!",
                    erro
                });
            }
        }

        /// <summary>
        /// Lista a agenda do medico
        /// </summary>
        /// <returns>retorna uma lista de agenda e um StatusCode 200</returns>
        [Authorize(Roles = "2")]
        [HttpGet("agenda")]
        public IActionResult GetAgenda()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consultasRepository.ListarAgenda(idUsuario));
                
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar a agenda se o usuário não estiver logado!",
                    ex
                });
            }
        }
    }
}
