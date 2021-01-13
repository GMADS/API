using System.Collections.Generic;
using ConcessionariaAPI.ConcessionariaDominio.Entidades;

namespace ConcessionariaAPI.ConcessionariaDominio.Repositorio.Interfaces
{
    public interface IClienteRepository
    {
        void AdicionarCliente (Cliente cliente);
        void AlterarCliente (Cliente cliente);
        void RemoverCliente (Cliente cliente);
        Cliente ObterClientePorId(int id);
        IEnumerable<Cliente> ListarCliente();
    }
}