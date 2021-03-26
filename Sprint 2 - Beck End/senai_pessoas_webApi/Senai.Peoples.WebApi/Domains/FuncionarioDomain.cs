using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domains
{
    /// <summary>
    /// classe que representa a entidade funcionarios
    /// </summary>
    public class FuncionarioDomain
    {
        public int idFuncionario { get; set; }
        public string nome { get; set; }
        public string sobreNome { get; set; }
    }
}
