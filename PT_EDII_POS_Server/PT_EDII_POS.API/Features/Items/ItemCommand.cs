namespace PT_EDII_POS.API.Features.Items;

public record CreateItemCommand
{
    public required string NamaBarang { get; init; }
    public required decimal Harga { get; init; }
    public required int StokAwal { get; init; }

    public required string Kategori { get; init; }
    public required IFormFile Gambar { get; init; }
};
public record UpdateItemCommand
{
    public required string NamaBarang { get; init; }
    public required decimal Harga { get; init; }
    public required int StokAwal { get; init; }
    public required string Kategori { get; init; }
    public required IFormFile Gambar { get; init; }
};