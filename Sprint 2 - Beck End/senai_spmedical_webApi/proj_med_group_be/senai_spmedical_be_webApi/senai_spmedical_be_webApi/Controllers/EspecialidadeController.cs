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
    /// Controlador responsavel pelos endpoints consultas
    /// </summary>


    // define que a api sera no formato json
    [Produces("application/json")]

    // define  a rota (http://localhost:5000/api/especialidades)
    [Route("api/[controller]")]

    // controlador de api
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        // Criar um objeto que irá receber todos os métodos da interface
        private IEspecialidadeRepository _especialidadeRepository;



        // iremos inicializar o objeto através de um construtor (ctor)
        /// <summary>
        /// Instancia o objeto _consultaRepository para que haja referencia aos métodos do repositorio
        /// </summary>
        public EspecialidadeController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }


        /// <summary>
        /// Lista todas as especialidades
        /// </summary>
        /// <returns>retorna uma lista de especialidadde e StatusCode - 200</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // tratamento de excessoes
            try
            {
                // retorna uma lista de especiliadades fazendo a chamada para o método
                return Ok(_especialidadeRepository.Listar());
            }
            catch (Exception ex)
            {
                // retorna um badrequest (statuscode 400 - a requisição nao deu certo)
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra uma nova especialidade
        /// </summary>
        /// <param name="novaEspecialidade">objeto novaEspecialidade que era cadastrada</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Especialidade novaEspecialidade)
        {
            //tratamento de excessao
            try
            {
                _especialidadeRepository.Cadastrar(novaEspecialidade);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                // retorna um BadReques (StatusCode 400)
                return BadRequest(ex);          
            }
        }


        /// <summary>
        /// retorna uma especialidade através do seu id
        /// </summary>
        /// <param name="id">objeto da especialidade que sera buscada</param>
        /// <returns>retorna uma especiadade buscada e status code 200</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // tratamento de dados
            try
            {
                //retorna a resposta da requisicao fazendo a chamada para o método
                return Ok(_especialidadeRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                // retorna uma exception e um StatusCode 400 - BadRequest
                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Atualiza a especialidade através do seu id
        /// </summary>
        /// <param name="id">id da especialidade buscada</param>
        /// <param name="especialidadeUpdate">objeto especialidade com novas infrmacoes</param>
        /// <returns>retorna uma especialidade atualizada e StatusCode 204</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Especialidade especialidadeUpdate)
        {
            try
            {
                //faz a chamada para o metodo
                _especialidadeRepository.Atualizar(id, especialidadeUpdate);

                //retorna um statuscode
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                //retorna um status code 400
                return BadRequest(ex);
                
            }
        }


        
        [HttpDelete("{id}")]
        public IActionResult Del(int id)
        {
            // tratamento de excessao
            try
            {
                // fazemos a chamada para o método
                _especialidadeRepository.Deletar(id);

                //rotorna um 204
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                //retorna um statuscode 400
                return BadRequest(ex);
            }
        }
    }

}
                                                                       