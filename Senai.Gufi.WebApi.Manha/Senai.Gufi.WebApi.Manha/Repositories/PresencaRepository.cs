using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Manha.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {
        GufiContext ctx = new GufiContext();

        public void Inscricao(Presenca novaPresenca)
        {
            novaPresenca.IdPresenca = 0;
            novaPresenca.Situacao = "Aguardando";
            int verificacao = VerificarseEstaInscrito(novaPresenca);
            if(verificacao == 0)
            {
                ctx.Presenca.Add(novaPresenca);
                ctx.SaveChanges();
            }
        }

        public List<Presenca> Listar()
        {
            return ctx.Presenca.ToList();
        }

        public List<Presenca> ListarMeusEventos(int id)
        {
            return ctx.Presenca.Where(p => p.IdUsuario == id).ToList();
        }

        public int VerificarseEstaInscrito(Presenca novaPresenca)
        {
            List<Presenca> presencas = ListarMeusEventos(Convert.ToInt32(novaPresenca.IdUsuario));
            int verificacao = 0;
            foreach (var presenca in presencas)
            {
                if (presenca.IdEvento == novaPresenca.IdEvento)
                {
                    verificacao++;
                }
            }
            return verificacao;
        }
    }
}
