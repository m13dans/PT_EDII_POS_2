public class TransactionModel
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public int JumlahItem { get; set; }
    public string Kategori { get; set; } = string.Empty;
    public decimal Harga { get; set; }
    public decimal TotalHarga { get; set; }
    public DateOnly TanggalTransaksi { get; set; }
}
