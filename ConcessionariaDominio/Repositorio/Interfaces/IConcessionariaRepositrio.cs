using System.Collections.Generic;
using ConcessionariaAPI.ConcessionariaDominio.Entidades;

namespace ConcessionariaDominio.Repositorio.Interfaces
{
    public interface IConcessionariaRepositrio
    {
        void AdicionarCarro (Carro carro);
        void AlterarCarro (Carro carro);
        void RemoverCarro (int id);
        Carro ObterCarroPorId(int id);
        IEnumerable<Carro> ListarCarro();
        void AdicionarCliente (Cliente cliente);
        void AlterarCliente (Cliente cliente);
        void RemoverCliente (Cliente cliente);
        Cliente ObterClientePorId(int id);
        IEnumerable<Cliente> ListarCliente();
        void AdicionarCompra (Compra compra);
        void AlterarCompra (Compra compra);
        void RemoverCompra (Compra compra);
        Compra ObterCompraPorId(int id);
        IEnumerable<Compra> ListarCompra();
    }
}