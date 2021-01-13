using System.Collections.Generic;
using ConcessionariaAPI.ConcessionariaDominio.Entidades;

namespace ConcessionariaAPI.ConcessionariaDominio.Repositorio.Interfaces
{
    public interface ICompraRepository
    {
        void AdicionarCompra (Compra compra);
        void AlterarCompra (Compra compra);
        void RemoverCompra (Compra compra);
        Compra ObterCompraPorId(int id);
        IEnumerable<Compra> ListarCompra();
    }
}