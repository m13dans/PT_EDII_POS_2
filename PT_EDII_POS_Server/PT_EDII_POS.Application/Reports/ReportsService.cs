using PT_EDII_POS.Domain.Reports;

namespace PT_EDII_POS.Application.Reports;

public class ReportsService(IReportRepository repo)
{
    public async Task<List<Report>> GetReport()
    {
        return await repo.GetReport();
    }
}
