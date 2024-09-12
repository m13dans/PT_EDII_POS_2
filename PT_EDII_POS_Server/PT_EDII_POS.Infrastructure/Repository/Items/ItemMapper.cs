using PT_EDII_POS.Application.Items;
using PT_EDII_POS.Domain.Items;

namespace PT_EDII_POS.Infrastructure.Repository.Items;

public class ItemMapper
{
    public static Item Map(ItemDTO itemDTO) =>
        new()
        {
            NamaBarang = itemDTO.NamaBarang,
            Harga = itemDTO.Harga,
            StokAwal = itemDTO.StokAwal,
            Kategori = itemDTO.Kategori,
            UrlGambar = itemDTO.HostUrlGambar
        };
}