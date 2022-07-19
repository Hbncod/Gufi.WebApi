using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using Senai.Gufi.WebApi.Manha.Models;

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
        public IActionResult Get()
        {
            return Ok(_repository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_repository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(TipoEventoModel novoTipoEvento)
        {
            var tipoEvento = _mapper.Map<TipoEvento>(novoTipoEvento);
            _repository.Cadastrar(tipoEvento);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoEventoModel tipoEventoAtualizado)
        {
            var tipoEvento = _mapper.Map<TipoEvento>(tipoEventoAtualizado);

            _repository.Atualizar(id, tipoEvento);

            return StatusCode(204);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Deletar(id);

            return StatusCode(204);
        }
    }
}