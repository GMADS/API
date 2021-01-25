using System.Threading.Tasks;
using ConcessionariaAPI.ConcessionariaDominio.Entidades;
using ConcessionariaDominio.Entidades;

namespace ConcessionariaDominio.Servicos.Interface
{
    public interface IConcessionariaServicos
    {
        Task<RetornoGenerico> AdicionarCarro (Carro carro);
        Task<RetornoGenerico> RemoverCarro (int id);
        Task<RetornoGenerico> ObterCarroPorId(int id);
        RetornoGenerico ListarCarro();
        Task<RetornoGenerico> AdicionarCliente (Cliente cliente);
        Task<RetornoGenerico> AlterarCliente (Cliente cliente);
        Task<RetornoGenerico> RemoverCliente (int id);
        Task<RetornoGenerico> ObterClientePorId(int id);
        Task<RetornoGenerico> ListarCliente();
        Task<RetornoGenerico> AdicionarCompra (Compra compra);
        Task<RetornoGenerico> AlterarCompra (Compra compra);
        Task<RetornoGenerico> RemoverCompra (int id);
        Task<RetornoGenerico> ObterCompraPorId(int id);
        Task<RetornoGenerico> ListarCompra();
    }
}