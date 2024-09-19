using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;

namespace PT_EDII_POS.PWA.Pages.Items;

public class ItemModel
{
	public int Id { get; set; }
	[Required]
	[Length(3, 255, ErrorMessage = "Minimal 3 Maskimal 255 Karakter")]
	public string NamaBarang { get; set; } = string.Empty;
	[Required]
	[Range(0, double.MaxValue, ErrorMessage = "Jangan kurang dari 0")]
	public decimal Harga { get; set; }
	[Required]
	[Range(0, double.MaxValue, ErrorMessage = "Jangan kurang dari 0")]
	public int StokAwal { get; set; }
	[Required]
	[Length(3, 255, ErrorMessage = "Minimal 3 Maskimal 255 Karakter")]

	public string Kategori { get; set; } = string.Empty;
	public string UrlGambar { get; set; } = string.Empty;
	public IBrowserFile? Gambar { get; set; }
}
