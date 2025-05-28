using GM.Core.Domain;
using GM.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.Data.Context
{
    public class GMContext: DbContext
    {
        public DbSet<Caixa> Caixas { get; set; }
        public DbSet<Dimensoes> Dimensoes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Role> Roles { get; set; }

        public GMContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CaixaConfiguration());
            modelBuilder.ApplyConfiguration(new DimensoesConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
        }

    }
}
