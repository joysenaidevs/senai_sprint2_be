using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        List<TipoHabilidade> Listar();

        TipoHabilidade BuscarPorId(int id);

        void Cadastrar(TipoHabilidade novoTipoHabilidade);

        void Atualizar(int id, TipoHabilidade tipoHabilidadeUpdate);

        void Deletar(int id);

        List<TipoHabilidade> ListarTipoHabilidade();
    }
}
