using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoPaulo.Domain.Model;
using ProjetoPaulo.Service.Interface;

namespace ProjetoPaulo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExemploController : ControllerBase
    {
        private readonly IExemploService _exemploService;

        public ExemploController(IExemploService exemploService)
        {
            _exemploService = exemploService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarExemplos()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarExemplos([FromBody] Exemplo exemplo)
        {
            try
            {
                await _exemploService.Cadastrar(exemplo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> AlterarExemplo()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletarExemplo()
        {
            return Ok();
        }
    }
}