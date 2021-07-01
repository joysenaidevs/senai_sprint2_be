using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmedical_be_webApi.Domains
{
    public partial class Prontuario
    {
        public Prontuario()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdProntuario { get; set; }
        public int? IdUsuario { get; set; }
        public string NomeProntuario { get; set; }
        public DateTime? DataNascimento { get; set; }
        public int Telefone { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }

        public virtual TipoUsuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
