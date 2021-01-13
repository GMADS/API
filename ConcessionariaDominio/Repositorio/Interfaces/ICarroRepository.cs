using System.Collections.Generic;
using ConcessionariaAPI.ConcessionariaDominio.Entidades;

namespace ConcessionariaAPI.ConcessionariaDominio.Repositorio.Interfaces
{
    public interface ICarroRepository
    {
        void AdicionarCarro (Carro carro);
        void AlterarCarro (Carro carro);
        void RemoverCarro (int id);
        Carro ObterCarroPorId(int id);
        IEnumerable<Carro> ListarCarro();
    }
}
