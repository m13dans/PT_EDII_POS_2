using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PT_EDII_POS.Domain.Reports;

public class Report
{
    public DateOnly TanggalTransaksi { get; set; }
    public required List<int> ItemId { get; set; }
    public required List<string> Kategori { get; set; }
    public int TotalTransaksi { get; set; }
    public decimal TotalHargaTransaksi { get; set; }

}
