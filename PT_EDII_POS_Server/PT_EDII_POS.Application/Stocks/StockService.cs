using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PT_EDII_POS.Domain.Stocks;

namespace PT_EDII_POS.Application.Stocks;

public class StockService(IStockRepository stockRepository)
{
    public async Task<List<Stock>> GetStocks()
    {
        return await stockRepository.GetStock();
    }
}
