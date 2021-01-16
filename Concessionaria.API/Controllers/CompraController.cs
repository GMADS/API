using System;
using ConcessionariaAPI.ConcessionariaDominio.Entidades;
using ConcessionariaAPI.ConcessionariaDominio.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Concessionaria.API.Controllers
{
    public class CompraController : ControllerBase
    {
         [HttpGet("ObterCrompas/{id}")]
        public IActionResult ObterCompraPorId([FromBody] int id,
                [FromServices] ICompraRepository __repositorioCompra)
        {
            try
            {
                
                var verificaCrompa = _repositorioCompra.ObterCompraPorId(id);

                if (verificaCrompa == null)
                {
                    return NotFound("Compra não encontrada");
                }

                return Ok(verificaCrompa);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("ListarCrompa")]
        public IActionResult ListarCrompa([FromServices] ICompraRepository __repositorioCompra)
        {
            try
            {
                var compra = _repositorioCompra.ListarCompra();

                return Ok(compra);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("IncluirCompra")]
        public IActionResult AdicionarCompra([FromBody] Compra compra,
                [FromServices] ICompraRepository __repositorioCompra)
        {
              _repositorioCompra.AdicionarCompra(compra);
            //   _repositorioCarro.AlterarCarro(IdCarro);

             return Ok();
        }
        [HttpPut("AlterarCompra")]
        public IActionResult AlterarCompra([FromBody] int id, Compra compra,
                [FromServices] ICompraRepository __repositorioCompra)
        {
            var verificarCompra = _repositorioCompra.ObterCompraPorId(id);
            if (verificarCompra == null)
            {
                return BadRequest();
            }

            // verificarCompra.IdCompra = compra.IdCompra;

            _repositorioCompra.AlterarCompra(verificarCompra);

            return Ok();
        }
        [HttpDelete("DeletarCompra/{id}")]
        public IActionResult RemoverCompra([FromBody]int id, [FromServices] ICompraRepository __repositorioCompra)
        {
            var verificarCompra = _repositorioCompra.ObterCompraPorId(id);

            if(verificarCompra == null)
            {
                return NotFound();
            }
            _repositorioCompra.RemoverCompra(verificarCompra);

            return Ok(); 
        }
    }
}