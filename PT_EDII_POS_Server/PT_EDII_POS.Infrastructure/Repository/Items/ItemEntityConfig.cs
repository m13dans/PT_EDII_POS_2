using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PT_EDII_POS.Domain.Items;

namespace PT_EDII_POS.Infrastructure.Repository.Items;

public class ItemEntityConfig : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.NamaBarang).HasMaxLength(256);
        builder.Property(x => x.Harga).HasColumnType("decimal(18,2)");
        builder.Property(x => x.Kategori).HasMaxLength(256);
        builder.Property(x => x.UrlGambar).HasMaxLength(512);
    }
}
