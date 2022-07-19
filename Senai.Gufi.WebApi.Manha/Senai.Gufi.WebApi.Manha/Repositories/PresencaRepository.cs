using Microsoft.EntityFrameworkCore;
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
        private readonly GufiContext _context;

        public PresencaRepository(GufiContext context)
        {
            _context = context;
        }

        public async Task Inscricao(Presenca novaPresenca)
        {
            int verificacao = await VerificarseEstaInscrito(novaPresenca);
            if (verificacao == 0)
            {
                await _context.Presenca.AddAsync(novaPresenca);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Presenca>> Listar()
        {
            return await _context.Presenca.ToListAsync();
        }

        public async Task<List<Presenca>> ListarMeusEventos(int id)
        {
            return await _context.Presenca.Where(p => p.IdUsuario == id).ToListAsync();
        }

        public async Task<int> VerificarseEstaInscrito(Presenca novaPresenca)
        {
            var presencas = await ListarMeusEventos(Convert.ToInt32(novaPresenca.IdUsuario));
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
