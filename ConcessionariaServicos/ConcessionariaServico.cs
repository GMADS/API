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

        public async Task<RetornoGenerico> AlterarCarro(Carro carro)
        {
            var verificarCarro = _concessionariaRepositorio.ObterCarroPorId(carro.IdCarro);

            if(verificarCarro == null || carro.IdCarro == 0)
            {
                return new RetornoGenerico(false, "Erro: id igual a 0 ou carro não existe", null);
            }

            return new RetornoGenerico(
                    true, "Carro alterado com sucesso", _concessionariaRepositorio.AlterarCarro(carro));
        }

        public async Task<RetornoGenerico> AlterarCliente(Cliente cliente)
        {
            var verificarCliente = _concessionariaRepositorio.ObterClientePorId(cliente.IdCliente);

            if(verificarCliente == null || cliente.IdCliente == 0)
            {
                return new RetornoGenerico(false, "Erro: id igual a 0 ou cliente não existe", null);
            }

            return new RetornoGenerico(
                    true, "Cliente alterado com sucesso", _concessionariaRepositorio.AlterarCliente(cliente));
        }

        public async Task<RetornoGenerico> AlterarCompra(Compra compra)
        {
            var verificarCompra = _concessionariaRepositorio.ObterCompraPorId(compra.IdCompra);

            if(verificarCompra == null || compra.IdCompra == 0)
            {
                return new RetornoGenerico(false, "Erro: id igual a 0 ou compra não existe", null);
            }
            return new RetornoGenerico(
                    true, "Compra alterada com sucesso", _concessionariaRepositorio.AlterarCompra(compra));
        }

        public async Task<RetornoGenerico> ListarCarro()
        {
            return new RetornoGenerico(
                    true, "Carros obtidos com sucesso",  _concessionariaRepositorio.ListarCarro());
        }

        public async Task<RetornoGenerico> ListarCliente()
        {
            return new RetornoGenerico(
                    true, "Clientes obtidos com sucesso", _concessionariaRepositorio.ListarCliente());
        }

        public async Task<RetornoGenerico> ListarCompra()
        {
            return new RetornoGenerico(
                    true, "Compras obtidas com sucesso", _concessionariaRepositorio.ListarCompra());
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
            return new RetornoGenerico(
                    true, "Compra obtido com sucesso", _concessionariaRepositorio.ObterCompraPorId(id));
        }

        async Task<RetornoGenerico> IConcessionariaServicos.RemoverCarro(int id)
        {
            var verificarCarro = await _concessionariaRepositorio.ObterCarroPorId(id);

            if(verificarCarro == null)
            {
                return new RetornoGenerico(false, "Carro não existe", null);
            }

            return new RetornoGenerico(true, "Carro excluido com sucesso", await _concessionariaRepositorio.ObterCarroPorId(id));
        }
        public async Task<RetornoGenerico> RemoverCliente(int id)
        {
            var verificarCliente = await _concessionariaRepositorio.ObterClientePorId(id);

            if(verificarCliente == null || id == 0)
            {
                return new RetornoGenerico(false, "Erro: id igual a 0 ou cliente não existe", null);
            }

            return new RetornoGenerico(
                true, "Cliente excluido com sucesso", await _concessionariaRepositorio.ObterClientePorId(id));
        }

        public async Task<RetornoGenerico> RemoverCompra(int id)
        {
            var verificarCompra = await _concessionariaRepositorio.ObterClientePorId(id);

            if(verificarCompra == null || id == 0)
            {
                return new RetornoGenerico(false, "Erro: id igual a 0 ou compra não existe", null);
            }

            return new RetornoGenerico(
                true, "Compra excluido com sucesso", await _concessionariaRepositorio.ObterClientePorId(id));
        }
    }
}