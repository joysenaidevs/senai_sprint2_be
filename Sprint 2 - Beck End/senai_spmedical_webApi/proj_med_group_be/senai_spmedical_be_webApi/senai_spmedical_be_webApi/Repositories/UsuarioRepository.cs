using senai_spmedical_be_webApi.Contexts;
using senai_spmedical_be_webApi.Domains;
using senai_spmedical_be_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedical_be_webApi.Repositories
{
    public class UsuarioRepository :IUsuarioRepository 
    {
        MedicalContext ctx = new MedicalContext();

        public void Atualizar(int id, Usuario usuarioUpdate)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> Listar()
        {
            throw new NotImplementedException();
        }
    }

        public Usuario Login(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
