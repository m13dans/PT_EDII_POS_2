using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PT_EDII_POS.Domain.Transactions;

namespace PT_EDII_POS.Infrastructure.Transactions;

public class TransactionEntityConfig : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Harga).HasColumnType("decimal(18,2)");
        builder.Property(x => x.TotalHarga).HasColumnType("decimal(18,2)");
        builder.Property(x => x.Kategori).HasMaxLength(256);
    }
}
