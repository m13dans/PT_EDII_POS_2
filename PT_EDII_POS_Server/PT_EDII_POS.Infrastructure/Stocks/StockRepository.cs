using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PT_EDII_POS.Application.Stocks;
using PT_EDII_POS.Application.Transactions;
using PT_EDII_POS.Domain.Stocks;
using PT_EDII_POS.Infrastructure.DataContext;

namespace PT_EDII_POS.Infrastructure.Stocks;

public class StockRepository(AppDbContext dbContext) : IStockRepository
{
    public async Task<List<Stock>> GetStock()
    {
        var item = dbContext.Items.Select(x => new Stock()
        {
            NamaBarang = x.NamaBarang,
            Harga = x.Harga,
            JumlahStokSaatIni = x.StokAwal,
            Kategori = x.Kategori
        });

        return await item.ToListAsync();
    }
}
