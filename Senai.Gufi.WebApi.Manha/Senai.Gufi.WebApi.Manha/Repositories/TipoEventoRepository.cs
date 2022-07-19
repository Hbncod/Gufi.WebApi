using Microsoft.EntityFrameworkCore;
using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Manha.Repositories
{
    internal class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly GufiContext _context;
        public TipoEventoRepository(GufiContext context)
        {
            _context = context;
        }

        public async Task Atualizar(int id, TipoEvento tipoEventoAtualizado)
        {
            var tipoEventoBuscado = await _context.TipoEvento.FindAsync(id);

            tipoEventoBuscado.TituloTipoEvento = tipoEventoAtualizado.TituloTipoEvento;

            _context.TipoEvento.Attach(tipoEventoBuscado);

            await _context.SaveChangesAsync();
        }

        public async Task<TipoEvento> BuscarPorId(int id)
        {
            return await _context.TipoEvento.FirstOrDefaultAsync(x => x.IdTipoEvento == id);
        }

        public async Task Cadastrar(TipoEvento novoTipoEvento)
        {
            await _context.TipoEvento.AddAsync(novoTipoEvento);

            await _context.SaveChangesAsync();
        }

        public async Task Deletar(int id)
        {
            _context.TipoEvento.Remove(await BuscarPorId(id));

            await _context.SaveChangesAsync();
        }

        public async Task<List<TipoEvento>> Listar()
        {
            return await _context.TipoEvento.ToListAsync();
        }
    }
}
