using System;
using ConcessionariaAPI.ConcessionariaDominio.Entidades;
using ConcessionariaDominio.Servicos.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Concessionaria.API.Controllers
{
    public class ClienteController : ControllerBase
    {
        [HttpGet("ObterCliente/{id}")]
        public IActionResult ObterClientePorId(int id, [FromServices] IConcessionariaServicos _servicoConcessionaria)
        {
            try
            {
                var verificaCliente = _servicoConcessionaria.ObterClientePorId(id);

                if (verificaCliente == null)
                {
                    return NoContent();
                }

                return Ok(verificaCliente);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("ListarCliente")]
        public IActionResult ListarCliente([FromServices] IConcessionariaServicos _servicoConcessionaria)
        {
            try
            {
                var cliente = _servicoConcessionaria.ListarCliente();

                if(!cliente.Result.Sucesso)
                {
                    return NoContent();
                }

                return Ok(cliente);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("IncluirCliente")]
        public IActionResult AdicionarCliente([FromBody] Cliente cliente, 
                [FromServices] IConcessionariaServicos _servicoConcessionaria)
        {
              _servicoConcessionaria.AdicionarCliente(cliente);

            return Ok();
        }
        [HttpPut("AlterarCliente")]
        public IActionResult AlterarCliente(int id, Cliente cliente,
                [FromServices] IConcessionariaServicos _servicoConcessionaria)
        {
            var verificarCliente = _servicoConcessionaria.ObterClientePorId(id);
            if (verificarCliente == null)
            {
                return BadRequest();
            }

            _servicoConcessionaria.AlterarCliente(cliente);

            return Ok(verificarCliente);
        }
        [HttpDelete("DeletarCliente/{id}")]
        public IActionResult RemoverCliente(int id, [FromServices] IConcessionariaServicos _servicoConcessionaria)
        {
            var verificarCliente = _servicoConcessionaria.ObterClientePorId(id);

            if(verificarCliente == null)
            {
                return NotFound();
            }
            _servicoConcessionaria.RemoverCliente(id);

            return Ok(); 
        }
        
    }
}