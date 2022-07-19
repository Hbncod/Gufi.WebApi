using Microsoft.AspNetCore.Mvc;
using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Listar()
        {
            return Ok(await _repository.Listar());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ListarMeusEventos(int id)
        {
            return Ok(await _repository.ListarMeusEventos(id));
        }
        [HttpPost]
        public async Task<IActionResult> Inscrever(Presenca novaPresenca)
        {
            await _repository.Inscricao(novaPresenca);

            return Ok();
        }

    }
}