namespace PT_EDII_POS.API.Features.Items;

public class ItemResponse
{
	public int Id { get; set; }
	public string NamaBarang { get; set; } = string.Empty;
	public decimal Harga { get; set; }
	public int StokAwal { get; set; }
	public string Kategori { get; set; } = string.Empty;
	public string UrlGambar { get; set; } = string.Empty;
	public IFormFile? Gambar { get; set; }
}
