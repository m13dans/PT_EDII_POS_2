using PT_EDII_POS.Application.Features.Stocks;
using PT_EDII_POS.Domain.Transactions;
using static Microsoft.AspNetCore.Http.TypedResults;

namespace PT_EDII_POS.API.Features.Reports;

public static class StockEndpoint
{
    public static void MapStockEndpoint(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("api/pos/stocks")
            .WithOpenApi()
            .WithTags("Stocks")
            .RequireAuthorization();

        endpoints.MapGet("", GetStock)
            .Produces<List<Transaction>>();
    }

    private static async Task<IResult> GetStock(StockService services)
    {
        var result = await services.GetStocks();
        return Ok(result);
    }
}
