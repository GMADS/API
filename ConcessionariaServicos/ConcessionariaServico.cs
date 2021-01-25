using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcessionariaAPI.ConcessionariaDominio.Entidades;
using ConcessionariaDominio.Entidades;
using ConcessionariaDominio.Repositorio.Interfaces;
using ConcessionariaDominio.Servicos.Interface;

namespace ConcessionariaServicos
{
    public class ConcessionariaServico : IConcessionariaServicos
    {
        private IConcessionariaRepositrio _concessionariaRepositorio;
        public ConcessionariaServico(IConcessionariaRepositrio concessionariaRepositorio)
        {
            _concessionariaRepositorio = concessionariaRepositorio;
        }
        public async Task<RetornoGenerico> AdicionarCarro(Carro carro)
        {
            return new RetornoGenerico(
                    true, "Carro alterado com sucesso", _concessionariaRepositorio.AdicionarCarro(carro));            
        }

        public async Task<RetornoGenerico> AdicionarCliente(Cliente cliente)
        {
            return new RetornoGenerico(
                    true, "Cliente inserido com sucesso", _concessionariaRepositorio.AdicionarCliente(cliente));
        }

        public async Task<RetornoGenerico> AdicionarCompra(Compra compra)
        {
            return new RetornoGenerico(
                    true, "Compra inserida com sucesso", _concessionariaRepositorio.AdicionarCompra(compra));
        }
        public async Task<RetornoGenerico> AlterarCliente(Cliente cliente)
        {
            return new RetornoGenerico(
                    true, "Cliente alterado com sucesso", _concessionariaRepositorio.AlterarCliente(cliente));
        }

        public async Task<RetornoGenerico> AlterarCompra(Compra compra)
        {
            return new RetornoGenerico(
                    true, "Compra alterada com sucesso", _concessionariaRepositorio.AlterarCompra(compra));
        }

        public RetornoGenerico ListarCarro()
        {
            var retorno = _concessionariaRepositorio.ListarCarro();

            if(!retorno.Any())
            {
                return new RetornoGenerico(false, "Não existe carros cadastrados na base de dados", null);
            }

            return new RetornoGenerico(true, "Carros obtidos com sucesso", retorno);
        
        }

        public async Task<RetornoGenerico> ListarCliente()
        {
            var retorno = _concessionariaRepositorio.ListarCliente();

            if (!retorno.Any())
            {
                return new RetornoGenerico(false, "Não existe clientes cadastrados na base de dados", null);
            }
            
            return new RetornoGenerico(true, "Clientes obtidos com sucesso", retorno);             
        }

        public async Task<RetornoGenerico> ListarCompra()
        {
            var retorno = _concessionariaRepositorio.ListarCompra();

            if(!retorno.Any())
            {
                return new RetornoGenerico(false, "Não existe compras cadastrados na base de dados", null);
            }

            return new RetornoGenerico(true, "Compras obtidas com sucesso", retorno);
        }

        public async Task<RetornoGenerico> ObterCarroPorId(int id)
        {
            return new RetornoGenerico(
                    true, "Carro obtido com sucesso", _concessionariaRepositorio.ObterCarroPorId(id));
            
        }

        public async Task<RetornoGenerico> ObterClientePorId(int id)
        {
            return new RetornoGenerico(
                    true, "Cliente obtido com sucesso", _concessionariaRepositorio.ObterClientePorId(id));
        }

        public async Task<RetornoGenerico> ObterCompraPorId(int id)
        {
            var retorno = _concessionariaRepositorio.ObterCompraPorId(id);

            return new RetornoGenerico(
                    true, "Compra obtido com sucesso", retorno);
        }

        async Task<RetornoGenerico> IConcessionariaServicos.RemoverCarro(int id)
        {
            return new RetornoGenerico(true, "Carro excluido com sucesso", _concessionariaRepositorio.RemoverCarro(id));
        }
        public async Task<RetornoGenerico> RemoverCliente(int id)
        {
            return new RetornoGenerico(
                true, "Cliente excluido com sucesso", _concessionariaRepositorio.RemoverCliente(id));
        }

        public async Task<RetornoGenerico> RemoverCompra(int id)
        {
            return new RetornoGenerico(
                true, "Compra excluido com sucesso", _concessionariaRepositorio.RemoverCompra(id));
        }

        public IEnumerable<Carro> ExportarCSV()
        {
            var builder = new StringBuilder();

            builder.AppendLine("IdCarro, Ano, Marca, Kilometragem, Cor, Cambio, Items, Carroceria");

            var carros = _concessionariaRepositorio.ListarCarro();            

            foreach (var user in carros)
            {
                builder.AppendLine($"{user.IdCarro}, {user.Ano}, {user.Marca}, {user.Kilometragem}, {user.Cor}, {user.Cambio}, {user.Items}, {user.Carroceria}");
            }

            return (IEnumerable<Carro>)File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "users.csv");

            // return (IOrderedEnumerable<Carro>)retorno;
        }

        private object File(byte[] vs, string v1, string v2)
        {
            throw new System.NotImplementedException();
        }
    }
}