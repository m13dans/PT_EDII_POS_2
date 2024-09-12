using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PT_EDII_POS.API.Features.Reports;

public class QueryOption
{
    public OrderOption OrderOption { get; set; }
}

public enum OrderOption
{
    [Display(Name = "Tanggal Transaksi")] TanggalTransaksi,
    [Display(Name = "Total Transaksi")] TotalTransaksi
}
