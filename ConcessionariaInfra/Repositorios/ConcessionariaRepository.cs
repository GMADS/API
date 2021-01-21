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

        async Task<bool> IConcessionariaRepositrio.AdicionarCarro(Carro carro)
        {
            try
            {
                await _context.Add(carro);
                _context.SaveChanges();

                return true;
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
            
        }

        public void AlterarCarro(int id)
        {
            _context.Update(id);
            _context.SaveChanges();
        }

        public IEnumerable<Carro> ListarCarro()
        {
            return  _context.Carro.ToList();
        }

        public Carro ObterCarroPorId(int id)
        {
            var result =  _context.Carro.FirstOrDefault(x => x.IdCarro == id);

            return result;
        }

        public void RemoverCarro(int id)
        {

            var result = _context.Carro.FirstOrDefault(x => x.IdCarro == id);

            _context.Remove(result);
            _context.SaveChanges();

        }

        public void AdicionarCliente(Cliente cliente)
        {
            _context.Add(cliente);
            _context.SaveChanges();
        }

        public void AlterarCliente(int id)
        {
            _context.Entry(id).State = EntityState.Modified;
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

        public void RemoverCliente(int id)
        {
            _context.Remove(id);
            _context.SaveChanges();
        }

        public void AdicionarCompra(Compra compra)
        { 
            _context.Add(compra);            
            _context.SaveChanges();
        }

        public void AlterarCompra(int id)
        {
            _context.Entry(id).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Compra> ListarCompra()
        {
            return _context.Compra.ToList();
        }

        public Compra ObterCompraPorId(int id)
        {
            return _context.Compra.FirstOrDefault(x => x.IdCarro == id);
        }

        public void RemoverCompra(int id)
        {
            _context.Remove(id);
            _context.SaveChanges();
        }

        Task<bool> IConcessionariaRepositrio.AdicionarCarro(Carro carro)
        {
            throw new System.NotImplementedException();
        }

        Task<bool> IConcessionariaRepositrio.AlterarCarro(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<bool> IConcessionariaRepositrio.RemoverCarro(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<Carro> IConcessionariaRepositrio.ObterCarroPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<IEnumerable<Carro>> IConcessionariaRepositrio.ListarCarro()
        {
            throw new System.NotImplementedException();
        }

        Task<bool> IConcessionariaRepositrio.AdicionarCliente(Cliente cliente)
        {
            throw new System.NotImplementedException();
        }

        Task<bool> IConcessionariaRepositrio.AlterarCliente(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<bool> IConcessionariaRepositrio.RemoverCliente(int id)
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

        Task<bool> IConcessionariaRepositrio.AdicionarCompra(Compra compra)
        {
            throw new System.NotImplementedException();
        }

        Task<bool> IConcessionariaRepositrio.AlterarCompra(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<bool> IConcessionariaRepositrio.RemoverCompra(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<Compra> IConcessionariaRepositrio.ObterCompraPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<IEnumerable<Compra>> IConcessionariaRepositrio.ListarCompra()
        {
            throw new System.NotImplementedException();
        }
    }
}
