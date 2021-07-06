using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace senai_spmedical_be_webApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //adicionando um serivco para permitir a leitura dos controllers
            // define o uso de controllers

            services
                //Adiciona o service controllers
                .AddControllers()

                .AddNewtonsoftJson(options => {
                    //Igonora os loopings
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                    // ignoramos valores nullos (principalmente para junç~ão)
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;

                });

            // Adiciona o CORS ao projeto
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy",
                    builder => {
                        builder.WithOrigins("http://localhost:3000", "http://localhost:19006")
                                                                    .AllowAnyHeader()
                                                                    .AllowAnyMethod();
                    }
                );
            });

            // configurando swagger adicionando serviço
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "senai_spmedical_be_webApi", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services
             // Define a forma de autenticacao
             .AddAuthentication(options =>
             {
                 options.DefaultAuthenticateScheme = "JwtBearer";
                 options.DefaultChallengeScheme = "JwtBearer";
             })

             // Define os parametros de validacao do token
             .AddJwtBearer("JwtBearer", options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                        // Valida quem esta solicitando
                        ValidateIssuer = true,

                        // Valida quem esta recebendo
                        ValidateAudience = true,

                        // Define se o tempo de expiracao sera validado
                        ValidateLifetime = true,

                        // Forma de criptografia e ainda valida a chave de autenticacao                 // tamanho de chave precisa ser maior
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("spmedical-chave-joyce-senai")),

                        // Valida o tempo de expiracaoo do token
                        ClockSkew = TimeSpan.FromMinutes(30),

                        // Nome do issuer, de onde esta vindo
                        ValidIssuer = "spmedical_webApi",

                        // Nome do audience, para onde esta indo
                        ValidAudience = "spmedical_be.webApi"
                 };
             });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "senai_spmedical_Group");
                c.RoutePrefix = string.Empty;
            });

            
            app.UseRouting();

            // Habilita a autorizacao (o use authorization deve estar entre : UseRouting e UseAuthentication)
            app.UseAuthorization();

            // Habilita a autenticadoo
            app.UseAuthentication();

            // Define o uso de CORS
            app.UseCors("CorsPolicy");


            app.UseEndpoints(endpoints =>
            {
                // define o mapeamento dos controllers
                endpoints.MapControllers();
            });
        }
    }
}
