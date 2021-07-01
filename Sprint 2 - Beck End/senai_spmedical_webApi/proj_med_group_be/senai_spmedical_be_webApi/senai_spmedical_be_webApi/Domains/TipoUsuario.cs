using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmedical_be_webApi.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Prontuarios = new HashSet<Prontuario>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }
        public string NomeTipoUsuario { get; set; }

        public virtual ICollection<Prontuario> Prontuarios { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
