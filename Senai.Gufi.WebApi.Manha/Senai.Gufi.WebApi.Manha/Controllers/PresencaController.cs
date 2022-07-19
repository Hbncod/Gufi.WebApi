using Microsoft.AspNetCore.Mvc;
using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;

namespace Senai.Gufi.WebApi.Manha.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PresencaController : ControllerBase
    {
        private IPresencaRepository _repository { get; set; }

        public PresencaController(IPresencaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_repository.Listar());
        }
        [HttpGet("{id}")]
        public IActionResult ListarMeusEventos(int id)
        {
            return Ok(_repository.ListarMeusEventos(id));
        }
        [HttpPost]
        public IActionResult Inscrever(Presenca novaPresenca)
        {
            _repository.Inscricao(novaPresenca);

            return Ok();
        }

    }
}