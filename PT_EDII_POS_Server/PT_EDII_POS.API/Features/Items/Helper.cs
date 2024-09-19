using PT_EDII_POS.Application.Features.Items;

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
        byte[]? imageInBytes)
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
    public static ItemDTO MapItemWithoutImage(UpdateItemCommand command)
    {
        ItemDTO item = new()
        {
            NamaBarang = command.NamaBarang,
            Harga = command.Harga,
            StokAwal = command.StokAwal,
            Kategori = command.Kategori,
            HostUrlGambar = command.UrlGambar,
        };

        return item;
    }
}
