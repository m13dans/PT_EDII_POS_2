using PT_EDII_POS.Domain.Stocks;

namespace PT_EDII_POS.Application.Features.Stocks;

public class StockService(IStockRepository stockRepository)
{
    public async Task<List<Stock>> GetStocks()
    {
        return await stockRepository.GetStock();
    }
}
