using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using PT_EDII_POS.Application.Features.Transactions;
using PT_EDII_POS.Domain.Transactions;
using static Microsoft.AspNetCore.Http.TypedResults;

namespace PT_EDII_POS.API.Features.Transactions;

public static class TransactionEndpoint
{
    public static void MapTransactionEndpoint(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("api/pos/transactions")
            .WithOpenApi()
            .WithTags("Transaction")
            .RequireAuthorization();

        endpoints.MapGet("", GetTransaction)
            .Produces<List<Transaction>>();

        endpoints.MapPost("", PostTransaction)
            .DisableAntiforgery()
            .ProducesProblem(400)
            .Produces<Transaction>();
    }

    private static async Task<IResult> GetTransaction(TransactionService services)
    {
        var result = await services.GetTransaction();
        return Ok(result);
    }
    private static async Task<IResult> PostTransaction(
        TransactionService services,
        PostTransactionCommand command,
        IValidator<PostTransactionCommand> validator)
    {
        var validationResult = await validator.ValidateAsync(command);
        if (!validationResult.IsValid)
            return ValidationProblem(validationResult.ToDictionary());

        var result = await services.PostTransaction(command);

        return result.Match<IResult>(
            Ok,
            error => Problem(
                statusCode: int.Parse(error.First().Code),
                detail: error.First().Description));
    }
}
