using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PT_EDII_POS.Application.Items;
using PT_EDII_POS.Domain.Items;
using PT_EDII_POS.Infrastructure.DataContext;

namespace PT_EDII_POS.Infrastructure.Repository.Items;

public class ItemRepository(AppDbContext dbContext) : IItemRepository
{

    public async Task<List<Item>> GetItems()
    {
        var result = await dbContext.Items.ToListAsync();
        return result;
    }
    public async Task<ErrorOr<Item>> CreateItem(ItemDTO item)
    {
        Item newItem = ItemMapper.Map(item);
        var result = await dbContext.Items.AddAsync(newItem);

        await SaveImage(item.AbsoluteUrlGambar, item.Gambar);
        await dbContext.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<ErrorOr<Item>> UpdateItem(int id, ItemDTO itemUpdated)
    {
        var item = await dbContext.Items.SingleOrDefaultAsync(x => x.Id == id);

        if (item is null)
            return Error.NotFound("Item.NotFound");

        item.NamaBarang = itemUpdated.NamaBarang;
        item.Harga = itemUpdated.Harga;
        item.StokAwal = itemUpdated.StokAwal;
        item.Kategori = itemUpdated.Kategori;
        item.UrlGambar = itemUpdated.HostUrlGambar;

        var result = dbContext.Items.Update(item);
        await SaveImage(itemUpdated.AbsoluteUrlGambar, itemUpdated.Gambar);
        await dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<ErrorOr<Item>> DeleteItem(int id)
    {
        var item = await dbContext.Items.SingleOrDefaultAsync(x => x.Id == id);

        if (item is null)
            return Error.NotFound("Item.NotFound");

        var result = dbContext.Items.Remove(item);

        await dbContext.SaveChangesAsync();
        return result.Entity;
    }

    private static async Task SaveImage(string urlGambar, byte[] byteGambar)
    {
        using var memoryStream = new MemoryStream(byteGambar);
        FormFile formFile = new(
            memoryStream,
            0,
            memoryStream.Length,
            Path.GetFileNameWithoutExtension(urlGambar),
            Path.GetFileName(urlGambar));

        using var stream = new FileStream(urlGambar, FileMode.Create);
        await formFile.CopyToAsync(stream);
    }
}
