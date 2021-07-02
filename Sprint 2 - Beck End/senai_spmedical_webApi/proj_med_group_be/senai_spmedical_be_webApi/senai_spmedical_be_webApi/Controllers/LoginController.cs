﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_spmedical_be_webApi.Domains;
using senai_spmedical_be_webApi.Interfaces;
using senai_spmedical_be_webApi.LoginViewModels;
using senai_spmedical_be_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_spmedical_be_webApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints (URLs) referentes aos Logins
    /// </summary>
    /// 

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]


    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex:
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    // Define que somente o administrador pode acessar os métodos
    //[Authorize(Roles = "1")]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Objeto _usuarioRepository que irá receber todos os métodos definidos na interface IuUsuarioRepository
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }


        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Valida o usuario
        /// </summary>
        /// <param name="login">objeto com email e senha</param>
        /// <returns>retorna</returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                // informações do usuario
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                // caso nao encontre um usuario ou email e a senha
                if (usuarioBuscado == null)
                {
                    // retorna um notFound com mensagem personalizada
                    return NotFound("Email ou senha inválidos!");
                }

                //caso seja encontrado, cria o token

                /*
                    Dependencias:

                    Criar e validar o Token:    System.IdentityModel.Tokens.Jwt
                    Integrar a autentiação :    Microsoft.AspNetCore.Authentication.JwtBearer
                   
                 */

                // criando uma variavel chamada claims do tipo arrays
                // define os dados que serao fornecidos no Token - Payload
                var claims = new[]
                {
                    // criando uma nova claim para armazenar o email do usuario
                    // PEGANDO O Email do usuario buscado do banco de dados atraves do email e da senha
                    //e esta sendo armazenado na primeira claim
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                    // armazena na claim o id do usuario autenticado
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                    // armazenando o idTipoUsuario ex: 1
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())

                    //Armazena o NomeTipoUsuario ex: Administrador
                    //new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuarioNavigation.NomeTipoUsuario)
                };

                // define o acesso ao token     gerando a chave
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("spmedical-key"));

                // definindo as credenciais do token
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                issuer:                         "spmedical_webApi",             //emissor do token
                audience:                       "spmedical_be.webApi",             // destinátario do token
                claims:                         claims,                         //dados da claim (email, idUsuario e idTipoUsuario)
                expires:                        DateTime.Now.AddMinutes(30),        // tempo de expiração
                signingCredentials:             creds                               // credenciais                           //

            );
                // retorna o Token (StatusCode 200)
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            catch (Exception ex)
            {
                // caso  seja encontrado ou ocorra algum erro , retorna a exception
                return BadRequest(ex);
            }
        }
    }
}
