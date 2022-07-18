using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using Senai.Gufi.WebApi.Manha.Models;
using Senai.Gufi.WebApi.Manha.Repositories;

namespace Senai.Gufi.WebApi.Manha.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TiposEventoController : ControllerBase
    {
        private ITipoEventoRepository _tipoEventoRepository { get; set; }
        private readonly IMapper _mapper;

        public TiposEventoController(IMapper mapper)
        {
            _mapper = mapper;
            _tipoEventoRepository = new TipoEventoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoEventoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_tipoEventoRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(TipoEventoModel novoTipoEvento)
        {
            var tipoEvento = _mapper.Map<TipoEvento>(novoTipoEvento);
            _tipoEventoRepository.Cadastrar(tipoEvento);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoEventoModel tipoEventoAtualizado)
        {
            var tipoEvento = _mapper.Map<TipoEvento>(tipoEventoAtualizado);

            _tipoEventoRepository.Atualizar(id, tipoEvento);

            return StatusCode(204);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tipoEventoRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}