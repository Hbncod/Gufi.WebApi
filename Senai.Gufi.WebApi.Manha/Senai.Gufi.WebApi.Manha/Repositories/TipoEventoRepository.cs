using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Senai.Gufi.WebApi.Manha.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly GufiContext _context;
        public TipoEventoRepository(GufiContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, TipoEvento tipoEventoAtualizado)
        {
            TipoEvento tipoEventoBuscado = _context.TipoEvento.Find(id);

            tipoEventoBuscado.TituloTipoEvento = tipoEventoAtualizado.TituloTipoEvento;

            _context.TipoEvento.Update(tipoEventoBuscado);

            _context.SaveChanges();
        }

        public TipoEvento BuscarPorId(int id)
        {
            return _context.TipoEvento.FirstOrDefault(te => te.IdTipoEvento == id);
        }

        public void Cadastrar(TipoEvento novoTipoEvento)
        {
            _context.TipoEvento.Add(novoTipoEvento);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            _context.TipoEvento.Remove(BuscarPorId(id));

            _context.SaveChanges();
        }

        public List<TipoEvento> Listar()
        {
            return _context.TipoEvento.ToList();
        }
    }
}
