using Senai.Gufi.WebApi.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Manha.Interfaces
{
    interface IPresencaRepository
    {
        List<Presenca> Listar();

        List<Presenca> ListarMeusEventos(int id);

        void Inscricao(Presenca novaPresenca);

        int VerificarseEstaInscrito(Presenca novaPresenca);
    }
}
