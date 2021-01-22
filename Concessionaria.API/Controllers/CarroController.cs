using System;
using System.Collections.Generic;
using ConcessionariaAPI.ConcessionariaDominio.Entidades;
using ConcessionariaDominio.Servicos.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ConcessionariaAPI.Concessionaria.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarroController : ControllerBase
    {
        [HttpGet("ObterCarroPorId/{id}")]
        public IActionResult ObterCarroPorId(int id, [FromServices]IConcessionariaServicos _servicoConcessionaria)
        {
            try
            {
                var verificaProduto = _servicoConcessionaria.ObterCarroPorId(id);

                if (verificaProduto == null)
                {
                    return NoContent();
                }


                return Ok(verificaProduto);
            }

            catch (Exception e)
            {
                 throw e;
            }
        }
        [HttpGet("ListarCarros")] 
        public IEnumerable<Carro> ListarCarros([FromServices]IConcessionariaServicos _servicoConcessionaria)
        {                            
            var produtos = _servicoConcessionaria.ListarCarro();  

            if(!produtos.Result.Sucesso)
            {
                return (IEnumerable<Carro>)NoContent();
            }         

            return ((IEnumerable<Carro>)produtos);
            
        }
        [HttpPost("IncluirCarro")]
        public IActionResult AdicionarCarro([FromBody] Carro carro,
                 [FromServices]IConcessionariaServicos _servicoConcessionaria)
        {
            _servicoConcessionaria.AdicionarCarro(carro);
            return Ok();
        }
        [HttpPut("AlterarCarro")]
        public IActionResult AlterarCarro(Carro carro, [FromServices]IConcessionariaServicos _servicoConcessionaria)
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

            _servicoConcessionaria.AlterarCarro(carro);

            return Ok();
        }
        [HttpDelete("DeletarCarro/{id}")]
        public IActionResult RemoverCarro(int id, [FromServices]IConcessionariaServicos _servicoConcessionaria)
        {
            _servicoConcessionaria.RemoverCarro(id);

            return Ok(); 
        }
    }
}