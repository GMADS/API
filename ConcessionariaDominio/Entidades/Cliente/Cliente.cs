using System.ComponentModel.DataAnnotations;

namespace ConcessionariaAPI.ConcessionariaDominio.Entidades
{
    public class Cliente
    {
        [Key] //DataAnnotations
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
    }
}