using Microsoft.EntityFrameworkCore;
using PT_EDII_POS.Application.Reports;
using PT_EDII_POS.Domain.Reports;
using PT_EDII_POS.Infrastructure.DataContext;

namespace PT_EDII_POS.Infrastructure.Reports;

public class ReportRepository(AppDbContext dbContext) : IReportRepository
{
    public async Task<List<Report>> GetReport()
    {
        return await dbContext.Transactions.GroupBy(x => x.TanggalTransaksi).Select(x => new Report()
        {
            TanggalTransaksi = x.Key,
            TotalTransaksi = x.Sum(x => x.Id),
            ItemId = x.Select(x => x.ItemId).ToList(),
            Kategori = x.Select(x => x.Kategori).ToList(),
            TotalHargaTransaksi = x.Sum(x => x.TotalHarga)
        }).ToListAsync();
    }
}
