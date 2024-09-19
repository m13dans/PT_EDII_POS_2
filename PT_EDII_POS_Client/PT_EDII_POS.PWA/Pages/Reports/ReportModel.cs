public class ReportModel
{
    public DateOnly TanggalTransaksi { get; set; }
    public List<int> ItemId { get; set; }
    public List<string> Kategori { get; set; }
    public int TotalTransaksi { get; set; }
    public decimal TotalHargaTransaksi { get; set; }

}