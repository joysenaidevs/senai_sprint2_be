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
    /// Controllers responsaveis pelas clinicas
    /// </summary>
    /// 

    // define que a api sera no formato JSON
    [Produces("application/json")]

    // Define a rota de uma requisição será no formato dominio/api/nomeController
    //ex:http://localhost:5000/api/clinicas
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class ClinicasController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos definidos na interface IClinicaRepository
        /// </summary>
        private IClinicaRepository _clinicaRepository { get; set; }

        /// <summary>
        /// instancia para que haja referencia nos metodos implementados no repositório ClinicaRepository
        /// </summary>
        public ClinicasController()
        {

            _clinicaRepository = new ClinicaRepository();
        }


        /// <summary>
        /// Lista todas as clinicas
        /// </summary>
        /// <returns>retorna uma lista de clinicas e um status code 200</returns>
        /// http://localhost:5000/api/clinicas
        [HttpGet]
        public IActionResult Get()
        {
            //tratamento de excessao
            try
            {
                // retorna a resposta da requisicao fazendo a chamada para o método
                return Ok(_clinicaRepository.Listar());

            }
            catch (Exception erro)
            {
                //retorna um status code 400
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca umá clinica através do seu id
        /// </summary>
        /// <param name="id">ID da clinica buscada</param>
        /// <returns>uma clinica encontrada e um statuscode 200</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            // tratamento de excessao
            try
            {
                // retorna a resposta da requisicao fazendo a chamada para o método
                return Ok(_clinicaRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                // retorna uma exception e um statusCode 400 - Bad Request
                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Cadastra uma clinica
        /// </summary>
        /// <param name="novaClinica">objeto para cadastrar uma nica</param>
        /// <returns>retorna uma novva clinica</returns>
        [HttpPost]
        public IActionResult Post(Clinica novaClinica)
        {
            // tratamento de excessao
            try
            {
                //Faz chamada para o metodo
                _clinicaRepository.Cadastrar(novaClinica);

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
        /// Atualiza uma clinica através do seu id
        /// </summary>
        /// <param name="id">objeto da clinica</param>
        /// <param name="clinicaUpdate">objeto para atualizar uma clinica existente</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Clinica clinicaUpdate)
        {
            // tratamento de excessao
            try
            {
                // faz a chamada para o metodo
                _clinicaRepository.Atualizar(id, clinicaUpdate);

                //retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Não foi possivel encontrar esssa clinica",
                    ex
                });

            }
        }


        /// <summary>
        /// Deleta uma clinica existente através do seu id
        /// </summary>
        /// <param name="id">id da clincia deletada</param>
        /// <returns>retorna uma clinica existente deletada</returns>
        [HttpDelete("{id}")]
        public IActionResult Del(int id)
        {
            //tratamento de excessão
            try
            {
                // faz a chamada para o método
                _clinicaRepository.Deletar(id);

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

