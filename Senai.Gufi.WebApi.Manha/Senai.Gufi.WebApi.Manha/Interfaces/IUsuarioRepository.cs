using Senai.Gufi.WebApi.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Manha.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> Listar();

        void Cadastrar(Usuario novoUsuario);

        void Atualizar(Usuario NovosDados);

        void Deletar(int idUsuarioDeletado);

        Usuario BuscarporId(int idUsuario);

        Usuario BuscarporEmaileSenha(string email, string senha);

    }
}
