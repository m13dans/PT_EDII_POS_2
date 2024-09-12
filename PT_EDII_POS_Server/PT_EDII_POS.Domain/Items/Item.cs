using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PT_EDII_POS.Domain.Items;

public class Item
{
  public int Id { get; set; }
  public required string NamaBarang { get; set; }
  public required decimal Harga { get; set; }
  public required int StokAwal { get; set; }
  public required string Kategori { get; set; }
  public required string UrlGambar { get; set; }
}
