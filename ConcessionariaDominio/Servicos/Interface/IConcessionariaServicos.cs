using System.Threading.Tasks;
using ConcessionariaAPI.ConcessionariaDominio.Entidades;
using ConcessionariaDominio.Entidades;

namespace ConcessionariaDominio.Servicos.Interface
{
    public interface IConcessionariaServicos
    {
        Task<RetornoGenerico> AdicionarCarro (Carro carro);
        Task<RetornoGenerico> AlterarCarro (int id);
        Task<RetornoGenerico> RemoverCarro (int id);
        Task<RetornoGenerico> ObterCarroPorId(int id);
        Task<RetornoGenerico> ListarCarro();
        Task<RetornoGenerico> AdicionarCliente (Cliente cliente);
        Task<RetornoGenerico> AlterarCliente (int id);
        Task<RetornoGenerico> RemoverCliente (int id);
        Task<RetornoGenerico> ObterClientePorId(int id);
        Task<RetornoGenerico> ListarCliente();
        Task<RetornoGenerico> AdicionarCompra (Compra compra);
        Task<RetornoGenerico> AlterarCompra (int id);
        Task<RetornoGenerico> RemoverCompra (int id);
        Task<RetornoGenerico> ObterCompraPorId(int id);
        Task<RetornoGenerico> ListarCompra();
    }
}