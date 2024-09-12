using PT_EDII_POS.Application.Items;
using PT_EDII_POS.Domain.Items;

namespace PT_EDII_POS.API.Features.Items;

public class Helper
{
    public static ItemDTO MapToItemDTO(
        CreateItemCommand command,
        string urlGambar,
        string hostUrlGambar,
        byte[] imageInBytes)
    {
        return new ItemDTO()
        {
            NamaBarang = command.NamaBarang,
            Harga = command.Harga,
            StokAwal = command.StokAwal,
            Kategori = command.Kategori,
            Gambar = imageInBytes,
            AbsoluteUrlGambar = urlGambar,
            HostUrlGambar = hostUrlGambar
        };
    }
    public static ItemDTO MapToItemDTO(
        UpdateItemCommand command,
        string urlGambar,
        string hostUrlGambar,
        byte[] imageInBytes)
    {
        return new ItemDTO()
        {
            NamaBarang = command.NamaBarang,
            Harga = command.Harga,
            StokAwal = command.StokAwal,
            Kategori = command.Kategori,
            Gambar = imageInBytes,
            HostUrlGambar = hostUrlGambar,
            AbsoluteUrlGambar = urlGambar
        };
    }
}
