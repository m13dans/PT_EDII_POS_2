using PT_EDII_POS.Domain.Stocks;

namespace PT_EDII_POS.Application.Stocks;

public interface IStockRepository
{
    public Task<List<Stock>> GetStock();
}