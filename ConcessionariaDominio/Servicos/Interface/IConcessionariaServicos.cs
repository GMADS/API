using System.Threading.Tasks;
using ConcessionariaAPI.ConcessionariaDominio.Entidades;
using ConcessionariaDominio.Entidades;

namespace ConcessionariaDominio.Servicos.Interface
{
    public interface IConcessionariaServicos
    {
        Task<RetornoGenerico> AdicionarCarro (Carro carro);
        Task<RetornoGenerico> AlterarCarro (Carro carro);
        void RemoverCarro (int id);
        Task<RetornoGenerico> ObterCarroPorId(int id);
        Task<RetornoGenerico> ListarCarro();
        Task<RetornoGenerico> AdicionarCliente (Cliente cliente);
        Task<RetornoGenerico> AlterarCliente (Cliente cliente);
        Task<RetornoGenerico> RemoverCliente (Cliente cliente);
        Task<RetornoGenerico> ObterClientePorId(int id);
        Task<RetornoGenerico> ListarCliente();
        Task<RetornoGenerico> AdicionarCompra (Compra compra);
        Task<RetornoGenerico> AlterarCompra (Compra compra);
        Task<RetornoGenerico> RemoverCompra (Compra compra);
        Task<RetornoGenerico> ObterCompraPorId(int id);
        Task<RetornoGenerico> ListarCompra();
    }
}