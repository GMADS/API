using System;
using ConcessionariaAPI.ConcessionariaDominio.Entidades;
using ConcessionariaDominio.Repositorio.Interfaces;
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
        public IActionResult AlterarCliente([FromBody]Cliente cliente, [FromServices] IConcessionariaServicos _servicoConcessionaria)
        {
            _servicoConcessionaria.AlterarCliente(cliente);

            return Ok();
        }
        [HttpDelete("DeletarCliente/{id}")]
        public IActionResult RemoverCliente(int id, [FromServices] IConcessionariaServicos _servicoConcessionaria)
        {
            _servicoConcessionaria.RemoverCliente(id);

            return Ok(); 
        }
        
    }
}