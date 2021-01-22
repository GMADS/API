using System.Collections.Generic;
using System.Threading.Tasks;
using ConcessionariaAPI.ConcessionariaDominio.Entidades;

namespace ConcessionariaDominio.Repositorio.Interfaces
{
    public interface IConcessionariaRepositrio
    {
        bool AdicionarCarro (Carro carro);
        bool AlterarCarro (Carro carro);
        bool RemoverCarro (int id);
        Task<Carro> ObterCarroPorId(int id);
        IEnumerable<Carro> ListarCarro();
        bool AdicionarCliente (Cliente cliente);
        bool AlterarCliente (Cliente cliente);
        bool RemoverCliente (int id);
        Task<Cliente> ObterClientePorId(int id);
        IEnumerable<Cliente> ListarCliente();
        bool AdicionarCompra (Compra compra);
        bool AlterarCompra (Compra compra);
        bool RemoverCompra (int id);
        Compra ObterCompraPorId(int id);
        IEnumerable<Compra> ListarCompra();
    }
}