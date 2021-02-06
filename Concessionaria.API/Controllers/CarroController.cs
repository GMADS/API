using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcessionariaAPI.ConcessionariaDominio.Entidades;
using ConcessionariaDominio.Repositorio.Interfaces;
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

                return Ok(verificaProduto.Result);
            }

            catch (Exception e)
            {
                 throw e;
            }
        }
        [HttpGet("ListarCarros")] 
        public IActionResult ListarCarros([FromServices]IConcessionariaServicos _servicoConcessionaria)
        {                            
            var produtos = _servicoConcessionaria.ListarCarro();  
            return Ok(produtos);            
        }
        [HttpPost("IncluirCarro")]
        public IActionResult AdicionarCarro([FromBody] Carro carro,
                 [FromServices]IConcessionariaServicos _servicoConcessionaria)
        {
            _servicoConcessionaria.AdicionarCarro(carro);
            return Ok();
        }
        [HttpPut("AlterarCarro")]
        public IActionResult AlterarCarro(Carro carro, [FromServices]IConcessionariaRepositrio _repositorioConcessionaria)
        {
            var retorno = _repositorioConcessionaria.AlterarCarro(carro);
            
            return Ok();
        }
        [HttpDelete("DeletarCarro/{id}")]
        public IActionResult RemoverCarro(int id, [FromServices]IConcessionariaServicos _servicoConcessionaria)
        {
            _servicoConcessionaria.RemoverCarro(id);

            return Ok(); 
        }
        [HttpGet("ExportarArquivoCSV")]
         public IActionResult Csv([FromServices]IConcessionariaServicos _repositorioConcessionaria)
        {
            // var cabecalho = new StringBuilder();

            // cabecalho.AppendLine("IdCarro, Ano, Marca, Kilometragem, Cor, Cambio, Items, Carroceria");

            // cabecalho.AppendLine("IdCarro".Split(','), "Ano".Split(','), "Marca".Split(','), "Kilometragem".Split(','), "Cor".Split(','), "Cambio".Split(','), "Items".Split(','), "Carroceria".Split(','));

            var carros = _repositorioConcessionaria.ListarCarro();


            var fileName = $"ListaDeCarros" + DateTime.Now.ToString("dd-MM-yyyy") + ".csv";

            // foreach (var user in carros)
            // {
            //     cabecalho.AppendLine($"{user.IdCarro}, {user.Ano}, {user.Marca}, {user.Kilometragem}, {user.Cor}, {user.Cambio}, {user.Items}, {user.Carroceria}");
            // }

            var result = File(new System.Text.UTF8Encoding().GetBytes(carros), "text/csv", fileName);

            return result;

            // return File(Encoding.UTF8.GetBytes(cabecalho.ToString()), "text/csv", "carros.csv");
        }
    }
}