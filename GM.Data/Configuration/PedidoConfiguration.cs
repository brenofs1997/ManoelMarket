using GM.Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.Data.Configuration
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Pedido_Id);

            builder.HasMany(p => p.Caixas)
              .WithOne()
              .HasForeignKey(c => c.PedidoId)
              .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
