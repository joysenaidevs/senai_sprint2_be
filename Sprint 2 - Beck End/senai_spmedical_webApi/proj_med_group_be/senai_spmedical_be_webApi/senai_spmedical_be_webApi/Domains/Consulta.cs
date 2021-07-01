using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmedical_be_webApi.Domains
{
    public partial class Consulta
    {
        public int IdConsulta { get; set; }
        public int? IdProntuario { get; set; }
        public int? IdMedico { get; set; }
        public DateTime DataConsulta { get; set; }
        public string Situacao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Prontuario IdProntuarioNavigation { get; set; }
    }
}
