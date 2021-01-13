using System.ComponentModel.DataAnnotations;

namespace ConcessionariaAPI.ConcessionariaDominio.Entidades
{
    public class Compra
    {
        [Key]
        public int IdCompra { get; set; }
        public int IdCliente { get; set; }
        public int IdCarro { get; set; }
    }
}