using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufi.WebApi.Manha.Domains;
using Senai.Gufi.WebApi.Manha.Interfaces;
using Senai.Gufi.WebApi.Manha.Repositories;

namespace Senai.Gufi.WebApi.Manha.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PresencaController : ControllerBase
    {
        private IPresencaRepository _presencaRepository { get; set; }

        public PresencaController()
        {
            _presencaRepository = new PresencaRepository();
        }
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_presencaRepository.Listar());
        }
        [HttpGet("{id}")]
        public IActionResult ListarMeusEventos(int id)
        {
            return Ok(_presencaRepository.ListarMeusEventos(id));
        }
        [HttpPost]
        public IActionResult Inscrever(Presenca novaPresenca)
        {
            _presencaRepository.Inscricao(novaPresenca);

            return Ok();
        }

    }
}