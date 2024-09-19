using ErrorOr;
using Microsoft.EntityFrameworkCore;
using PT_EDII_POS.Application.Features.Items;
using PT_EDII_POS.Domain.Items;
using PT_EDII_POS.Infrastructure.DataContext;
using static PT_EDII_POS.Infrastructure.Features.Items.ImageHelper.ItemImageHelper;

namespace PT_EDII_POS.Infrastructure.Features.Items;

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

        var rowAffected = await dbContext.SaveChangesAsync();

        if (rowAffected <= 0)
            return Error.Validation("Item.Validation", "Tidak dapat menambahkan item");

        await SaveImage(item.AbsoluteUrlGambar, item.Gambar);
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

    public async Task<ErrorOr<Item>> GetItemById(int id)
    {
        var result = await dbContext.Items.SingleOrDefaultAsync(x => x.Id == id);
        if (result is null)
            return Error.NotFound("Item.NotFound", "Item tidak ditemukan");

        return result;
    }
}
