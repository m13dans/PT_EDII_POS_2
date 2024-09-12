using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PT_EDII_POS.Application.Items;

public record ItemDTO
{
    public required string NamaBarang { get; set; }
    public required decimal Harga { get; set; }
    public required int StokAwal { get; set; }
    public required string Kategori { get; set; }
    public required byte[] Gambar { get; set; }
    public required string AbsoluteUrlGambar { get; set; }
    public required string HostUrlGambar { get; set; }
}
