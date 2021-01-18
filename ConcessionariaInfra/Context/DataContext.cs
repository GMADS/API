using ConcessionariaAPI.ConcessionariaDominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ConcessionariaAPI.ConcessionariaInfra.Context
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {            
        }      

        public DbSet<Carro> Carro {get; set;}
        public DbSet<Cliente> Cliente {get; set;}
        public DbSet<Compra> Compra { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Carro>().ToTable("Carro");
            modelBuilder.Entity<Carro>().Property(x => x.Ano);
            modelBuilder.Entity<Carro>().Property(x => x.Marca);
            modelBuilder.Entity<Carro>().Property(x => x.Modelo);
            modelBuilder.Entity<Carro>().Property(x => x.Kilometragem);
            modelBuilder.Entity<Carro>().Property(x => x.Cor);
            modelBuilder.Entity<Carro>().Property(x => x.Cambio);
            modelBuilder.Entity<Carro>().Property(x => x.Items);
            modelBuilder.Entity<Carro>().Property(x => x.Carroceria);
            modelBuilder.Entity<Carro>().Property(x => x.Vendido);

            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Cliente>().Property(x => x.Nome);
            modelBuilder.Entity<Cliente>().Property(x => x.Logradouro);
            modelBuilder.Entity<Cliente>().Property(x => x.Cidade);
            modelBuilder.Entity<Cliente>().Property(x => x.Estado);
            modelBuilder.Entity<Cliente>().Property(x => x.Cep);

            modelBuilder.Entity<Compra>().ToTable("Compra");
            modelBuilder.Entity<Compra>().Property(x => x.IdCompra);
            modelBuilder.Entity<Compra>().Property(x => x.IdCarro);
            modelBuilder.Entity<Compra>().Property(x => x.IdCliente);
        }
    }

}

