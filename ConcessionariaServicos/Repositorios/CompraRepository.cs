using System.Collections.Generic;
using System.Linq;
using ConcessionariaAPI.ConcessionariaDominio.Entidades;
using ConcessionariaAPI.ConcessionariaDominio.Repositorio.Interfaces;
using ConcessionariaAPI.ConcessionariaInfra.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ConcessionariaServicos.Repositorios
{
    public class CompraRepository : ICompraRepository
    {
        private readonly DataContext _context;

        public CompraRepository(DataContext context)
        {
            _context = context;
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