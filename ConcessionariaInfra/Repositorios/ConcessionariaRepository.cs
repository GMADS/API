using System.Collections.Generic;
using System.Linq;
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

        public void AdicionarCarro(Carro carro)
        {
            try
            {
                _context.Add(carro);
                _context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
            
        }

        public void AlterarCarro(Carro carro)
        {
            _context.Update(carro);
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

        public void AdicionarCompra(Compra compra)
        { 
            _context.Add(compra);            
            _context.SaveChanges();
        }

        public void AlterarCompra(Compra compra)
        {
            _context.Entry(compra).State = EntityState.Modified;
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

        public void RemoverCompra(Compra compra)
        {
            _context.Remove(compra);
            _context.SaveChanges();
        }
    }
}
