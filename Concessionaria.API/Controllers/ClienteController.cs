using System;
using ConcessionariaAPI.ConcessionariaDominio.Entidades;
using ConcessionariaAPI.ConcessionariaDominio.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Concessionaria.API.Controllers
{
    public class ClienteController : ControllerBase
    {
        [HttpGet("ObterCliente/{id}")]
        public IActionResult ObterClientePorId(int id, [FromServices] IClienteRepository _repositorioCliente)
        {
            try
            {
                var verificaCliente = _repositorioCliente.ObterClientePorId(id);

                if (verificaCliente == null)
                {
                    return NotFound("Cliente não encontrado");
                }

                return Ok(verificaCliente);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("ListarCliente")]
        public IActionResult ListarCliente([FromServices] IClienteRepository _repositorioCliente)
        {
            try
            {
                var cliente = _repositorioCliente.ListarCliente();

                return Ok(cliente);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("IncluirCliente")]
        public IActionResult AdicionarCliente([FromBody] Cliente cliente, 
                [FromServices] IClienteRepository _repositorioCliente)
        {
              _repositorioCliente.AdicionarCliente(cliente);

            return Ok();
        }
        [HttpPut("AlterarCliente")]
        public IActionResult AlterarCliente(int id, Cliente cliente,
                [FromServices] IClienteRepository _repositorioCliente )
        {
            var verificarCliente = _repositorioCliente.ObterClientePorId(id);
            if (verificarCliente == null)
            {
                return BadRequest();
            }

            verificarCliente.IdCliente = cliente.IdCliente;

            _repositorioCliente.AlterarCliente(verificarCliente);

            return Ok();
        }
        [HttpDelete("DeletarCliente/{id}")]
        public IActionResult RemoverCliente(int id, [FromServices] IClienteRepository _repositorioCliente)
        {
            var verificarCliente = _repositorioCliente.ObterClientePorId(id);

            if(verificarCliente == null)
            {
                return NotFound();
            }
            _repositorioCliente.RemoverCliente(verificarCliente);

            return Ok(); 
        }
        
    }
}