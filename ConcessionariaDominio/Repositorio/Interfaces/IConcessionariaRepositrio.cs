using System.Collections.Generic;
using System.Threading.Tasks;
using ConcessionariaAPI.ConcessionariaDominio.Entidades;

namespace ConcessionariaDominio.Repositorio.Interfaces
{
    public interface IConcessionariaRepositrio
    {
        Task<bool> AdicionarCarro (Carro carro);
        Task<bool> AlterarCarro (int id);
        Task<bool> RemoverCarro (int id);
        Task<Carro> ObterCarroPorId(int id);
        Task<IEnumerable<Carro>> ListarCarro();
        Task<bool> AdicionarCliente (Cliente cliente);
        Task<bool> AlterarCliente (int id);
        Task<bool> RemoverCliente (int id);
        Task<Cliente> ObterClientePorId(int id);
        Task<IEnumerable<Cliente>> ListarCliente();
        Task<bool> AdicionarCompra (Compra compra);
        Task<bool> AlterarCompra (int id);
        Task<bool> RemoverCompra (int id);
        Task<Compra> ObterCompraPorId(int id);
        Task<IEnumerable<Compra>> ListarCompra();
    }
}