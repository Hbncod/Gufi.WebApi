using Senai.Gufi.WebApi.Manha.Domains;
using System.Collections.Generic;

namespace Senai.Gufi.WebApi.Manha.Interfaces
{
    public interface ITipoEventoRepository
    {
        List<TipoEvento> Listar();

        void Cadastrar(TipoEvento novoTipoEvento);

        void Atualizar(int id, TipoEvento tipoEventoAtualizado);

        void Deletar(int id);

        TipoEvento BuscarPorId(int id);
    }
}
