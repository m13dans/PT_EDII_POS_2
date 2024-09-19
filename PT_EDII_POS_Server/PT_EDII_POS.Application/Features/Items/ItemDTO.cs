namespace PT_EDII_POS.Application.Features.Items;

public record ItemDTO
{
    public required string NamaBarang { get; set; }
    public required decimal Harga { get; set; }
    public required int StokAwal { get; set; }
    public required string Kategori { get; set; }
    public byte[] Gambar { get; set; }
    public string AbsoluteUrlGambar { get; set; }
    public string HostUrlGambar { get; set; }
}
