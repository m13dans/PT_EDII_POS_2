namespace PT_EDII_POS.Domain.Stocks;

public class Stock
{
    public required string NamaBarang { get; set; }
    public required string Kategori { get; set; }
    public required int JumlahStokSaatIni { get; set; }
    public required decimal Harga { get; set; }
}