using System.Collections.Generic;
using System.Linq;
using ConcessionariaAPI.ConcessionariaDominio.Entidades;
using ConcessionariaAPI.ConcessionariaDominio.Repositorio.Interfaces;
using ConcessionariaAPI.ConcessionariaInfra.Context;
using Microsoft.EntityFrameworkCore;

namespace ConcessionariaServicos.Repositorios
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext _context;
        public ClienteRepository(DataContext context)
        {
            _context = context;
        }

        public void AdicionarCliente(Cliente cliente)
        {
            _context.Add(cliente);
            _context.SaveChanges();
        }

        public void AlterarCliente(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Cliente> ListarCliente()
        {
            return _context.Cliente.ToList();
        }

        public Cliente ObterClientePorId(int id)
        {
            return _context.Cliente.FirstOrDefault(x => x.IdCliente == id);
        }

        public void RemoverCliente(Cliente cliente)
        {
            _context.Remove(cliente);
            _context.SaveChanges();
        }
    }
}