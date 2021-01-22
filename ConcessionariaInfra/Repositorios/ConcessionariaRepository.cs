using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConcessionariaAPI.ConcessionariaDominio.Entidades;
using ConcessionariaAPI.ConcessionariaInfra.Context;
using ConcessionariaDominio.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConcessionariaInfra.Repositorios
{
    public class ConcessionariaRepository : IConcessionariaRepositrio
    {
        private readonly DataContext _context;
        public ConcessionariaRepository(DataContext context)
        {
            _context = context; 
        }

        public bool AdicionarCarro(Carro carro)
        {
            try
            {
                _context.Add(carro);
                _context.SaveChanges();

                return true;
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
        }

        public bool AdicionarCliente(Cliente cliente)
        {
            _context.Add(cliente);
            _context.SaveChanges();

            return true;
        }

        public bool AdicionarCompra(Compra compra)
        {
            _context.Add(compra);            
            _context.SaveChanges();

            return true;
        }

        public bool AlterarCarro(Carro carro)
        {
            _context.Update(carro);
            _context.SaveChanges();

            return true;
        }

        public bool AlterarCliente(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            _context.SaveChanges();

            return true;
        }

        public bool AlterarCompra(Compra compra)
        {
            _context.Entry(compra).State = EntityState.Modified;
            _context.SaveChanges();

            return true;
        }

        public IEnumerable<Carro> ListarCarro()
        {
            return _context.Carro.ToList();
        }

        public IEnumerable<Cliente> ListarCliente()
        {
            return _context.Cliente.ToList();
        }

        public IEnumerable<Compra> ListarCompra()
        {
            return _context.Compra.ToList();
        }

        public async Task<Carro> ObterCarroPorId(int id)
        {
            return _context.Carro.FirstOrDefault(x => x.IdCarro == id);
        }

        public async Task<Cliente> ObterClientePorId(int id)
        {
            return _context.Cliente.FirstOrDefault(x => x.IdCliente == id);
        }

        public Compra ObterCompraPorId(int id)
        {
            return _context.Compra.FirstOrDefault(x => x.IdCarro == id);
        }

        public bool RemoverCarro(int id)
        {
            _context.Remove(id);
            _context.SaveChanges();

            return true;
        }

        public bool RemoverCliente(int id)
        {
            _context.Remove(id);
            _context.SaveChanges();

            return true;
        }

        public bool RemoverCompra(int id)
        {
            _context.Remove(id);
            _context.SaveChanges();

            return true;
        }
    }
}
