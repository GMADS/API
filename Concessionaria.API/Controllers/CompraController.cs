using System;
using ConcessionariaAPI.ConcessionariaDominio.Entidades;
using ConcessionariaDominio.Servicos.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Concessionaria.API.Controllers
{
    public class CompraController : ControllerBase
    {
         [HttpGet("ObterCrompas/{id}")]
        public IActionResult ObterCompraPorId(int id,
                [FromServices] IConcessionariaServicos _servicoConcessionaria)
        {
            try
            {                
                var verificaCrompa = _servicoConcessionaria.ObterCompraPorId(id);

                if (verificaCrompa.Result.Data == null)
                {
                    return NoContent();
                }

                return Ok(verificaCrompa);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("ListarCrompa")]
        public IActionResult ListarCrompa([FromServices] IConcessionariaServicos _servicoConcessionaria)
        {
            try
            {
                var compra = _servicoConcessionaria.ListarCompra();

                if (!compra.Result.Sucesso)
                    return NoContent();

                return Ok(compra);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("IncluirCompra")]
        public IActionResult AdicionarCompra([FromBody] Compra compra,
                [FromServices] IConcessionariaServicos _servicoConcessionaria)
        {
              _servicoConcessionaria.AdicionarCompra(compra);

             return Ok();
        }
        [HttpPut("AlterarCompra")]
        public IActionResult AlterarCompra([FromBody] Compra compra,
                [FromServices] IConcessionariaServicos _servicoConcessionaria)
        {
            _servicoConcessionaria.AlterarCompra(compra);

            return Ok();
        }
        [HttpDelete("DeletarCompra/{id}")]
        public IActionResult RemoverCompra(int id, [FromServices] IConcessionariaServicos _servicoConcessionaria)
        {
            _servicoConcessionaria.RemoverCompra(id);

            return Ok(); 
        }
    }
}