using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConcessionariaAPI.ConcessionariaDominio.Entidades
{
    public class Carro
    {

        [Key] //DataAnnotation
        public int IdCarro { get; set; }
        public int Ano { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Kilometragem { get; set; }
        public string Cor { get; set; }
        public string Cambio { get; set; }
        public string Items { get; set; }
        public string Carroceria { get; set; }
        public int? Vendido { get; set; }         
    }
}