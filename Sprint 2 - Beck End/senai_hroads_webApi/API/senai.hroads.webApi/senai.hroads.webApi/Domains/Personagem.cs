using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Personagem
    {
        public int IdPersonagem { get; set; }
        public int? IdClasse { get; set; }
        public string Nome { get; set; }
        public string CapacicadeMaximaVida { get; set; }
        public string CapacicadeMaximaMana { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public string DataCriacao { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
    }
}
