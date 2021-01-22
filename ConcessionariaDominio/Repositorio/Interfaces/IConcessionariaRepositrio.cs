using System.Collections.Generic;
using System.Threading.Tasks;
using ConcessionariaAPI.ConcessionariaDominio.Entidades;

namespace ConcessionariaDominio.Repositorio.Interfaces
{
    public interface IConcessionariaRepositrio
    {
        Task<bool> AdicionarCarro (Carro carro);
        Task<bool> AlterarCarro (int id);
        bool RemoverCarro (int id);
        Task<Carro> ObterCarroPorId(int id);
        IEnumerable<Carro> ListarCarro();
        bool AdicionarCliente (Cliente cliente);
        bool AlterarCliente (int id);
        bool RemoverCliente (int id);
        Task<Cliente> ObterClientePorId(int id);
        Task<IEnumerable<Cliente>> ListarCliente();
        bool AdicionarCompra (Compra compra);
        bool AlterarCompra (int id);
        bool RemoverCompra (int id);
        Compra ObterCompraPorId(int id);
        IEnumerable<Compra> ListarCompra();
    }
}