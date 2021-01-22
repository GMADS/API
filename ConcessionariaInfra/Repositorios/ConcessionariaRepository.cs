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

        bool AdicionarCarro(Carro carro)
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

        bool AlterarCarro(int id)
        {
            _context.Update(id);
            _context.SaveChanges();

            return true;
        }

        IEnumerable<Carro> ListarCarro()
        {
            return _context.Carro.ToList();
        }

        public Carro ObterCarroPorId(int id)

        {
            return _context.Carro.FirstOrDefault(x => x.IdCarro == id);            
        }

        bool RemoverCarro(int id)
        {
            var result = _context.Carro.FirstOrDefault(x => x.IdCarro == id);

            _context.Remove(result);
            _context.SaveChanges();

            return true;
        }

        bool AdicionarCliente(Cliente cliente)
        {
            _context.Add(cliente);
            _context.SaveChanges();

            return true;
        }

        bool AlterarCliente(int id)
        {
            _context.Entry(id).State = EntityState.Modified;
            _context.SaveChanges();

            return true;
        }

        IEnumerable<Cliente> ListarCliente()
        {
            return _context.Cliente.ToList();
        }

        Cliente ObterClientePorId(int id)
        {
            return _context.Cliente.FirstOrDefault(x => x.IdCliente == id);
        }

        bool IConcessionariaRepositrio.RemoverCliente(int id)
        {
            _context.Remove(id);
            _context.SaveChanges();

            return true;
        }

        bool IConcessionariaRepositrio.AdicionarCompra(Compra compra)
        { 
            _context.Add(compra);            
            _context.SaveChanges();

            return true;
        }

        bool AlterarCompra(int id)
        {
            _context.Entry(id).State = EntityState.Modified;
            _context.SaveChanges();

            return true;
        }

        IEnumerable<Compra> ListarCompra()
        {
            return _context.Compra.ToList();
        }

        Compra ObterCompraPorId(int id)
        {
            return _context.Compra.FirstOrDefault(x => x.IdCarro == id);
        }

        bool IConcessionariaRepositrio.RemoverCompra(int id)
        {
            _context.Remove(id);
            _context.SaveChanges();

            return true;
        }

        Task<bool> IConcessionariaRepositrio.AdicionarCarro(Carro carro)
        {
            throw new System.NotImplementedException();
        }

        Task<bool> IConcessionariaRepositrio.AlterarCarro(int id)
        {
            throw new System.NotImplementedException();
        }

        bool IConcessionariaRepositrio.RemoverCarro(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<Carro> IConcessionariaRepositrio.ObterCarroPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Carro> IConcessionariaRepositrio.ListarCarro()
        {
            throw new System.NotImplementedException();
        }

        bool IConcessionariaRepositrio.AdicionarCliente(Cliente cliente)
        {
            throw new System.NotImplementedException();
        }

        bool IConcessionariaRepositrio.AlterarCliente(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<Cliente> IConcessionariaRepositrio.ObterClientePorId(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<IEnumerable<Cliente>> IConcessionariaRepositrio.ListarCliente()
        {
            throw new System.NotImplementedException();
        }

        bool IConcessionariaRepositrio.AlterarCompra(int id)
        {
            throw new System.NotImplementedException();
        }

        Compra IConcessionariaRepositrio.ObterCompraPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Compra> IConcessionariaRepositrio.ListarCompra()
        {
            throw new System.NotImplementedException();
        }
    }
}
