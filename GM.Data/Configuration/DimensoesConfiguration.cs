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
    public class DimensoesConfiguration: IEntityTypeConfiguration<Dimensoes>
    {
        public void Configure(EntityTypeBuilder<Dimensoes> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
