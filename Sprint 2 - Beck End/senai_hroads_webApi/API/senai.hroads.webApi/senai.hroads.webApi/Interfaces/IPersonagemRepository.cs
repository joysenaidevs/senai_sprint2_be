using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IPersonagemRepository
    {
        List<Personagem> Listar();

        Personagem BuscarPorId(int id);

        void Cadastrar(Personagem novoPersonagem);

        void Atualizar(int id, Personagem personagemUpdate);

        void Deletar(int id);
    }
}
