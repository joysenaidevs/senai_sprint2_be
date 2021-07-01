using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_spmedical_be_webApi.Interfaces;
using senai_spmedical_be_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedical_be_webApi.Controllers
{
    // define que a api sera no formato JSON
    [Produces("applicaton/json")]

    // Define a rota de uma requisição será no formato dominio/api/nomeController
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
            //return Ok(_clinicaRepository.Listar());

            try
            {
                // retorna a resposta da requisicao fazendo a chamada para o método
                return Ok(_clinicaRepository.Listar());
            }
            catch (Exception erro)
            {

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
            // retorna a resposta da requisicao fazendo a chamada para o método
            return Ok(_clinicaRepository.BuscarPorId(id));
        }
    }
}
