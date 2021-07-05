using senai_spmedical_be_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedical_be_webApi.Interfaces
{
    interface IProntuarioRepository
    {
        void Cadastrar(Prontuario novoProntuario);

        List<Prontuario> Listar();

        Prontuario BuscarPorId(int id);

        void Atualizar(int id, Prontuario prontuarioUpdate);

        void Deletar(int id);
    }
}
