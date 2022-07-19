using Senai.Gufi.WebApi.Manha.Domains;
using System.Collections.Generic;

namespace Senai.Gufi.WebApi.Manha.Interfaces
{
    public interface IPresencaRepository
    {
        List<Presenca> Listar();

        List<Presenca> ListarMeusEventos(int id);

        void Inscricao(Presenca novaPresenca);

        int VerificarseEstaInscrito(Presenca novaPresenca);
    }
}
