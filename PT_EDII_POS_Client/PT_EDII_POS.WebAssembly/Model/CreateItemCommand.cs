using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace PT_EDII_POS.WebAssembly.Model;

public record CreateItemCommand
{
    [Required, MaxLength(255)]
    public string NamaBarang { get; set; } = string.Empty;
    [Required]
    public decimal Harga { get; set; }
    [Required]
    public int StokAwal { get; set; }
    [Required, MaxLength(255)]

    public string Kategori { get; set; } = string.Empty;

    [Required]
    public IFormFile Gambar { get; set; }
};
