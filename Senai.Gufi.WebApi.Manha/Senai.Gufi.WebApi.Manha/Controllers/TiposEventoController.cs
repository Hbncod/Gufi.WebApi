using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using Senai.Gufi.WebApi.Manha.Models;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Manha.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TiposEventoController : ControllerBase
    {
        private ITipoEventoRepository _repository { get; set; }
        private readonly IMapper _mapper;

        public TiposEventoController(ITipoEventoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.Listar());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _repository.BuscarPorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(TipoEventoModel novoTipoEvento)
        {
            var tipoEvento = _mapper.Map<TipoEvento>(novoTipoEvento);
            await _repository.Cadastrar(tipoEvento);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TipoEventoModel tipoEventoAtualizado)
        {
            var tipoEvento = _mapper.Map<TipoEvento>(tipoEventoAtualizado);

            await _repository.Atualizar(id, tipoEvento);

            return StatusCode(204);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.Deletar(id);

            return StatusCode(204);
        }
    }
}