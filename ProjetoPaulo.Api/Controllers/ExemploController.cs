using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoPaulo.Domain.Model;
using ProjetoPaulo.Domain.Service;

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
        public async Task<IActionResult> ListarExemplos(string descricaoFiltro, int? skip, int? take)
        {
            try
            {
                ICollection<Exemplo> listaExemplo = await _exemploService.BuscarExemplos(descricaoFiltro,skip,take);
                return Ok(listaExemplo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getPorId/{id}")]
        public async Task<IActionResult> BuscarPorId(Guid id)
        {
            try
            {
                Exemplo exemplo = await _exemploService.BuscarExemploPorId(id);
                return Ok(exemplo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CadastrarExemplos([FromBody] Exemplo exemplo)
        {
            try
            {
                Exemplo exemploCadastrado = await _exemploService.Cadastrar(exemplo);
                return Ok(exemploCadastrado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> AlterarExemplo([FromBody] Exemplo exemplo)
        {
            try
            {
                Exemplo exemploAtualizado = await _exemploService.Alterar(exemplo);
                return Ok(exemploAtualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletarExemplo([FromBody] Exemplo exemplo)
        {
            try
            {
                await _exemploService.Deletar(exemplo);
                return Ok("Exemplo deletado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}