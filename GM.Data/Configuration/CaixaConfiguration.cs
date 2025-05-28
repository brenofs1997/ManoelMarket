using GM.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.Data.Configuration
{
    public class CaixaConfiguration : IEntityTypeConfiguration<Caixa>
    {
        public void Configure(EntityTypeBuilder<Caixa> builder)
        {
            builder.HasKey(c => c.CaixaId);
            builder.Property(c => c.CaixaId)
                    .ValueGeneratedOnAdd();

            builder.HasOne(c => c.Dimensoes)
                    .WithOne() 
                    .HasForeignKey<Caixa>(c => c.DimensoesId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Pedido>()
              .WithMany(p => p.Caixas)
              .HasForeignKey(c => c.PedidoId)
              .OnDelete(DeleteBehavior.SetNull);

            builder.Property(c => c.Observacao)
                   .HasMaxLength(255);

            builder.HasMany(c => c.Produtos)
                   .WithOne(p => p.Caixa)
                   .HasForeignKey(p => p.CaixaId);
        }        
    }
}
