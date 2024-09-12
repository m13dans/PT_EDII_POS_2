using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using FluentValidation;
using PT_EDII_POS.Domain.Items;

namespace PT_EDII_POS.Application.Items;
public class ItemServices(IItemRepository repo)
{
    public async Task<List<Item>> GetItems()
    {
        var items = await repo.GetItems();
        return items;
    }

    public async Task<ErrorOr<Item>> CreateItem(
        ItemDTO item)
    {
        var result = await repo.CreateItem(item);
        return result;
    }

    public async Task<ErrorOr<Item>> UpdateItem(int id, ItemDTO item)
    {
        var result = await repo.UpdateItem(id, item);
        return result;
    }

    public async Task<ErrorOr<Item>> DeleteItem(int id)
    {
        var result = await repo.DeleteItem(id);
        return result;
    }
}
