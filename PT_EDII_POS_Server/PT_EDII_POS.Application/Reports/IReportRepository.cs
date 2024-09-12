using PT_EDII_POS.Domain.Reports;

namespace PT_EDII_POS.Application.Reports;

public interface IReportRepository
{
    public Task<List<Report>> GetReport();
}