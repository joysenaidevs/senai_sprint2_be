using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Domains
{
    public class FilmesDomain
    {
        public int idFilme { get; set; }
        public int idGenero { get; set; }
        public string tituloFilme { get; set; }
    }
}
