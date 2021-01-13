﻿using System.Collections.Generic;
using System.Linq;
using ConcessionariaAPI.ConcessionariaDominio.Entidades;
using ConcessionariaAPI.ConcessionariaDominio.Repositorio.Interfaces;
using ConcessionariaAPI.ConcessionariaInfra.Context;

namespace ConcessionariaServicos
{
    public class CarroRepository : ICarroRepository
    {
        private readonly DataContext _context;
        public CarroRepository(DataContext context)
        {
            _context = context; 
        }

        public void AdicionarCarro(Carro carro)
        {
            _context.Add(carro);
        }

        public void AlterarCarro(Carro carro)
        {
            _context.Update(carro);
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

        }
    }
}
