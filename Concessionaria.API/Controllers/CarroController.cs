using System;
using System.Collections.Generic;
using ConcessionariaAPI.ConcessionariaDominio.Entidades;
using ConcessionariaAPI.ConcessionariaDominio.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConcessionariaAPI.Concessionaria.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarroController : ControllerBase
    {
        [HttpGet("ObterCarroPorId/{id}")]
        public IActionResult ObterCarroPorId(int id, [FromServices]ICarroRepository _repositorioCarro)
        {
            try
            {
                var verificaProduto = _repositorioCarro.ObterCarroPorId(id);

                if (verificaProduto == null)
                {
                    return NotFound("Carro não encontrado");
                }


                return Ok(verificaProduto);
            }

            catch (Exception e)
            {
                 throw e;
            }
        }
        [HttpGet("ListarCarros")] 
        public IEnumerable<Carro> ListarCarros([FromServices]ICarroRepository _repositorioCarro)
        {                            
            var produtos = _repositorioCarro.ListarCarro();           

            return (produtos);
            
        }
        [HttpPost("IncluirCarro")]
        public IActionResult AdicionarCarro([FromBody] Carro carro, [FromServices]ICarroRepository _repositorioCarro)
        {
            _repositorioCarro.AdicionarCarro(carro);
            return Ok();
        }
        [HttpPut("AlterarCarro")]
        public IActionResult AlterarCarro(Carro carro, [FromServices]ICarroRepository _repositorioCarro)
        {
            // var IdCarro = carro.IdCarro;
            // var verificarCarro = _repositorioCarro.ObterCarroPorId(IdCarro);
            // if (verificarCarro == null)
            // {
            //     return BadRequest();
            // }

            // verificarCarro.Ano = carro.Ano;
            // verificarCarro.Marca = carro.Marca;
            // verificarCarro.Modelo = carro.Modelo;
            // verificarCarro.Kilometragem = carro.Kilometragem;
            // verificarCarro.Cor = carro.Cor;
            // verificarCarro.Cambio = carro.Cambio;
            // verificarCarro.Itens = carro.Itens;
            // verificarCarro.Carroceria = carro.Carroceria;

            _repositorioCarro.AlterarCarro(carro);

            return Ok();
        }
        [HttpDelete("DeletarCarro")]
        public IActionResult RemoverCarro(int id, [FromServices]ICarroRepository _repositorioCarro)
        {
            _repositorioCarro.RemoverCarro(id);

            return Ok(); 
        }
    }
}