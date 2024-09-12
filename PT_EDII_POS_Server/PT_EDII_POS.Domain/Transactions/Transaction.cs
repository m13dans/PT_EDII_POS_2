using PT_EDII_POS.Domain.Items;

namespace PT_EDII_POS.Domain.Transactions;

public class Transaction
{
    public int Id { get; set; }
    public required int ItemId { get; set; }
    public required int JumlahItem { get; set; }
    public required string Kategori { get; set; }
    public required decimal Harga { get; set; }
    public required decimal TotalHarga { get; set; }
    public DateOnly TanggalTransaksi { get; set; }
}
