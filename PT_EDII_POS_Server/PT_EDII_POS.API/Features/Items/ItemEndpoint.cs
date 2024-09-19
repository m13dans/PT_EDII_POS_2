using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PT_EDII_POS.Application.Features.Items;
using PT_EDII_POS.Domain.Items;
using PT_EDII_POS.Infrastructure.Features.Items.ImageHelper;
using static Microsoft.AspNetCore.Http.TypedResults;

namespace PT_EDII_POS.API.Features.Items;

public static class ItemEndpoint
{
    public static void MapItemEndpoint(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("api/items").WithOpenApi().WithTags("Items").RequireAuthorization();

        endpoints.MapGet("", GetItems)
            .Produces<List<Item>>();

        endpoints.MapGet("{id:int}", GetItemById)
            .ProducesProblem(404)
            .Produces<Item>();

        endpoints.MapPost("", PostItems)
            .DisableAntiforgery()
            .ProducesProblem(400)
            .Produces<Item>(statusCode: StatusCodes.Status201Created);

        endpoints.MapPut("/{id:int}", UpdateItem)
            .DisableAntiforgery()
            .ProducesProblem(400)
            .Produces<Item>();

        endpoints.MapDelete("/{id:int}", DeleteItem)
            .ProducesProblem(400)
            .Produces<Item>();
    }

    private static async Task<IResult> GetItems(ItemServices services)
    {
        var result = await services.GetItems();
        return Ok(result);
    }
    private static async Task<IResult> GetItemById(ItemServices services, int id)
    {
        var result = await services.GetItemById(id);
        if (result.IsError)
            return Problem(detail: result.FirstError.Description);

        return Ok(result.Value);
    }
    private static async Task<IResult> PostItems(
        ItemServices services,
        ItemImageHelper imageHelper,
        [FromForm] CreateItemCommand command,
        IValidator<CreateItemCommand> validator)
    {
        var validationResult = await validator.ValidateAsync(command);
        if (!validationResult.IsValid)
            return ValidationProblem(validationResult.ToDictionary());

        var (urlGambar, hostUrlGambar, imageInByte) = imageHelper.HandleImage(command.Gambar);

        ItemDTO itemDto = Helper.MapToItemDTO(command, urlGambar, hostUrlGambar, imageInByte);

        var result = await services.CreateItem(itemDto);

        return result.Match<IResult>(
            value => Created($"/api/items/{value.Id}", value: value),
            error => Problem(statusCode: 400));
    }

    private static async Task<IResult> UpdateItem(
        ItemServices services,
        ItemImageHelper imageHelper,
        int id,
        [FromForm] UpdateItemCommand command,
        IValidator<UpdateItemCommand> validator)
    {
        var validationResult = await validator.ValidateAsync(command);
        if (!validationResult.IsValid)
            return ValidationProblem(validationResult.ToDictionary());

        if (command.Gambar is null)
        {
            var itemWithoutImage = Helper.MapItemWithoutImage(command);
            var resultItem = await services.UpdateItem(id, itemWithoutImage);
            return resultItem.Match<IResult>(
                Ok,
                error => Problem(statusCode: StatusCodes.Status400BadRequest));
        }
        var (urlGambar, hostUrlGambar, imageInByte) = imageHelper.HandleImage(command.Gambar);

        ItemDTO item = Helper.MapToItemDTO(command, urlGambar, hostUrlGambar, imageInByte);

        var result = await services.UpdateItem(id, item);
        return result.Match<IResult>(
            Ok,
            error => Problem(statusCode: StatusCodes.Status400BadRequest));
    }



    private static async Task<IResult> DeleteItem(ItemServices services, int id)
    {
        var result = await services.DeleteItem(id);

        return result.Match<IResult>(
            Ok,
            error => BadRequest(error));
    }

}
