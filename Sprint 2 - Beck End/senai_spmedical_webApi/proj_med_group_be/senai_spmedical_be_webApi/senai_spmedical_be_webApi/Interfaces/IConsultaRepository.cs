using senai_spmedical_be_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedical_be_webApi.Interfaces
{
    interface IConsultaRepository
    {

        void Cadastrar(Consulta novaConsulta);

        List<Consulta> Listar();

        Consulta BuscarPorId(int id);

        void Atualizar(int id, Consulta consultaUpdate);

        void Deletar(int id);

        List<Consulta> ListarMinhas(int id);

        List<Consulta> ListarAgenda(int id);

        
    }
}
