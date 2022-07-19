using Senai.Gufi.WebApi.Manha.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Manha.Interfaces
{
    public interface ITipoEventoRepository
    {
        Task<List<TipoEvento>> Listar();

        Task Cadastrar(TipoEvento novoTipoEvento);

        Task Atualizar(int id, TipoEvento tipoEventoAtualizado);

        Task Deletar(int id);

        Task<TipoEvento> BuscarPorId(int id);
    }
}
