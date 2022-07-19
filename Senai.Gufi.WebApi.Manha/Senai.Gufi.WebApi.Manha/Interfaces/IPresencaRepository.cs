using Senai.Gufi.WebApi.Manha.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Manha.Interfaces
{
    public interface IPresencaRepository
    {
        Task<List<Presenca>> Listar();

        Task<List<Presenca>> ListarMeusEventos(int id);

        Task Inscricao(Presenca novaPresenca);

        Task<int> VerificarseEstaInscrito(Presenca novaPresenca);
    }
}
