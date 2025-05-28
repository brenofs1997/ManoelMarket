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
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
 
            builder.HasKey(p => p.Produto_Id);
            builder.Property(p => p.Observacao)
                   .HasMaxLength(500)
                   .IsUnicode(false)
                   .IsRequired(false);
        }
    }
}
