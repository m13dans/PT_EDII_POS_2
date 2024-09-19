using Microsoft.EntityFrameworkCore;
using PT_EDII_POS.Application.Features.Stocks;
using PT_EDII_POS.Domain.Stocks;
using PT_EDII_POS.Infrastructure.DataContext;

namespace PT_EDII_POS.Infrastructure.Features.Stocks;

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
